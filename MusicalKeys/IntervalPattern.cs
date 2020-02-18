using System.Collections.Generic;
using System.Linq;

namespace Music
{
    public class IntervalPattern : Pattern
    {
        private Intervals intervalMap = new Intervals();
        public List<Interval> Intervals { get; private set; }

        public IntervalPattern(string name, string symbol, string sequence) : base(name, symbol) =>
            Intervals = parseIntervals(sequence);

        public IntervalPattern(string name, string sequence) : base(name) =>
            Intervals = parseIntervals(sequence);

        public IntervalPattern(string name, string symbol, List<Interval> intervals) : base(name, symbol) =>
            Intervals = intervals;

        public IntervalPattern(string name, List<Interval> intervals) : base(name) =>
            Intervals = intervals;

        public override List<Pitch> GetNotes(Pitch root)
        {
            var notes = new List<Pitch>();
            Intervals.ForEach(i =>
            {
                var degree = (root.Degree + i.Degree) % maxDegree;
                notes.Add(tones.Get(degree));
            });
            return notes;
        }

        private List<Interval> parseIntervals(string s)
        {
            s = safe(s).StartsWith("P1") ? s : $"P1 {s}";
            var tokens = s.Split(' ');
            return tokens.Select(t => intervalMap.Get(t.ToString())).ToList();
        }
    }
}
