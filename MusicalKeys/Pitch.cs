using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class Pitch
    {
        public int Degree { get; private set; }
        public string Symbol { get; private set; }
        public string AltSymbol { get; private set; }

        public Pitch(int degree, string symbol)
        {
            Degree = degree;
            Symbol = symbol;
        }

        public Pitch(int degree, string symbol, string altSymbol) : this(degree, symbol) =>
            AltSymbol = altSymbol;

        public override string ToString() => Symbol;
    }
}
