using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Synthesis
    {
        private int _nbValues = 0;
        private int _sumOfValues = 0;
        private object _syncObject = new object();

        public float MediumValue
        {
            get
            {
                return _sumOfValues / _nbValues;
            }
        }

        public int MinValue { get; private set; } = int.MaxValue;

        public int MaxValue { get; private set; } = int.MinValue;

        public void AddValue(int value)
        {
            lock (_syncObject)
            {
                _nbValues++;
                _sumOfValues += value;
                if (value < this.MinValue) this.MinValue = value;
                if (value > this.MaxValue) this.MaxValue = value;
            }
        }

    }
}
