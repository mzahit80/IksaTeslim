using System.IO;

namespace IksaTeslim
{

    class SatirSayisi
    {
        public static int satirSay(string dosyaadi)
        {
            int satirsayisi = 0;
            string satir;
            StreamReader srsatir = new StreamReader(dosyaadi);
            satir = srsatir.ReadLine();
            while (satir != null)
            {

                satir = srsatir.ReadLine();
                satirsayisi++;
            }
            srsatir.Close();
            return satirsayisi;
        }
    }

}
