﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//https://github.com/joc-luis/OPCUaClient/blob/master/README.md
using Opc.Ua;using Opc.Ua.Client;
using OPCUaClient.Objects;
using OPCUaClient.Exceptions;
using Opc.Ua.Configuration;
using System.Threading;
using System.IO;

namespace DUR.OPCUA
{
    public partial class Form1 : Form
    {
        public UaClient client;

        public UaUi ui = new UaUi();


        public Form1()
        {
            InitializeComponent();
        }

        public void createSession()
        {
            try
            {
                //client = new UaClient("test", "opc.tcp://desktop-e7rdrqt:51210/UA/SampleServer", true, true);
                client = new UaClient("test", "opc.tcp://192.168.0.1:4840", false, true);
                uint timeOut = 30;
                client.Connect(timeOut, true);

                ui.connect(client,treeView1,listView1);

            }
            catch
            {

            }
        }



        public void readTag()
        {
            OPCUaClient.Objects.Tag tag  = new OPCUaClient.Objects.Tag();

            try
            {
                tag = client.Read(TbTagName.Text);
                TbTagValue.Text = tag.Value.ToString();
            }
            catch { }
        }

        public void wirteTag()
        {
            try
            {
                object tagValue = TbWriteValue.Text;
                client.Write(TbTagName.Text, tagValue);
            }
            catch { }
        }

        public void monitorTag()
        {
            Console.WriteLine("test");
            client.Monitoring(TbTagName.Text, 200, (_, e) =>
            {
                MonitoredItemNotification value = (MonitoredItemNotification)e.NotificationValue;
               
                Console.WriteLine(value.Value.ToString());
                //TbTagValue.Text = value.ToString();
            });
        }

        public void getTags()
        {
            List<OPCUaClient.Objects.Tag> tags = new List<OPCUaClient.Objects.Tag>();

            try
            {
                tags = client.Tags("Realtimedata");

            }
            catch { }
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            createSession();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            readTag();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            wirteTag();
        }

        private void TbMonitor_Click(object sender, EventArgs e)
        {
            monitorTag();
        }

        private void BtnScan_Click(object sender, EventArgs e)
        {
            try
            {
                var groups = client.Groups("Device", true);
                var tags = client.Tags("opc.tcp://desktop-e7rdrqt:62640");
                //Or
                //tags = await client.TagsAsync("Device.Counter");

                foreach (var tag in tags)
                {
                    Console.WriteLine($"Name: {tag.Name}");
                    Console.WriteLine($"Address: {tag.Address}");
                }
            }
            catch(Exception ex)
            {
                e = e; 
            }
        }
    }
}