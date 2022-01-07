using MatrizenBibliothek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splines
{
    public static class KoeffizientenRechner
    {
        public static Matrix BerechneKoeffizenten(List<Punkt> sortiertePunkte)
        {
            Matrix koeffizienten = new Matrix(sortiertePunkte.Count, 4);
            Matrix koeffizientenMatrix = new Matrix(sortiertePunkte.Count - 2, sortiertePunkte.Count - 1, 0);   //erstelle Nullmatrix mit entsprechenden Dimensionen

            for (int i = 0; i < koeffizienten.heigth; i++)  //Setzte erstes und letztes b auf 0
            {
                //berechne b
                if (i == 0 || i == koeffizienten.heigth - 1) //wenn erster oder letzter Spline bi= 0
                    koeffizienten.setWert(i, 1, 0);
            }

            //erstelle Lgs                  
            for (int k = 0; k < sortiertePunkte.Count - 2; k++) //erstelle linke Seite
            {
                koeffizientenMatrix.setWert(k, k, 2 * (sortiertePunkte[k + 2].x - sortiertePunkte[k].x));
                if (k != sortiertePunkte.Count - 3)//nur solange nicht unten rechts, rechts und unterhalb machen (siehe Matrix aus script)
                {
                    koeffizientenMatrix.setWert(k, k + 1, sortiertePunkte[k + 2].x - sortiertePunkte[k + 1].x);
                    koeffizientenMatrix.setWert(k + 1, k, sortiertePunkte[k + 2].x - sortiertePunkte[k + 1].x);
                }
            }

            for (int l = 0; l < koeffizientenMatrix.heigth; l++) //erstelle rechte Seite
            {
                koeffizientenMatrix.setWert(l, sortiertePunkte.Count - 2, 3 * ((sortiertePunkte[l + 2].y - sortiertePunkte[l + 1].y) / (sortiertePunkte[l + 2].x - sortiertePunkte[l + 1].x)
                    - ((sortiertePunkte[l + 1].y - sortiertePunkte[l].y) / (sortiertePunkte[l + 1].x - sortiertePunkte[l].x))));
            }

            //loese LGs
            koeffizientenMatrix = MatrizenBibliothek.Operations.LgsLoesen(koeffizientenMatrix);

            for (int m = 0; m < koeffizientenMatrix.heigth; m++)    //schreibe b's auf koeffizienten über
            {
                koeffizienten.setWert(m + 1, 1, koeffizientenMatrix.getWert(m, sortiertePunkte.Count - 2));
            }

            for (int j = 0; j < koeffizienten.heigth - 1; j++)
            {
                //berechne a
                koeffizienten.setWert(j, 0, (koeffizienten.getWert(j + 1, 1) - koeffizienten.getWert(j, 1)) / (3 * (sortiertePunkte[j + 1].x - sortiertePunkte[j].x)));

                //berechne c
                double ersterBruch = (sortiertePunkte[j + 1].y - sortiertePunkte[j].y) / (sortiertePunkte[j + 1].x - sortiertePunkte[j].x);
                double zweiterBruch = ((koeffizienten.getWert(j + 1, 1) - koeffizienten.getWert(j, 1)) * (sortiertePunkte[j + 1].x - sortiertePunkte[j].x)) / 3;
                double dritterFaktor = koeffizienten.getWert(j, 1) * (sortiertePunkte[j + 1].x - sortiertePunkte[j].x);

                koeffizienten.setWert(j, 2, ersterBruch - zweiterBruch - dritterFaktor);

                //"berechne" d
                koeffizienten.setWert(j, 3, sortiertePunkte[j].y);


            }

            return koeffizienten;
        }
    }
}
