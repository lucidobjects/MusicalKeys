using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class Step
    {
        public int Increment { get; private set; }
        public string Symbol { get; private set; }

        public Step(int increment, string symbol)
        {
            Increment = increment;
            Symbol = symbol;
        }
    }
}
