using System;
using System.Collections.Generic;
using System.Linq;

namespace Music
{

    public class Pitches
    {
        private Dictionary<int, Pitch> dictionary;

        public List<Pitch> All { get; private set; }
        public Pitch A => Get(0);
        public Pitch Asharp => Get(1);
        public Pitch B => Get(2);
        public Pitch C => Get(3);
        public Pitch Csharp => Get(4);
        public Pitch D => Get(5);
        public Pitch Dsharp => Get(6);
        public Pitch E => Get(7);
        public Pitch F => Get(8);
        public Pitch Fsharp => Get(9);
        public Pitch G => Get(10);
        public Pitch Gsharp => Get(11);

        public Pitches()
        {
            All = new List<Pitch>
            {
                new Pitch(0,"A"),
                new Pitch(1, "A#", "Bb"),
                new Pitch(2, "B"),
                new Pitch(3, "C"),
                new Pitch(4, "C#","Db"),
                new Pitch(5, "D"),
                new Pitch(6, "D#", "Eb"),
                new Pitch(7, "E"),
                new Pitch(8, "F"),
                new Pitch(9, "F#", "Gb"),
                new Pitch(10, "G"),
                new Pitch(11, "G#", "Ab"),
            };
            dictionary = All.ToDictionary(t => t.Degree, t => t);
        }

        public Pitch Get(int degree)
        {
            if (dictionary.TryGetValue(degree, out Pitch tone))
            {
                return tone;
            }
            else
            {
                throw new Exception($"Tone degree {degree} not found");
            }
        }
    }
}
