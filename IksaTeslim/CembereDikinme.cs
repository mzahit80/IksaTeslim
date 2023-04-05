using System;

namespace IksaTeslim
{
    class CembereDikinme
    {
        public static Double cemberY;
        public static Double cemberX;
        public static Double Uzunluk;

        public static void cembereDik(double Yaricap,Double km, Double KOT, Double Y1, Double X1)
        {
            
            Double merkezKoorY = 0.00d;
            Double merkezKoorX = RayUstKotu.RayUstu(km) + 1.75;
            
            KmOfset.kmOfsetgetir(Y1, X1);
            Double Smesafe = Math.Sqrt(Math.Pow((KmOfset.Ofset - merkezKoorY), 2.0) + Math.Pow((KOT - merkezKoorX), 2));
            
            Double oKatsayisi = (KmOfset.Ofset - merkezKoorY) / Smesafe;
            
            Double aKatsayisi = (KOT - merkezKoorX) / Smesafe;
            
            Uzunluk = Smesafe - Yaricap;
            cemberY = merkezKoorY + (oKatsayisi * Yaricap);
            cemberX = merkezKoorX + (aKatsayisi * Yaricap);
           
        }
    }
}
