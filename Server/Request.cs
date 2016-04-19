using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Request
    {
        private string _request;

        public Request(byte[] buffer, int nbBytes)
        {
            _request = ASCIIEncoding.ASCII.GetString(buffer, 0, nbBytes);
        }

        public bool IsMessage
        {
            get
            {
                return !_request.Contains("/synthesis");
            }
        }

        public bool IsSynthesis
        {
            get
            {
                return _request.Contains("/synthesis");
            }
        }

        public void ReadData(out string id, out string timestamp, out int sensorType, out int value)
        {
            int idxAcc = _request.IndexOf(": \"");
            int idx = _request.IndexOf("\"", idxAcc + 3);

            if (idx < 0)
            {
                id = string.Empty;
                timestamp = string.Empty;
                sensorType = 0;
                value = 0;
                return;
            }

            // Id
            id = _request.Substring(idxAcc + 3, idx - idxAcc - 3);

            // timestamp
            idxAcc = _request.IndexOf(": \"", idxAcc + 3);
            idx = _request.IndexOf("\"", idxAcc + 3);
            timestamp = _request.Substring(idxAcc + 3, idx - idxAcc - 3);

            // sensorType
            idxAcc = _request.IndexOf(": ", idxAcc + 3);
            idx = _request.IndexOf(" ", idxAcc + 3);
            sensorType = int.Parse(_request.Substring(idxAcc + 2, idx - idxAcc - 3));

            // value
            idxAcc = _request.IndexOf(": ", idxAcc + 3);
            idx = _request.IndexOf("}", idxAcc + 3);
            value = int.Parse(_request.Substring(idxAcc + 2, idx - idxAcc - 2));

        }
    }
}
