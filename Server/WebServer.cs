// https://github.com/ltoinel/IoT-Development-Challenge 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class WebServer
    {
        private const int NB_MAX_CONNECTIONS = 100;
        private static readonly IPEndPoint _endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 90);
        private Socket _socket;
        private Storage _storage = new Storage();

        public void Listen()
        {
            Log.Debug("WebServer.Listen");

            // Initialise Storage + re-read synthesis / data
            _storage.Init();

            // Init
            _socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(_endPoint);
            _socket.Listen(NB_MAX_CONNECTIONS);

            // Accept connections
            _socket.BeginAccept(AcceptCallBack, _socket);
        }

        private void AcceptCallBack(IAsyncResult cb)
        {
            // Reaccept connections
            _socket.BeginAccept(AcceptCallBack, _socket);

            var s = cb.AsyncState as Socket;
            var s2 = s.EndAccept(cb);

            // Receive data
            byte[] buffer = new byte[1024];
            int nbBytes = s2.Receive(buffer);
            var req = new Request(buffer, nbBytes);

            if (req.IsMessage)
            {
                string id, timestamp;
                int sensorType, value;
                req.ReadData(out id, out timestamp, out sensorType, out value);

                _storage.StoreMessage(id, timestamp, sensorType, value);

                // Send HTTP 200
                s2.Send(ASCIIEncoding.ASCII.GetBytes("HTTP/1.1 200 OK\n\rContent-Length: 0"));
            }
            else
            {
                string synthesis = _storage.GetSynthesis();

                // Send HTTP 200
                s2.Send(ASCIIEncoding.ASCII.GetBytes($"HTTP/1.1 200 OK\n\rContent-Length: {synthesis.Length}\n\r{synthesis}"));
            }

        }
    }
}
