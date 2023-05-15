using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.Threading;
using DUR.RTBLOGGER;

namespace DUR.SOCKETS
{
    public class MSOCKET
    {
        #region vairables
        public IPAddress _IP_SEND { get; private set; }
        public IPAddress _IP_RECEIVE { get; private set; }
        public Int32 _PORT_SEND { get; private set; }
        public Int32 _PORT_RECEIVE { get; private set; }

        public MrtbLogger _LOGGER = new MrtbLogger();

        private TcpListener SocketReceiver = null;
        private Socket SocketSender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private IPEndPoint SocketEnpoint;

        private BackgroundWorker worker = new BackgroundWorker();
        private BackgroundWorker workerSending = new BackgroundWorker();

        // Buffer for reading data
        private Byte[] bytes = new Byte[1024];
        private String data = null;

        private List<string> DataToSend = new List<string>();
        #endregion

        public void init(string IP_SEND, string IP_RECEIVE, Int32 PORT_SEND = 0, Int32 PORT_RECEIVE = 0, MrtbLogger LOGGER = null)
        {
            //check if server is not running
            if(!worker.IsBusy)
            {
                _IP_RECEIVE     = IPAddress.Parse(IP_RECEIVE);
                _IP_SEND        = IPAddress.Parse(IP_SEND);
                _PORT_SEND      = PORT_SEND;
                _PORT_RECEIVE   = PORT_SEND;

                try
                {
                    if (LOGGER != null)
                    {
                        _LOGGER = LOGGER;
                    }

                    if (PORT_RECEIVE != 0)
                    {
                        SocketReceiver = new TcpListener(_IP_RECEIVE, PORT_RECEIVE);
                    }

                    if (PORT_SEND != 0)
                    {
                        SocketEnpoint = new IPEndPoint(_IP_SEND, _PORT_SEND) ;
                    }
                    _LOGGER.Pass("Init socket server");
                }
                catch(Exception e)
                {
                    _LOGGER.Error("SOCKET | Init Error: " + e.ToString()) ;
                }
            }
            else
            {
                _LOGGER.Error("SOCKET | Server is running, pleas stop first");
                Thread.Sleep(1000);
            }
        }
        public void start()
        {
            if(worker.IsBusy != true)
            { 
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += Worker_Receiving; 
                worker.RunWorkerAsync();

                workerSending.WorkerSupportsCancellation = true;
                workerSending.DoWork += WorkerSending_DoWork;
                workerSending.RunWorkerAsync();
                _LOGGER.Pass("socket server started");
            }
        }
        public void stop()
        {
            if(worker.IsBusy)
            {
                worker.CancelAsync();
                workerSending.CancelAsync();
                _LOGGER.Pass("socket server stopped");
            }
        }
        private void Worker_Receiving(object sender, DoWorkEventArgs e)
        {
            // Start listening for client requests.
            SocketReceiver.Start();
            
            while (!worker.CancellationPending)
            {

                // Perform a blocking call to accept requests.
                // You could also use server.AcceptSocket() here.
                TcpClient client = SocketReceiver.AcceptTcpClient();
                _LOGGER.Info("accept_connection ");
                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                data = null;
                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                    _LOGGER.Info("SOCKET | recieved data from: " + _IP_RECEIVE.ToString() + " " + data);
                    SocketReceived(data);

                    //send response
                    //byte[] msg = Encoding.ASCII.GetBytes("ACK");
                    //stream.Write(msg, 0, msg.Length);
                }
            }
            SocketReceiver.Stop();
        }
        private void WorkerSending_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if (workerSending.CancellationPending)
                {
                    break;
                }

                if(DataToSend.Count != 0)
                {
                    try
                    {
                        _LOGGER.Info("SOCKET | sending: " + DataToSend[0]);
                        SocketSender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        byte[] msg = Encoding.ASCII.GetBytes(DataToSend[0]);
                        SocketSender.Connect(SocketEnpoint);
                        SocketSender.Send(msg);
                        SocketSender.Disconnect(false);
                        DataToSend.RemoveAt(0);
                    }
                    catch(Exception ex)
                    {
                        _LOGGER.Error("SOCKET | sending error: " + ex.ToString());
                    }
                }
                Thread.Sleep(100);
            }
        }
        public void sendString(string data)
        {
            DataToSend.Add(data);
        }

        public bool IsRunning 
        {
            get
            {
                return worker.IsBusy;
            }
        }

        #region OnSocketReceived event      

        public delegate void SockedReceivedEventHandler(string data);

        public event SockedReceivedEventHandler SocketReceived;
        
        protected virtual void OnSocketReceived(string data)
        {
            SocketReceived?.Invoke(data);
        }
        #endregion

        #region PropertyToSend event
        /// <summary>
        /// this event is for receiving data
        /// </summary>
        public void PropertyToSend(object sender, PropertyChangedEventArgs e)
        {
            if(sender.GetType().GetProperty(e.PropertyName).GetValue(sender, null).ToString() == "False")
            {
                DataToSend.Add('{' + e.PropertyName.ToString() + "," + "false" + ',' + sender.GetType().GetProperty(e.PropertyName).PropertyType.Name + '}');
            }
            else
            {
                DataToSend.Add('{' + e.PropertyName.ToString() + "," + sender.GetType().GetProperty(e.PropertyName).GetValue(sender, null).ToString() + ',' + sender.GetType().GetProperty(e.PropertyName).PropertyType.Name + '}');

            }

        }
        #endregion
    }
}
