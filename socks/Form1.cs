using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace socks
{
    public partial class Form1 : Form
    {
        Socket sendSock;
        Socket recvSock;
        public Form1()
        {
            InitializeComponent();
            openSocket(ref sendSock, IPAddress.Any);
            bindReceiver((int)nud_receiveport.Value);
        }
        void printTextLine(string message)
        {
            rtb_output.Text += ">> " + message + '\n';//System.Environment.NewLine;
        }
        void openSocket(ref Socket s, IPAddress ip)
        {
            if (s != null)
            {
                s.Close();
            }
            s = new Socket(ip.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        }
        Packet recv(Socket s, int port)
        {
            Debug.WriteLine("Receiving packet.");
            if (s == null) return null;

            s.Blocking = false;
            Byte[] buffer = new byte[128];
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, port);
            EndPoint ep = (EndPoint)ipe;
            int byteLen =0;
            
            try
            {
                byteLen = s.ReceiveFrom(buffer, ref ep);
                Debug.WriteLine("Packet received. Size: " + byteLen);
            }
            catch (Exception e)
            {
                //printTextLine("A receiving error has occurred: " + e.Message);
            }

            if (byteLen == 0) return null;
            
            Array.Resize(ref buffer, byteLen);
            Packet p = new Packet(buffer); IPEndPoint remoteip = (IPEndPoint)ep;

            Debug.WriteLine("Sending acknowledgement");
            int sendPort = (int)nud_sendport.Value;
            IPEndPoint remIp = new IPEndPoint(remoteip.Address, sendPort);
            s.SendTo(Packet.ACK_Pack().Data, (EndPoint)remIp);
            Debug.WriteLine("Acknowledgement sent to host " +
                Dns.GetHostEntry(remIp.Address).HostName + ", on port " + remIp.Port);
            return p;
        }
        Packet[] recvAll(Socket s, int port)
        {
            List<Packet> inp = new List<Packet>();
            while(true)
            {
                Debug.WriteLine("recvAll: Receiving next packet.");
                Packet p = recv(s, port);
                if (p == null)
                {
                    break;
                }
                inp.Add(p);
            }
            return inp.ToArray();
        }
        bool send(Socket s, string host, int port, Packet[] packs)
        {
            if (s == null)
            {
                return false;
            }
            IPAddress[] ips = Dns.GetHostAddresses(host); //[0] is ipv6, [1] is ipv4. This may not always be true. Find a better solution.
            IPAddress[] ip4s = Array.FindAll(ips, (a) => a.AddressFamily == AddressFamily.InterNetwork);
            IPEndPoint remote = new IPEndPoint(ip4s[0], port);
            EndPoint end = (EndPoint)remote;
            foreach (Packet pack in packs)
            {
                s.SendTo(pack.Data, end);
            }
            return true;
        }
        private void B_listen_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Button clicked");
            int port = (int)nud_receiveport.Value;
            Packet[] p = recvAll(recvSock, port);
            foreach(Packet pack in p)
            {
                Debug.WriteLine("Reading received packets");
                printTextLine("Packet type is: " +
                    Packet.typeToString(pack.getType()));
                if (pack.getType() == (Byte)Packet.PacketType.Data)
                {
                    printTextLine(
                        Encoding.ASCII.GetString(pack.getPayload()));
                }
            }
        }

        private void B_send_Click(object sender, EventArgs e)
        {
            string hostname = tb_hostname.Text;
            string message = tb_message.Text;
            int port = (int)nud_sendport.Value;
            Packet[] packs = Packer.PackageData(
                Encoding.ASCII.GetBytes(tb_message.Text));
            printTextLine("Sending " + packs.Length + " packets to " + hostname + " (Port " + port + ")");
            try
            {
                if (!send(sendSock, hostname, port, packs))
                {
                    MessageBox.Show("A sending error has occurred.");
                }
            }
            catch (Exception exp)
            {
                printTextLine("A sending exception occurred: " + exp.Message);
            }
        }
        void bindReceiver(int port)
        {
            //recvSock.Shutdown();
            if (recvSock != null)
            {
                recvSock.Close();
            }
            openSocket(ref recvSock, IPAddress.Any);
            EndPoint local = (EndPoint)(new IPEndPoint(IPAddress.Any, port));
            recvSock.Bind(local);
        }
        private void Nud_receiveport_ValueChanged(object sender, EventArgs e)
        {
            int port = (int)nud_receiveport.Value;
            bindReceiver(port);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Packet[] packets = Packer.PackageData(Encoding.ASCII.GetBytes(tb_message.Text));
            printTextLine("Number of packets: " + packets.Length);
        }
    }
}
