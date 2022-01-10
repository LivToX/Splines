using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splines
{
    public class Punkt
    {
        public double x  { get; set; }

        public double y { get; set; }

        public Punkt()
        {
            x = 0;
            y = 0;
        }

        public Punkt(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
    }
}
