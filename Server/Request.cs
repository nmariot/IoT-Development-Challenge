using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Request
    {
        private byte[] _buffer;
        private int _nbBytes;

        public Request(byte[] buffer, int nbBytes)
        {
            _buffer = buffer;
            _nbBytes = nbBytes;
        }

        public bool IsMessage
        {
            get
            {
                // TODO
                return false;
            }
        }

        public bool IsSynthesis
        {
            get
            {
                // TODO
                return false;
            }
        }

        public void ReadData(out string id, out string timestamp, out string sensorType, out string value)
        {
            // TODO : try to optimize (not use ASCIIEncoding and read directly the array)
            string requete = ASCIIEncoding.ASCII.GetString(_buffer, 0, _nbBytes);
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
            id = string.Empty;
            timestamp = string.Empty;
            sensorType = string.Empty;
            value = string.Empty;
        }
    }
}
