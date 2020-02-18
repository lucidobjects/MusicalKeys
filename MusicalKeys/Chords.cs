using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public class Chords : Collection
    {
        private Dictionary<string, ToneSet> _symbolDictionary;
        private Dictionary<string, ToneSet> symbolDictionary => _symbolDictionary ?? (_symbolDictionary = getSymbolDictionary());

        public Chords(Pitch root, List<Pattern> patterns) :base(root, patterns)
        {
        }

        public override ToneSet Get(string id)
        {
            if (nameDictionary.TryGetValue(id, out ToneSet chord))
            {
            }
            else if (symbolDictionary.TryGetValue(id, out chord))
            {
            }
            else
            {
                throw new Exception($"{id} not found");
            }
            return chord;
        }

        protected override Dictionary<string, ToneSet> getNameDictionary() =>
            All.ToDictionary(c => c.Pattern.Name, c => c, StringComparer.OrdinalIgnoreCase);

        private Dictionary<string, ToneSet> getSymbolDictionary() =>
            All.ToDictionary(c => c.Pattern.Symbol, c => c);
    }
}
