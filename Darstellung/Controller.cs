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


            if (punkte.Count > 1) // 2 oder mehr
            {
                for (int i = 0; i < punkte.Count; i++)
                {
                    if (p.x < punkte[i].x)
                    {
                        punkte.Insert(i, p);
                        break;
                    }
                }
            }
            else if (punkte.Count > 0)
            {
                if (punkte[0].x < p.x)
                    punkte.Add(p);
                else
                    punkte.Insert(0, p);
            }
            else
                punkte.Add(p);
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
