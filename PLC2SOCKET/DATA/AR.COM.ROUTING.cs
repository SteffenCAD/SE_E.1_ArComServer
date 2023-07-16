using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DUR.OPCUA;
using DUR.SOCKETS;
using System.Net.Sockets;

namespace AR.COM.ROUTING
{
    public class OPCROUTING 
    {
        public UaClient _uaClient;
        public MSOCKET _socket;

        private List<SocketReceivedStruct> RecivedData = new List<SocketReceivedStruct>();

        #region dataStuctureStuff
        [Category("DataStructureSuff")]
        [Browsable(false)]
        public bool enablePropertyToSend { get; set; } = true;
        #endregion


        public OPCROUTING(UaClient uaClient, MSOCKET socket)
        {
            _uaClient   = uaClient;
            _socket     = socket;

            _uaClient.MiToSend      += this.OpcClient_MiToSend;
            _socket.SocketReceived  += this.SocketOpcReceived;
        }


        #region OPC connection
        public void OpcClient_MiToSend(DUR.OPCUA.EVENTS.MiToSendEvents e)
        {
            //build json string
            string sSend = '{' + e.name + ":" + e.value.ToString() + ':' + e.type + '}';

            //send string
            _socket.sendString(sSend);
        }

        public void OpcClient_MiToReceive()
        {
            while(RecivedData.Count != 0)
            {
                try
                {
                    object value = ChangeType(RecivedData[0].value, RecivedData[0].type);
                    _uaClient.Write(RecivedData[0].name, value);

                    RecivedData.RemoveAt(0);
                }
                catch { }
            }
        }

        #endregion


        #region Socket Connection
        public void SocketOpcReceived(string data)
        {
            //disable sending if data is received from node red
            this.enablePropertyToSend = false;
            data = data.Trim(new Char[] { ' ', '{', '}' });

            string[] vars = data.Split(',');

            foreach(string var in vars)
            {
                string[] parameters = var.Split(':');

                if (parameters.Length >= 3)
                {
                    SocketReceivedStruct recived = new SocketReceivedStruct();
                    recived.name    = parameters[0];
                    recived.value   = parameters[1];
                    recived.type    = parameters[2];

                    RecivedData.Add(recived);

                    Task.Run(() => OpcClient_MiToReceive());
                }
            }

            this.enablePropertyToSend = true;
        }
        #endregion



        /// <summary>
        /// Changes the value in the text box to the data type required for the write operation.
        /// </summary>
        /// <returns>A value with the correct type.</returns>
        private object ChangeType(string Input, string type)
        {
            object value = null;

            switch (type)
            {
                case "Boolean":
                    {
                        value = Boolean.Parse(Input);
                        //value = Convert.ToBoolean(Input);
                        break;
                    }

                case "SByte":
                    {
                        value = Convert.ToSByte(Input);
                        break;
                    }

                case "Byte":
                    {
                        value = Convert.ToByte(Input);
                        break;
                    }

                case "Int16":
                    {
                        value = Convert.ToInt16(Input);
                        break;
                    }

                case "UInt16":
                    {
                        value = Convert.ToUInt16(Input);
                        break;
                    }

                case "Int32":
                    {
                        value = Convert.ToInt32(Input);
                        break;
                    }

                case "UInt32":
                    {
                        value = Convert.ToUInt32(Input);
                        break;
                    }

                case "Int64":
                    {
                        value = Convert.ToInt64(Input);
                        break;
                    }

                case "UInt64":
                    {
                        value = Convert.ToUInt64(Input);
                        break;
                    }

                case "Float":
                    {
                        value = Convert.ToSingle(Input);
                        break;
                    }

                case "Double":
                    {
                        value = Convert.ToDouble(Input);
                        break;
                    }

                default:
                    {
                        value = Input;
                        break;
                    }
            }

            return value;
        }

    }

    public class SocketReceivedStruct
    {
        public string name;
        public string value;
        public string type;
    }

}
