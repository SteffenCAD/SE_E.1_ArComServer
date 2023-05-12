using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUR.SOCKETS
{
    public class SocketRecivedArgs
    {
        public SocketRecivedArgs(string Data) { data = Data; }
        public string data { get; set; }
    }
}
