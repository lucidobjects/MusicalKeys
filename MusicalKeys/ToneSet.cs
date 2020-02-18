using System.Collections.Generic;
using System.Linq;

namespace Music
{
    public class ToneSet
    {
        public Pitch Root { get; private set; }
        public Pattern Pattern { get; protected set; }
        public string Name => $"{Root.Symbol} {Pattern.Name}";
        public string Id => getId();

        protected List<Pitch> notes;
        public List<Pitch> Notes => notes ?? (notes = Pattern.GetNotes(Root));

        public ToneSet(Pitch root, Pattern pattern)
        {
            Root = root;
            Pattern = pattern;
        }

        public override string ToString() => $"{Id}:  {string.Join(" ", Notes.Select(t => t.Symbol))}";
        public string ToStringTerse() => $"{Pattern.IdToken}:  {string.Join(" ", Notes.Select(t => t.Symbol))}";

        private string getId()
        {
            var separator = Pattern.HasSymbol ? string.Empty : " ";
            return $"{Root.Symbol}{separator}{Pattern.IdToken}";
        }
    }
}