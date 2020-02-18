using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Music
{
    public class Scales : Collection
    {
        public Scales(Pitch root, List<Pattern> patterns) : base(root, patterns)
        {
        }

        public override ToneSet Get(string name)
        {
            if (nameDictionary.TryGetValue(name, out ToneSet scale))
            {
            }
            else
            {
                throw new Exception($"{name} not found");
            }
            return scale;
        }

        protected override Dictionary<string, ToneSet> getNameDictionary()
        {
            var d = All.ToDictionary(s => s.Pattern.Name, c => c, StringComparer.OrdinalIgnoreCase);
            All.Where(s => s.Pattern.Name.EndsWith("scale", StringComparison.OrdinalIgnoreCase))
                .ToList()
                .ForEach(s => d.Add(Regex.Replace(s.Pattern.Name, @"\s*scale$", string.Empty, RegexOptions.IgnoreCase), s));
            ;
            return d;
        }
    }
}
