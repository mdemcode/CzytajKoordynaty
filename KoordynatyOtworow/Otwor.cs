using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoordynatyOtworow
{
    struct Otwor
    {
        public double Srednica;
        public double PozX;
        public double PozY;
        public double PozZ;

        public Otwor(double fi, double x, double y, double z) {
            Srednica = Math.Round(fi,1);
            PozX = Math.Round(x,1);
            PozY = Math.Round(y,1);
            PozZ = Math.Round(z,1);
        }
    }
}
