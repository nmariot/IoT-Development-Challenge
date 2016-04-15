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

        public void Listen()
        {
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

            // read data  : message or synthesis
            //string id, timestamp, sensorType, value;
            //ReadData(buffer, nbBytes, out id, out timestamp, out sensorType, out value);
            //Log.Debug($"id = {id}, timestamp = {timestamp}, sensorType = {sensorType}, value = {value}");

            // Persist data


            // Send HTTP 200
            s2.Send(ASCIIEncoding.ASCII.GetBytes("HTTP/1.1 200 OK\n\rContent-Length: 0"));

        }

        private void ReadData(byte[] buffer, int nbBytes, out string id, out string timestamp, out string sensorType, out string value)
        {
            // TODO : try to optimize (not usie ASCIIEncoding and read directly the array
            string requete = ASCIIEncoding.ASCII.GetString(buffer, 0, nbBytes);
            int idxAcc = requete.IndexOf(": \"");
            int idx = requete.IndexOf("\"", idxAcc + 3);

            // Id
            id = requete.Substring(idxAcc + 3, idx - idxAcc - 3);

            // timestamp
            idxAcc = requete.IndexOf(": \"", idxAcc + 3);
            idx = requete.IndexOf("\"", idxAcc + 3);
            timestamp = requete.Substring(idxAcc + 3, idx - idxAcc - 3);

            // sensorType
            idxAcc = requete.IndexOf(": ", idxAcc + 3);
            idx = requete.IndexOf(" ", idxAcc + 3);
            sensorType = requete.Substring(idxAcc + 2, idx - idxAcc - 3);

            // value
            idxAcc = requete.IndexOf(": ", idxAcc + 3);
            idx = requete.IndexOf("}", idxAcc + 3);
            value = requete.Substring(idxAcc + 2, idx - idxAcc - 2);
        }
    }
}
