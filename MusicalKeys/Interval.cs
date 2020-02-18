using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class Interval
    {
        public int Degree { get; private set; }
        public string Symbol { get; private set; }

        public Interval(int index, string symbol)
        {
            Degree = index;
            Symbol = symbol;
        }
    }
}
