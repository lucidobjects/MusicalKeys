using System;
using System.Collections.Generic;
using System.Linq;

namespace Music
{
    public class Intervals
    {
        private Dictionary<string, Interval> dictionary;
        public Interval Unison { get; private set; }
        public Interval Minor2nd { get; private set; }
        public Interval Major2nd { get; private set; }
        public Interval Minor3rd { get; private set; }
        public Interval Major3rd { get; private set; }
        public Interval Perfect4th { get; private set; }
        public Interval Diminished5th { get; private set; }
        public Interval Perfect5th { get; private set; }
        public Interval Minor6th { get; private set; }
        public Interval Major6th { get; private set; }
        public Interval Diminished7th { get; private set; }
        public Interval Minor7th { get; private set; }
        public Interval Major7th { get; private set; }
        public Interval Octave { get; private set; }
        public List<Interval> All { get; private set; } = new List<Interval>();

        public Intervals()
        {
            Unison = new Interval(0, "P1");
            Minor2nd = new Interval(1, "m2");
            Major2nd = new Interval(2, "M2");
            Minor3rd = new Interval(3, "m3");
            Major3rd = new Interval(4, "M3");
            Perfect4th = new Interval(5, "P4");
            Diminished5th = new Interval(6, "dim5");
            Perfect5th = new Interval(7, "P5");
            Minor6th = new Interval(8, "m6");
            Major6th = new Interval(9, "M6");
            Diminished7th = new Interval(9, "dim7");
            Minor7th = new Interval(10, "m7");
            Major7th = new Interval(11, "M7");
            Octave = new Interval(12, "P8");
            All.Add(Unison);
            All.Add(Minor2nd);
            All.Add(Major2nd);
            All.Add(Minor3rd);
            All.Add(Major3rd);
            All.Add(Perfect4th);
            All.Add(Diminished5th);
            All.Add(Perfect5th);
            All.Add(Minor6th);
            All.Add(Major6th);
            All.Add(Diminished7th);
            All.Add(Minor7th);
            All.Add(Major7th);
            All.Add(Octave);
            dictionary = All.ToDictionary(i => i.Symbol, i => i);
        }

        public Interval Get(string symbol)
        {
            if (dictionary.TryGetValue(symbol, out Interval interval))
            {
                return interval;
            }
            else
            {
                throw new Exception($"{symbol} not found");
            }
        }
    }
}