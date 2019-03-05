using System;


namespace KoordynatyOtworow
{
    static class Zaokr
    {
        public static double Zaokr_05(double liczba) {
            switch (liczba - Math.Floor(liczba)) {
                case double a when a>0.0 && a<0.3:
                    return Math.Floor(liczba);
                case double a when a > 0.3 && a < 0.7:
                    return Math.Floor(liczba) + 0.5;
                case double a when a > 0.7 && a < 1:
                    return Math.Floor(liczba) + 1;
                default:
                    return liczba;
            }

        }
    }
}
