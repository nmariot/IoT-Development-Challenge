using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Storage
    {
        static readonly DateTime _startTime = DateTime.Now;

        static readonly string _path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "data");

        /// <summary>
        /// List of synthesis (by sensorType, by minute)
        /// </summary>
        private Dictionary<int, Dictionary<int, Synthesis>> _lstSynthesis = new Dictionary<int, Dictionary<int, Synthesis>>();

        /// <summary>
        /// List of writers
        /// </summary>
        private Dictionary<int, StreamWriter> _lstWriters = new Dictionary<int, StreamWriter>();

        public void Init()
        {
            Log.Debug("Storage.Init");
            
            // Create folders and remove old files
            Directory.CreateDirectory(_path);

            foreach (string dataFile in Directory.GetFiles(_path))
            {
                string dateFileName = Path.GetFileName(dataFile);
                DateTime dt = new DateTime(_startTime.Year, _startTime.Month, _startTime.Day, int.Parse(dateFileName.Substring(0, 2)), int.Parse(dateFileName.Substring(3, 2)), 0);
                if ((_startTime - dt).TotalMinutes > 60)
                {
                    Log.Debug("Suppression du fichier " + dateFileName);
                    File.Delete(dataFile);
                }
            }

            //TODO : read disk and reload messages and synthesis
        }

        public void StoreMessage(string id, string timestamp, int sensorType, int value)
        {
            DateTime dt = DateTime.Parse(timestamp);
            int deltaMinutes = (int)(dt - _startTime).TotalMinutes;

            // Storing message in file (one file per minute)
            string dataFileName = Path.Combine(_path, dt.Hour.ToString() + dt.Minute.ToString());
            //TODO : add lock
            if (!_lstWriters.ContainsKey(sensorType))
            {
                _lstWriters[sensorType] = new StreamWriter(new FileStream(dataFileName, FileMode.Append));
            }
            _lstWriters[sensorType].WriteLine($"{id};{timestamp};{sensorType};{value}");

            // Storing synthesis in memory
            Dictionary<int, Synthesis> sensor;
            if (!_lstSynthesis.ContainsKey(sensorType))
            {
                _lstSynthesis[sensorType] = new Dictionary<int, Synthesis>();
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

        /// <summary>
        /// Return the synthesis already serialized
        /// </summary>
        /// <returns></returns>
        public string GetSynthesis()
        {
            // TODO
            return string.Empty;
        }        
    }
}
