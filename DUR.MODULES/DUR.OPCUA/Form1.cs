//https://github.com/joc-luis/OPCUaClient/blob/master/README.md
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;
using OPCUaClient.Objects;
using OPCUaClient.Exceptions;
using Opc.Ua.Configuration;
using System.Threading;
using System.IO;

namespace DUR.OPCUA
{
    public partial class Form1 : Form
    {
        public UaClient OpcClient;

        public UaUi ui = new UaUi();


        public Form1()
        {
            InitializeComponent();

            TbServerAddress.Text    = "opc.tcp://192.168.0.1:4840";
            CbSecurity.Checked      = false;
            CbUntrusted.Checked     = true;

        }

        public void createSession()
        {
            try
            {
                OpcClient = new UaClient("test", TbServerAddress.Text, CbSecurity.Checked, CbUntrusted.Checked);
                
                uint timeOut = 30;
                OpcClient.Connect(timeOut, true);

                ui.connect(OpcClient, treeView1,listView1);

            }
            catch
            {

            }
        }



        public void readTag()
        {
            try
            {
                TbTagValue.Text = OpcClient.Read(TbTagName.Text).ToString();

            }
            catch { }
        }

        public void wirteTag()
        {
            try
            {
                OpcClient.Write(TbTagName.Text, bool.Parse(TbTagValue.Text));
            }
            catch { }
        }

        public void monitorTag()
        {
            OpcClient.Monitoring(TbTagName.Text,200, MonitoringHandler);
        }

        public void MonitoringHandler(MonitoredItem Item, MonitoredItemNotificationEventArgs args)
        {

            //MonitoredItemNotification value = (MonitoredItemNotification)args.NotificationValue;

            if (LbMonitoring.InvokeRequired)
            {
                LbMonitoring.BeginInvoke(new Action(delegate {
                    MonitoringHandler(Item, args);
                }));
                return;
            }

            var monitored = (MonitoredItemNotification)args.NotificationValue;

            NodeId id = (NodeId)Item.StartNodeId;
            


            LbMonitoring.Text = id.Identifier.ToString() + " | " + monitored.Value.ToString();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            createSession();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            readTag();
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            wirteTag();
        }

        private void TbMonitor_Click(object sender, EventArgs e)
        {
            monitorTag();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpcClient.ScanTags(ObjectIds.ObjectsFolder);
            
            foreach(ReferenceDescription Tag in OpcClient.TagBook)
            {
                TreeNode TN = new TreeNode();
                TN.Text = Tag.BrowseName.ToString();

                TvScannedTags.Nodes.Add(TN);
            }
        }

        private void TmBackground_Tick(object sender, EventArgs e)
        {
            if(OpcClient != null)
            {
                if(OpcClient.IsConnected)
                {
                    LbState.Text = "CONNECTED";
                    LbState.ForeColor = Color.Green;
                }
                else
                {
                    LbState.Text = "DISCONNECTED";
                    LbState.ForeColor = Color.Red;
                }
            }
            else
            {
                LbState.Text = "DISCONNECTED";
                LbState.ForeColor = Color.Red;
            }
        }

        private void TvScannedTags_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = TvScannedTags.SelectedNode;
            TbTagName.Text = selectedNode.Text;
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            OpcClient.Disconnect();
        }
    }
}
