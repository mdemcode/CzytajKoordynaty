using System;

namespace KoordynatyOtworow
{
    struct Otwor
    {
        public short Nr { get; }
        public double Srednica { get; }
        public double PozX { get; }
        public double PozY { get; }
        public double PozZ { get; }

        public Otwor(short nr, double fi, double x, double y, double z) {
            Nr = nr;
            Srednica = Zaokr.Zaokr_05(fi); 
            PozX = Zaokr.Zaokr_05(x);   
            PozY = Zaokr.Zaokr_05(y);   
            PozZ = Zaokr.Zaokr_05(z);   
        }
    }
}
