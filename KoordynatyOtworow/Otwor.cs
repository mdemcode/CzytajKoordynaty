using System;

namespace KoordynatyOtworow
{
    struct Otwor
    {
        public double Srednica { get; set; }
        public double PozX { get; set; }
        public double PozY { get; set; }
        public double PozZ { get; set; }

        public Otwor(double fi, double x, double y, double z) {
            Srednica = Zaokr.Zaokr_05(fi); //Math.Round(fi,1);
            PozX = Zaokr.Zaokr_05(x);   //Math.Round(x,1);
            PozY = Zaokr.Zaokr_05(y);   //Math.Round(y,1);
            PozZ = Zaokr.Zaokr_05(z);   //Math.Round(z,1);
        }
    }
}
