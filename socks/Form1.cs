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
            //s.Blocking = true;
            int byteLen;
            byteLen = s.ReceiveFrom(buffer, ref ep);
            printTextLine("Port " + port + " says: " + ASCIIEncoding.ASCII.GetString(buffer, 0, byteLen));
            return true;
        }
        bool send(Socket s, string host, int port, string message)
        {
            if (s == null)
            {
                return false;
            }
            IPAddress[] ips = Dns.GetHostAddresses(host); //[0] is ipv6, [1] is ipv4. This may not always be true. Find a better solution.
            IPAddress[] ip4s = Array.FindAll(ips, (a) => a.AddressFamily == AddressFamily.InterNetwork);
            IPEndPoint remote = new IPEndPoint(ip4s[0], port);
            EndPoint end = (EndPoint)remote;
            s.SendTo(Encoding.ASCII.GetBytes(message), end);
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
                printTextLine("An excpetion has occurred " + exp.Message);
            }
        }

        private void B_send_Click(object sender, EventArgs e)
        {
            string hostname = tb_hostname.Text;
            string message = tb_message.Text;
            int port = (int)nud_sendport.Value;
            printTextLine("Sending message to " + hostname + " (Port " + port + ")");
            try
            {
                if (!send(sendSock, hostname, port, message))
                {
                    MessageBox.Show("A sending error has occurred.");
                }
            }
            catch (Exception exp)
            {
                printTextLine("An exception occurred: " + exp.Message);
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
    }
}
