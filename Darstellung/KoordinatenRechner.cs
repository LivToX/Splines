using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darstellung
{
    public static class KoordinatenRechner
    {
        public static double KoordinatenUmrechnen(double yAlt)
        {
            double yMax = 600;
            return yMax - yAlt;
        }

        
    }
}
