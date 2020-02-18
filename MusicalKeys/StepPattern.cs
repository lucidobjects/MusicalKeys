using System.Collections.Generic;
using System.Linq;

namespace Music
{
    public class StepPattern : Pattern
    {
        private Steps stepMap = new Steps();

        public List<Step> Steps { get; private set; }

        public StepPattern(string name, string symbol, string s) : base(name, symbol) => Steps = parseSteps(s);
        public StepPattern(string name, string s) : base(name) => Steps = parseSteps(s);
        public StepPattern(string name, string symbol, List<Step> steps) : base(name, symbol) =>
            Steps = steps;

        public StepPattern(string name, List<Step> steps) : base(name) => Steps = steps;

        public override List<Pitch> GetNotes(Pitch Root)
        {
            var notes = new List<Pitch>();
            var noteIndex = Root.Degree;
            Steps.ForEach(i =>
            {
                noteIndex += i.Increment;
                var index = noteIndex % maxDegree;
                notes.Add(tones.Get(index));
            });
            return notes;
        }

        private List<Step> parseSteps(string s)
        {
            s = safe(s).StartsWith("1") ? s : $"1{s}";
            return s.ToList().Select(t => stepMap.Get(t.ToString())).ToList();
        }
    }
}
