using Splines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darstellung
{
    public static class Controller
    {
        public static List<Punkt> punkte = new List<Punkt>();

        public static void AddPunkt(double x, double yAlt)
        {
            double y;
            y = KoordinatenRechner.KoordinatenUmrechnen(yAlt);

            Punkt p = new Punkt(x, y);

            punkte.Add(p);

            punkte = punkte.OrderBy(p => p.x).ToList();
        }

        public static List<Punkt> GetZuZeichendePunkte()
        {
            List<Punkt> punkteWelt = PunkteRechner.BerechneZuZeichnendePunkte(punkte, KoeffizientenRechner.BerechneKoeffizenten(punkte));
            foreach (Punkt p in punkteWelt)
            {
                p.y = KoordinatenRechner.KoordinatenUmrechnen(p.y);
            }

            return punkteWelt;
        }
    }
}
