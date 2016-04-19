using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Storage
    {
        static DateTime _startTime = DateTime.Now;

        /// <summary>
        /// List of synthesis (by sensorType, by minute)
        /// </summary>
        private ConcurrentDictionary<int, ConcurrentDictionary<int, Synthesis>> _lstSynthesis = new ConcurrentDictionary<int, ConcurrentDictionary<int, Synthesis>>();

        public void RetrieveStoredMessages()
        {
            //TODO : read disk and reload messages and synthesis
        }

        public void StoreMessage(string id, string timestamp, int sensorType, int value)
        {
            DateTime dt = DateTime.Parse(timestamp);
            int deltaMinutes = (int)(dt - _startTime).TotalMinutes;
            ConcurrentDictionary<int, Synthesis> sensor;
            if (_lstSynthesis.ContainsKey(sensorType))
            {
                _lstSynthesis[sensorType] = new ConcurrentDictionary<int, Synthesis>();
            }
            sensor = _lstSynthesis[sensorType];

            Synthesis sy;
            if (!sensor.ContainsKey(deltaMinutes))
            {
                sy = new Synthesis();
            }
            else
            {
                sy = sensor[deltaMinutes];
            }
            sy.AddValue(value);

        }

        public string GetSynthesis()
        {
            // TODO
            return string.Empty;
        }        
    }
}
