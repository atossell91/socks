using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        bool listen(Socket s, int port)
        {
            if (s == null)
            {
                return false;
            }

            Byte[] buffer = new byte[128];
            //IPAddress ip = Dns.GetHostAddresses(host)[0];
            //IPEndPoint remote = new IPEndPoint(ip, port);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, port);

            EndPoint ep = (EndPoint)ipe;
            s.Blocking = false;
            int byteLen;
            byteLen = s.ReceiveFrom(buffer, ref ep);
            Array.Resize(ref buffer, byteLen);
            Packet p = new Packet(buffer);
            if (p.getType() == (Byte)Packet.PacketType.Data)
            {
                printTextLine("Received packet contains: " + Encoding.ASCII.GetString(p.getPayload()));
                int ackBytes = s.SendTo(Packet.ACK_Pack().Data, ep);
                printTextLine("Sent Ack: " + ackBytes + " bytes");
            }
            else
            {
                printTextLine("Packet type is: " + (int)p.getType());
            }
            return true;
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
            try
            {
                recvSock.ReceiveTimeout = 5000;
                int port = (int)nud_receiveport.Value;
                if (!listen(recvSock, port))
                {
                    MessageBox.Show("A receiving error has occurred.");
                }
            }
            catch (Exception exp)
            {
                printTextLine("A receiving excpetion has occurred " + exp.Message);
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
