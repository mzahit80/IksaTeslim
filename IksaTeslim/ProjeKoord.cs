using System;

namespace IksaTeslim
{
    class ProjeKoord
    {
        public static Double projeY;
        public static Double projeX;
        public static Double projeZ;

        public static void projeKoordgetir(Double _km, Double _ofset, Double _kot)

        {
            Double baslangicY = 583196.858d;
            Double baslangicX = 4317987.992d;
            Double bitisY = 582716.358d;
            Double bitisX = 4317628.660d;
            Double _Smesafe = Math.Sqrt(Math.Pow((bitisY - baslangicY), 2.0) + Math.Pow((bitisX - baslangicX), 2));
            Double _oKatsayisi = (bitisY - baslangicY) / _Smesafe;
            Double _aKatsayisi = (bitisX - baslangicX) / _Smesafe;
            Double _Sc = _km - 115100.00;
            Double _hOfset = _ofset;
            projeY = baslangicY + (_oKatsayisi * _Sc) + (_aKatsayisi * _hOfset);
            projeX = baslangicX + (_aKatsayisi * _Sc) - (_oKatsayisi * _hOfset);
            projeZ = _kot;

        }
    }
}
