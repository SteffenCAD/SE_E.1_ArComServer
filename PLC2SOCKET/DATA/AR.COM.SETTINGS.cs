using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//custom namespaces
using DUR.CONFIG;

namespace AR.COM.DATA
{
    public class Settings : Mconfig
    {
        #region SOCKET

        private bool Socket_Autoconnect_value { get; set; } = false;
        [Category("SOCKET")]
        public bool Socket_Autoconnect
        {
            get { return Socket_Autoconnect_value; }
            set
            {
                Socket_Autoconnect_value = value;
                NotifyPropertyChanged();
            }
        }

        private string Socket_IP_SENDING_value { get; set; } = "127.0.0.1";
        [Category("SOCKET")]
        public string Socket_IP_SENDING
        {
            get { return Socket_IP_SENDING_value; } 
            set
            {
                Socket_IP_SENDING_value = value;
                NotifyPropertyChanged();
            }
        }

        private string Socket_IP_RECEIVING_value { get; set; } = "127.0.0.1";
        [Category("SOCKET")]
        public string Socket_IP_RECEIVING
        {
            get { return Socket_IP_RECEIVING_value; }
            set
            {
                Socket_IP_RECEIVING_value = value;
                NotifyPropertyChanged();
            }
        }

        private UInt32 Socket_PORT_SENDING_value { get; set; } = 60100;
        [Category("SOCKET")]
        public UInt32 Socket_PORT_SENDING
        {
            get { return Socket_PORT_SENDING_value; }
            set
            {
                Socket_PORT_SENDING_value = value;
                NotifyPropertyChanged();
            }
        }

        private UInt32 Socket_PORT_RECEIVING_value { get; set; } = 60101;
        [Category("SOCKET")]
        public UInt32 Socket_PORT_RECEIVING
        {
            get { return Socket_PORT_RECEIVING_value; }
            set
            {
                Socket_PORT_RECEIVING_value = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region OPCua

        private string Opc_AppName_value { get; set; } = "opc.tcp://192.168.0.1:4840";
        [Category("OPCua")]
        public string Opc_AppName
        {
            get { return Opc_AppName_value; }
            set
            {
                Opc_AppName_value = value;
                NotifyPropertyChanged();
            }
        }

        private string Opc_ServerAddress_value { get; set; } = "opc.tcp://192.168.0.1:4840";
        [Category("OPCua")]
        public string Opc_ServerAddress
        {
            get { return Opc_ServerAddress_value; }
            set
            {
                Opc_ServerAddress_value = value;
                NotifyPropertyChanged();
            }
        }

        private uint Opc_Timeout_value { get; set; } = 30;
        [Category("OPCua")]
        public uint Opc_Timeout
        {
            get { return Opc_Timeout_value; }
            set
            {
                Opc_Timeout_value = value;
                NotifyPropertyChanged();
            }
        }

        private bool Opc_Reconnect_value { get; set; } = false;
        [Category("OPCua")]
        public bool Opc_Reconnect
        {
            get { return Opc_Reconnect_value; }
            set
            {
                Opc_Reconnect_value = value;
                NotifyPropertyChanged();
            }
        }

        private bool Opc_Autoconnect_value { get; set; } = false;
        [Category("OPCua")]
        public bool Opc_Autoconnect
        {
            get { return Opc_Autoconnect_value; }
            set
            {
                Opc_Autoconnect_value = value;
                NotifyPropertyChanged();
            }
        }

        private bool Opc_UseSecurity_value { get; set; } = false;
        [Category("OPCua")]
        public bool Opc_UseSecurity
        {
            get { return Opc_UseSecurity_value; }
            set
            {
                Opc_UseSecurity_value = value;
                NotifyPropertyChanged();
            }
        }

        private bool Opc_Untrusted_value { get; set; } = false;
        [Category("OPCua")]
        public bool Opc_Untrusted
        {
            get { return Opc_Untrusted_value; }
            set
            {
                Opc_Untrusted_value = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region PropertyChangedEVentHandler
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region PropertyToSend
        public event PropertyChangedEventHandler PropertyToSend;
        private void NotifyPropertyToSend([CallerMemberName] String propertyName = "")
        {
            PropertyToSend?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
