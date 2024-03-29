﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;


namespace DUR.SOCKETS
{
    public partial class FrmMainDur : Form
    {

        MSOCKET SockSer = new MSOCKET();

        ChatClient cc;

        public FrmMainDur()
        {
            InitializeComponent();

            SockSer.init("127.0.0.1", "127.0.0.1", 60001, 60001);

            SockSer.SocketReceived += SockSer_SocketReceived;
        }

        private void SockSer_SocketReceived(string data)
        {
            if (TbTextToSend.InvokeRequired)
            {
                TbTextToSend.BeginInvoke(new Action(delegate
                {
                    SockSer_SocketReceived(data);
                }));
                return;
            }

            TbTextReceived.Text = data;
        }

        private void Cc_MessageRecieved(string obj)
        {
            Console.WriteLine("CC " + (string)obj);
        }

        private void BtnClientSend_Click(object sender, EventArgs e)
        {
            SockSer.sendString(TbTextToSend.Text);
        }

        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            SockSer.start();
        }
        private void BtnStopServer_Click(object sender, EventArgs e)
        {
            SockSer.stop();
        }
    }




    public class ChatClient
    {
        public event Action<String> MessageRecieved;

        private TcpClient socket;
        public ChatClient(String host, int port)
        {
            socket = new TcpClient(host, port);
            Thread listenThread = new Thread(ReadThread);
            listenThread.Start();
        }

        private void ReadThread()
        {
            NetworkStream netStream = socket.GetStream();
            while (socket.Connected)
            {
                //Read however you want, something like:
                // Reads NetworkStream into a byte buffer. 
                byte[] bytes = new byte[socket.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead.  
                // This method blocks until at least one byte is read.
                netStream.Read(bytes, 0, (int)socket.ReceiveBufferSize);

                // Returns the data received from the host to the console. 
                MessageRecieved(Encoding.UTF8.GetString(bytes));
            }
        }

        public void SendMessage(string msg)
        {
            NetworkStream netStream = socket.GetStream();
            Byte[] sendBytes = Encoding.UTF8.GetBytes(msg);
            netStream.Write(sendBytes, 0, sendBytes.Length);
        }
    }

}
