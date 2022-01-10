using Splines;
using System;
using System.Collections.Generic;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Punkt punkt1 = new Punkt(1, 3);
            Punkt punkt2 = new Punkt(2, 4);
            Punkt punkt3 = new Punkt(3, 1);
            Punkt punkt4 = new Punkt(4, 4);

            List<Punkt> punkte = new List<Punkt>();
            punkte.Add(punkt1);
            punkte.Add(punkt2);
            punkte.Add(punkt3);
            punkte.Add(punkt4);

            PunkteRechner.BerechneZuZeichnendePunkte(punkte,KoeffizientenRechner.BerechneKoeffizenten(punkte));


        }
    }
}
