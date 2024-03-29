﻿using MatrizenBibliothek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splines
{
    public static class PunkteRechner
    {
        public static List<Punkt> BerechneZuZeichnendePunkte(List<Punkt> punkte, Matrix koeffizienten)
        {
            List<Punkt> zuZeichnen = new List<Punkt>();

            for (int i = 0; i < punkte.Count - 1; i++)  
                for (double d = punkte[i].x; d < punkte[i + 1].x; d += 0.5) 
                {
                    double x = d - punkte[i].x; //  = (x - xi)

                    Punkt p = new Punkt();
                    p.x = d;
                    p.y = koeffizienten.getWert(i, 0) * Math.Pow((x), 3) + koeffizienten.getWert(i, 1) * Math.Pow((x), 2) + koeffizienten.getWert(i, 2) * x + koeffizienten.getWert(i, 3); // brechene Punkt

                    zuZeichnen.Add(p);
                }



            return zuZeichnen;
        }
    }
}
