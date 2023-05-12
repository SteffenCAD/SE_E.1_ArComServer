using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//custom namespaces
using DUR.RTBLOGGER;
using DUR.SOCKETS;
using DUR.CONFIG;
using DUR.OPCUA;
using AR.COM.DATA;


namespace PLC2SOCKET
{
    public partial class FrmMainPlc2Socket : Form
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

        public FrmMainPlc2Socket()
        {
            InitializeComponent();

            logger.setLogger(RtbLog);
        
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //do application setting stuff

            //handle Settings
            Einstellungen = (AR.COM.DATA.Settings)config.load(configPath,typeof(AR.COM.DATA.Settings), true);
            Einstellungen.PropertyChanged += Einstellungen_PropertyChanged;

            PgSettings.SelectedObject = Einstellungen;
            TbOpcAddress.Text = Einstellungen.Opc_ServerAddress;



            OpcControl.PropertyChanged += OpcControl_PropertyChanged;

            //init socket
            OpcSocket.init(Einstellungen.Socket_IP_SENDING, Einstellungen.Socket_IP_RECEIVING, (int)Einstellungen.Socket_PORT_SENDING, (int)Einstellungen.Socket_PORT_RECEIVING, logger);

            //connect socket to data objects
            OpcControl.PropertyToSend += OpcSocket.PropertyToSend;
            OpcSocket.SocketReceived += OpcControl.SocketReceived;

            //start socket
            OpcSocket.start();
        }



        private void BtnSendString_Click(object sender, EventArgs e)
        {
            OpcSocket.sendString(TbSendString.Text);
        }


        #region settings
        private void BtnSettingsSave_Click(object sender, EventArgs e)
        {
            Settings_Save();
        }

        private void BtnSettingsLoad_Click(object sender, EventArgs e)
        {
            Settings_load();
        }

        private void Einstellungen_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Settings_Save();
        }

        private void Settings_Save()
        {
            Einstellungen = (AR.COM.DATA.Settings)PgSettings.SelectedObject;
            Einstellungen.save(configPath);
        }

        private void Settings_load()
        {
            Einstellungen = (AR.COM.DATA.Settings)config.load(configPath, typeof(AR.COM.DATA.Settings), true);
            PgSettings.SelectedObject = Einstellungen;
        }

        #endregion

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
        private void OpcControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void TbOpcAddress_TextChanged(object sender, EventArgs e)
        {
            Einstellungen.Opc_ServerAddress = TbOpcAddress.Text;
        }
    }
}
