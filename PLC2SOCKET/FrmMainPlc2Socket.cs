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
using AR.COM.ROUTING;
using AR.COM.DATA;
using static System.Windows.Forms.AxHost;


namespace PLC2SOCKET
{
    public partial class FrmMainPlc2Socket : Form
    {
        private string configPathMi = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "//ArComMi.xml";
        private string configPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + "//ArComSettings.xml";

        MSOCKET OpcSocket = new MSOCKET();
        MrtbLogger logger = new MrtbLogger();

        Mconfig config = new Mconfig();

        private AR.COM.DATA.Settings AppSettings = new AR.COM.DATA.Settings();

        private AR.COM.DATA.OPCua OpcControl = new AR.COM.DATA.OPCua();
        private OPCROUTING opcrouting;

        //OPCua client
        UaClient OpcClient = null;

        public FrmMainPlc2Socket()
        {
            InitializeComponent();

            logger.setLogger(RtbLog);
        
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //do application setting stuff

            //handle Settings
            AppSettings = (AR.COM.DATA.Settings)config.load(configPath,typeof(AR.COM.DATA.Settings), true);
            AppSettings.PropertyChanged += Einstellungen_PropertyChanged;

            PgSettings.SelectedObject = AppSettings;

            //init socket
            OpcSocket.init(AppSettings.Socket_IP_SENDING, AppSettings.Socket_IP_RECEIVING, (int)AppSettings.Socket_PORT_SENDING, (int)AppSettings.Socket_PORT_RECEIVING, logger);

            //start socket
            if (AppSettings.Socket_Autoconnect)
            {
                OpcSocket.start();
            }

            //OPCua Client
            OpcClient = new UaClient(AppSettings.Opc_AppName,AppSettings.Opc_ServerAddress, AppSettings.Opc_UseSecurity, AppSettings.Opc_Untrusted);

            if(AppSettings.Opc_Autoconnect)
            {
                OpcConnect();
            }
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
            AppSettings = (AR.COM.DATA.Settings)PgSettings.SelectedObject;
            AppSettings.save(configPath);
        }

        private void Settings_load()
        {
            AppSettings = (AR.COM.DATA.Settings)config.load(configPath, typeof(AR.COM.DATA.Settings), true);
            PgSettings.SelectedObject = AppSettings;
        }

        #endregion

        #region OPCua
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            OpcConnect();
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            OpcDisconnect();
        }

        private void OpcConnect()
        {
            try
            {
                //check if OpcClient is not connected 
                if (OpcClient != null)
                {
                    OpcClient.Disconnect();
                }

                OpcClient = new UaClient("ArComServer", AppSettings.Opc_ServerAddress, AppSettings.Opc_UseSecurity, AppSettings.Opc_Untrusted);
                OpcClient.Connect(30);
                //OpcClient.ScanTagsByFolder("ServerInterfaces",3);
                OpcClient.ScanTagsByFolder("PLC", 3);

                OpcClient.Ui.connect(OpcClient, BrowseNodesTV, AttributesLV, MonitoredItemsLV);

                //connect socket to data objects
                opcrouting = new OPCROUTING(OpcClient, OpcSocket);
            }
            catch(Exception ex)
            {
                logger.Error("could not connect to OpcUA server \n" + ex);
            }
        }

        private void OpcDisconnect()
        {
            OpcClient.Disconnect();
        }

        private void BtnSaveMI_Click(object sender, EventArgs e)
        {
            OpcClient.Ui.SaveMonitoring(configPathMi);
        }
        private void BtnLoadMI_Click(object sender, EventArgs e)
        {
            OpcClient.Ui.LoadMonitoring(configPathMi);
        }
        #endregion


        #region Socket
        private void BtnSocketOpen_Click(object sender, EventArgs e)
        {
            OpcSocket.start();
        }

        private void BtnSocketClose_Click(object sender, EventArgs e)
        {
            OpcSocket.stop();
        }

        #endregion

        private void TmBackWorker_Tick(object sender, EventArgs e)
        {
            if (OpcClient != null)
            {
                if (OpcClient.IsConnected)
                {
                    LbConnectionState.Text = "CONNECTED";
                    LbConnectionState.ForeColor = Color.Green;
                }
                else
                {
                    LbConnectionState.Text = "DISCONNECTED";
                    LbConnectionState.ForeColor = Color.Red;
                }
            }
            else
            {
                LbConnectionState.Text = "DISCONNECTED";
                LbConnectionState.ForeColor = Color.Red;
            }
        }


    }
}
