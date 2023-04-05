using System;

namespace IksaTeslim
{
    class KmOfset
    {
        public static Double Km;
        public static Double Ofset;

        public static void kmOfsetgetir(Double ykoor, Double xkoor)
        {
            Double baslangicY = 583196.858d;
            Double baslangicX = 4317987.992d;
            Double bitisY = 582716.358d;
            Double bitisX = 4317628.660d;
            Double alfa = Math.Atan((bitisY - baslangicY) / (bitisX - baslangicX)) + Math.PI;

            Double deltaY = ykoor - baslangicY;
            Double deltaX = xkoor - baslangicX;

            Km = 115100 + (deltaY * Math.Sin(alfa)) + (deltaX * Math.Cos(alfa));

            Ofset = (deltaY * Math.Cos(alfa)) - (deltaX * Math.Sin(alfa));

        }


    }
}
