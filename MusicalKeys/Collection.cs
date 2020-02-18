using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    public abstract class Collection
    {
        protected Dictionary<string, ToneSet> _nameDictionary;
        protected Dictionary<string, ToneSet> nameDictionary => _nameDictionary ?? (_nameDictionary = getNameDictionary());

        public Pitch Root { get; protected set; }
        public List<ToneSet> All { get; protected set; }

        public Collection(Pitch root, List<Pattern> patterns)
        {
            Root = root;
            All = patterns.Select(p => new ToneSet(Root, p)).ToList();
        }

        public abstract ToneSet Get(string id);

        public string ToStringTerse(int indent)
        {
            var tabs = new string('\t', indent);
            var sb = new StringBuilder();
            All.ForEach(s => sb.AppendLine($"{tabs}{s.ToStringTerse()}"));
            return sb.ToString();
        }

        protected abstract Dictionary<string, ToneSet> getNameDictionary();        
    }
}
