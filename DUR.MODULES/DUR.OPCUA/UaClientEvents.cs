using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUR.OPCUA.EVENTS
{
    public class MiToSendEvents : EventArgs
    {
        public string name;
        public object value;
        public string type;
    }

    public delegate void MiToSendEventHandler(MiToSendEvents e);
}
