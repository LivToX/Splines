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
        static List<Punkt> punkte;

        public static void AddPunkt(double x, double yAlt)
        {
            double y;
            y = KoordinatenRechner.KoordinatenUmrechnen(yAlt);

            Punkt p = new Punkt(x,y);
        }
    }
}
