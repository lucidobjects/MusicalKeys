using System.Collections.Generic;
using System.Text;

namespace Music
{
    public class Key
    {
        public Pitch Root { get; private set; }

        public Scales Scales { get; private set; }
        public Chords Chords { get; private set; }

        public Key(Pitch root, List<Pattern> scalePatterns, List<Pattern> chordPatterns)
        {
            Root = root;
            Scales = new Scales(Root, scalePatterns);
            Chords = new Chords(Root, chordPatterns);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Key of {Root.ToString()}");
            sb.AppendLine("\tScales");
            sb.AppendLine(Scales.ToStringTerse(1));
            sb.AppendLine("\tChords");
            sb.AppendLine(Chords.ToStringTerse(1));
            return sb.ToString();
        }
    }
}
