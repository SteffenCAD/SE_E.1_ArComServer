using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using DUR.DATA;

namespace AR.COM.DATA
{
    public class OPCua : JSON
    {
        #region dataStuctureStuff
        [Category("DataStructureSuff")]
        [Browsable(false)]
        public bool enablePropertyToSend { get; set; } = true;
        #endregion

        #region ArComControl
        [Browsable(false)]
        private List<string> SubList_value { get; set; } = null;
        [Browsable(false)]
        private Int16 SubCycle_value { get; set; } = 0;
        [Browsable(false)]
        private bool SubStart_value { get; set; } = false;
        [Browsable(false)]
        private string Address_value { get; set; } = null;
        [Browsable(false)]
        private bool Connect_value { get; set; } = false;
        [Browsable(false)]
        private bool Connected_value { get; set; } = false;

        [Category("ArComControl")]
        public List<string> SubList
        {
            get { return SubList_value; }
            set
            {
                SubList_value = value;
                NotifyPropertyChanged();
                NotifyPropertyToSend();
            }
        }

        [Category("ArComControl")]
        public Int16 SubCycle
        {
            get { return SubCycle_value; }
            set
            {
                SubCycle_value = value;
                NotifyPropertyChanged();
                NotifyPropertyToSend();
            }
        }

        [Category("ArComControl")]
        public bool SubStart
        {
            get { return SubStart_value; }
            set
            {
                SubStart_value = value;
                NotifyPropertyChanged();
                NotifyPropertyToSend();
            }
        }

        [Category("ArComControl")]
        public string Address
        {
            get { return Address_value; }
            set
            {
                Address_value = value;
                NotifyPropertyChanged();
                NotifyPropertyToSend();
            }
        }
        
        [Category("ArComControl")]
        public bool Connect
        {
            get { return Connect_value; }
            set
            {
                Connect_value = value;
                NotifyPropertyChanged();
                NotifyPropertyToSend();
            }
        }

        [Category("ArComControl")]
        public bool Connected
        {
            get { return Connected_value; }
            set
            {
                Connected_value = value;
                NotifyPropertyChanged();
                NotifyPropertyToSend();
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
            if (enablePropertyToSend)
            {
                PropertyToSend?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void SocketReceived(string data)
        {
            //disable sending if data is received from node red
            this.enablePropertyToSend = false;
            this.fromJSON(data);
            this.enablePropertyToSend = true;
        }

        #endregion
    }
}
