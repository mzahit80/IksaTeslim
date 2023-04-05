using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IksaTeslim
{
    public class Sıralama
    {
        
        public void Sırala(KmOf[] dizi, Nokta[] dizioku)
        {
            for (int i = 0; i < dizi.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < dizi.Length; j++)
                {
                    if (dizi[min].Ofs_ok < dizi[j].Ofs_ok)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    var lowerValue = dizi[min];
                    var lowerValueoku = dizioku[min];
                    dizi[min] = dizi[i];
                    dizioku[min] = dizioku[i];
                    dizi[i] = lowerValue;
                    dizioku[i] = lowerValueoku;
                }
            }
        }
    }
}
