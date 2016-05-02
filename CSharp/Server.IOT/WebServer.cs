// https://github.com/ltoinel/IoT-Development-Challenge 

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static readonly IPEndPoint _endPoint = new IPEndPoint(IPAddress.Any, 90);
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

            AcceptConnections();
        }

        private void AcceptConnections()
        {
            // Accept connections
            var acceptCallback = new SocketAsyncEventArgs();
            acceptCallback.Completed += acceptCallback_Completed;
            var res = _socket.AcceptAsync(acceptCallback);
            if (!res)
            {
                acceptCallback_Completed(_socket, acceptCallback);
            }
        }

        private void acceptCallback_Completed(object sender, SocketAsyncEventArgs e)
        {
            AcceptConnections();

            // Receive            
            var receiveCallback = new SocketAsyncEventArgs();
            receiveCallback.SetBuffer(new byte[1024], 0, 1024);
            receiveCallback.Completed += receiveCallback_Completed;
            if (!e.AcceptSocket.ReceiveAsync(receiveCallback))
            {
                receiveCallback_Completed(e.AcceptSocket, receiveCallback);
            }
        }

        private void receiveCallback_Completed(object sender, SocketAsyncEventArgs e)
        {
            Debug.WriteLine(ASCIIEncoding.ASCII.GetString(e.Buffer, 0, e.BytesTransferred));

            // Send
            var sendCallBack = new SocketAsyncEventArgs();
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes("HTTP/1.1 200 OK\n\rContent-Length: 4\r\n\r\n1234");
            sendCallBack.SetBuffer(buffer, 0, buffer.Length);
            (sender as Socket).SendAsync(sendCallBack);
            // No need for a callback

            return;

            var req = new Request(e.Buffer, e.BytesTransferred);

            if (req.IsMessage)
            {
                string id, timestamp;
                int sensorType, value;
                req.ReadData(out id, out timestamp, out sensorType, out value);

                _storage.StoreMessage(id, timestamp, sensorType, value);

                // Send HTTP 200
                SendData(e.AcceptSocket, ASCIIEncoding.ASCII.GetBytes("HTTP/1.1 200 OK\n\rContent-Length: 0"));
            }
            else
            {
                string synthesis = _storage.GetSynthesis();

                // Send HTTP 200
                SendData(e.AcceptSocket, ASCIIEncoding.ASCII.GetBytes($"HTTP/1.1 200 OK\n\rContent-Length: {synthesis.Length}\n\r{synthesis}"));
            }

        }

        private void SendData(Socket s2, byte[] buffer)
        {
            var sendArg = new SocketAsyncEventArgs();
            sendArg.SetBuffer(buffer, 0, buffer.Length);
            s2.SendAsync(sendArg);
        }

    }
}
