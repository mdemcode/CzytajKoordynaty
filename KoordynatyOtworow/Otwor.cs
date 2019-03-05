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
            PozX = Math.Round(x);
            PozY = Math.Round(y);
            PozZ = Math.Round(z);
        }
    }
}
