using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour.View
{
    public partial class ServerForm : Form
    {
        private TcpClient client;
        public StreamReader str;
        public StreamWriter stw;
        public String recieve;
        public String text_to_send;
        public int readyCount = 0;
        public bool serverUser, clientUser, clientReady, serverReady;

        public ServerForm()
        {
            InitializeComponent();

            //gets my ip address
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox3.Text = address.ToString();
                }
            }
        }

        //Starts the server
        private void startServerButton_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(textBox4.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            str = new StreamReader(client.GetStream());
            stw = new StreamWriter(client.GetStream());
            stw.AutoFlush = true;

            serverUser = true;
            readyUpButton.Enabled = true;

            //Starts recieving data in background
            backgroundWorker1.RunWorkerAsync();
            //ability to cancel this thread
            backgroundWorker2.WorkerSupportsCancellation = true;
        }

        //Recieves the data
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    recieve = str.ReadLine();
                    this.textBox2.Invoke(new MethodInvoker(delegate () { textBox2.AppendText("You: " + recieve + "\n"); }));
                    recieve = "";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        //sends the data
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (client.Connected)
            {
                stw.WriteLine(text_to_send);
                this.textBox2.Invoke(new MethodInvoker(delegate () { textBox2.AppendText("Me: " + text_to_send + "\n"); }));
            }
            else
            {
                MessageBox.Show("Message has failed to send!");
            }
            backgroundWorker2.CancelAsync();
        }

        private void returnToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenuForm m = new MainMenuForm();
            m.Closed += (s, args) => this.Close();
            m.Show();
        }

        //Connect to server
        private void connectButton_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(textBox5.Text), int.Parse(textBox6.Text));

            try
            {
                client.Connect(IP_End);
                if (client.Connected)
                {
                    textBox2.AppendText("Connected to Server" + "\n");
                    stw = new StreamWriter(client.GetStream());
                    str = new StreamReader(client.GetStream());
                    stw.AutoFlush = true;
                    readyUpButton.Enabled = true;
                    clientUser = true;

                    //Starts recieving data in background
                    backgroundWorker1.RunWorkerAsync();
                    //ability to cancel this thread
                    backgroundWorker2.WorkerSupportsCancellation = true;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                text_to_send = textBox1.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            textBox1.Text = "";
        }

        private void readyUpButton_Click(object sender, EventArgs e)
        {
            readyUpButton.Enabled = false;
            if (serverUser)
            {
                serverReady = true;
            }
            if (clientUser)
            {
                clientReady = true;
            }
            if (!clientReady || !serverReady)
            {
                WaitForm w = new WaitForm(this);
                w.Show();
                while (clientReady || serverReady)
                {
                    SpinWait.SpinUntil(ReadyUp,1000);
                    if (clientReady && serverReady)
                        break;
                }
            }
            if (clientReady && serverReady)
            {
                this.Hide();
                GameBoardForm g = new GameBoardForm();
                g.Closed += (s, args) => this.Close();
                g.Show();
                readyCount = 0;
            }
        }

        private bool ReadyUp()
        {
            return clientReady && serverReady;
        }

    }
}
