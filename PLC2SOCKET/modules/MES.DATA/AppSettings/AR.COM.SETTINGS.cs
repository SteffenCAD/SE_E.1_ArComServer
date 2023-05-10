using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MES.CONFIG;

namespace AR.COM.DATA
{
    public class Settings : Mconfig
    {
        #region PROGRAM
        [Category("SETTINGS")]
        public string IP_SENDING { get; set; } = "127.0.0.1";
        [Category("SETTINGS")]
        public string IP_RECEIVING { get; set; } = "127.0.0.1";
        [Category("SETTINGS")]
        public UInt32 PORT_SENDING { get; set; } = 60100;
        [Category("SETTINGS")]
        public UInt32 PORT_RECEIVING { get; set; } = 60101;
        #endregion

    }
}
