using System.Collections.Generic;

namespace Music
{
    public abstract class Pattern
    {
        protected readonly int maxDegree = 12;
        protected Pitches tones = new Pitches();

        public string Name { get; private set; }
        public string Symbol { get; private set; }
        public string IdToken => HasSymbol ? Symbol : Name;
        public bool HasSymbol => !string.IsNullOrWhiteSpace(Symbol);

        public Pattern(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public Pattern(string name) => Name = name;

        public abstract List<Pitch> GetNotes(Pitch root);

        protected string safe(string s) => s ?? string.Empty;
    }
}
