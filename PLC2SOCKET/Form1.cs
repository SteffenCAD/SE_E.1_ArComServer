using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES.SOCKETS;
using MES.RTBLOGGER;
using MES.CONFIG;
using AR.COM.DATA;
using PLC2SOCKET.Properties;
using System.Runtime;
using DUR.OPCUA;


namespace PLC2SOCKET
{
    public partial class Form1 : Form
    {
        private string configPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "//ArComSettings.xml";

        MSOCKET OpcSocket = new MSOCKET();
        MrtbLogger logger = new MrtbLogger();

        Mconfig config = new Mconfig();

        private AR.COM.DATA.Settings Einstellungen = new AR.COM.DATA.Settings();

        private AR.COM.DATA.OPCua OpcControl = new AR.COM.DATA.OPCua();

        //OPCua client
        UaClient OpcClient = null;
        UaUi OpcUi = new UaUi();

        public Form1()
        {
            InitializeComponent();

            logger.setLogger(RtbLog);
        
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //do application setting stuff
            Einstellungen = (AR.COM.DATA.Settings)config.load(configPath,typeof(AR.COM.DATA.Settings), true);
            PgSettings.SelectedObject = Einstellungen;


            OpcControl.PropertyChanged += OpcControl_PropertyChanged;

            //init socket
            OpcSocket.init(Einstellungen.IP_SENDING, Einstellungen.IP_RECEIVING, (int)Einstellungen.PORT_SENDING, (int)Einstellungen.PORT_RECEIVING, logger);

            //connect socket to data objects
            OpcControl.PropertyToSend += OpcSocket.PropertyToSend;
            OpcSocket.SocketReceived += OpcControl.SocketReceived;

            //start socket
            OpcSocket.start();
        }

        private void OpcControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnSendString_Click(object sender, EventArgs e)
        {
            OpcSocket.sendString(TbSendString.Text);
        }

        private void BtnSettingsLoad_Click(object sender, EventArgs e)
        {
            Einstellungen = (AR.COM.DATA.Settings)config.load(configPath, typeof(AR.COM.DATA.Settings), true);
            PgSettings.SelectedObject = Einstellungen;
        }

        private void BtnSettingsSave_Click(object sender, EventArgs e)
        {
            Einstellungen = (AR.COM.DATA.Settings)PgSettings.SelectedObject;
            Einstellungen.save(configPath);
        }


        #region OPCua
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            //check if OpcClient is not connected 
            if(OpcClient == null)
            {
                OpcClient = new UaClient("ARcomServer", "opc.tcp://wem1-l07476:62640/IntegrationObjects/ServerSimulator", false,true);
                OpcClient.Connect();

                OpcUi.connect(OpcClient, BrowseNodesTV, AttributesLV);

                


                OpcClient.Read("AR_alive");
            }

        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
