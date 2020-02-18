using System;
using System.Collections.Generic;
using System.Linq;

namespace Music
{
    public class App
    {        
        public void Run()
        {
            var steps = new Steps();
            var scalePatterns = getScalePatterns(steps).Select(p => p as Pattern).ToList();
            var intervals = new Intervals();
            var chordPatterns = getChordPatterns(intervals).Select(p=> p as Pattern).ToList();
            var tones = new Pitches();

            ///define the Key of A and output individual elements from it
            var keyOfA = new Key(tones.A, scalePatterns, chordPatterns);
            Console.WriteLine(keyOfA.Scales.Get("Major").ToString());
            Console.WriteLine(keyOfA.Scales.Get("Natural Minor").ToString());
            Console.WriteLine(keyOfA.Scales.Get("Melodic Minor").ToString());
            Console.WriteLine(keyOfA.Chords.Get("M").ToString());
            Console.WriteLine(keyOfA.Chords.Get("M7").ToString());
            Console.WriteLine(keyOfA.Chords.Get("7").ToString());
            Console.WriteLine(keyOfA.Chords.Get("m7").ToString());
            Console.WriteLine(keyOfA.Chords.Get("m7b5").ToString());
            Console.WriteLine(keyOfA.Chords.Get("dim7").ToString());
            Console.WriteLine();

            ///shortened syntax to define the Key of F# and output all of its scales and chords
            Console.WriteLine(new Key(tones.Fsharp, scalePatterns, chordPatterns).ToString());

            ///define and print a single scale
            var scalePattern = new StepPattern("Major Scale", "WWHWWWH");
            var scale = new ToneSet(tones.Dsharp, scalePattern);
            Console.WriteLine(scale.ToString());

            ///define and print a single chord
            var chordPattern = new IntervalPattern("Major 7th", "M7", "P1 M3 P5 M7");
            var chord = new ToneSet(tones.C, chordPattern);
            Console.WriteLine(chord.ToString());

            ///define and print another single chord
            var chordPattern2 = new IntervalPattern("Dominant Seventh", "7", "P1 M3 P5 m7");
            var chord2 = new ToneSet(tones.G, chordPattern2);
            Console.WriteLine(chord2.ToString());
        }

        private List<IntervalPattern> getChordPatterns(Intervals intervals) => 
            new List<IntervalPattern>
            {
                ///string-based construction
                new IntervalPattern("Major Triad", "M", "P1 M3 P5"),
                new IntervalPattern("Minor Triad", "m", "P1 m3 P5"),
                new IntervalPattern("Major Seventh", "M7", "P1 M3 P5 M7"),
                new IntervalPattern("Dominant Seventh", "7", "P1 M3 P5 m7"),
                new IntervalPattern("Minor Seventh", "m7", "P1 m3 P5 m7"),
                new IntervalPattern("Minor 7 Flat 5", "m7b5", "P1 m3 dim5 m7"),
                
                ///list-based construction
                new IntervalPattern("Diminished Seventh", "dim7",
                    new List<Interval>
                    {
                        intervals.Unison,
                        intervals.Minor3rd,
                        intervals.Diminished5th,
                        intervals.Diminished7th
                    })
            };

        private List<StepPattern> getScalePatterns(Steps steps) => 
            new List<StepPattern>
            {
                ///string-based construction
                new StepPattern("Major Scale", "WWHWWWH"),
                new StepPattern("Melodic Minor Scale", "WHWWWWH"),
                
                ///list-based construction
                new StepPattern("Natural Minor Scale",
                        new List<Step>
                        {
                            steps.Unison,
                            steps.WholeStep,
                            steps.HalfStep,
                            steps.WholeStep,
                            steps.WholeStep,
                            steps.HalfStep,
                            steps.WholeStep,
                            steps.WholeStep,
                        }),
            };
    }
}