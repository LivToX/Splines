using MatrizenBibliothek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splines
{
    public static class PunkteRechner
    {
        public static List<Punkt> BerechneZuZeichnendePunkte(Punkt[] punkte, Matrix koeffizienten)
        {
            List<Punkt> zuZeichnen = new List<Punkt>();

            for (int i = 0; i < punkte.Length - 1; i++)    //gehe durch Anzahl von Splines
                for (double d = punkte[i].x; d < punkte[i + 1].x; d += 0.01) //Gehe durch Stellen von i < i+1   => zwischen x=n und x=n+1 liegen 100 Pixel
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
