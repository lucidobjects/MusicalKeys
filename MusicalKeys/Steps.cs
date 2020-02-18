using System;
using System.Collections.Generic;
using System.Linq;

namespace Music
{
    public class Steps
    {
        private Dictionary<string, Step> dictionary;

        public Step Unison { get; private set; }
        public Step WholeStep { get; private set; }
        public Step HalfStep { get; private set; }
        public List<Step> All { get; private set; } = new List<Step>();
        public Steps()
        {
            Unison = new Step(0, "1");
            HalfStep = new Step(1, "H");
            WholeStep = new Step(2, "W");
            All.Add(Unison);
            All.Add(HalfStep);
            All.Add(WholeStep);
            dictionary = All.ToDictionary(s => s.Symbol, s => s, StringComparer.OrdinalIgnoreCase);
        }

        public Step Get(string symbol)
        {
            if (dictionary.TryGetValue(symbol, out Step step))
            {
                return step;
            }
            else
            {
                throw new Exception($"{symbol} not found");
            }
        }
    }
}
