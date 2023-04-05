using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IksaTeslim
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void dosyaAc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosyaYolu = new OpenFileDialog();
            dosyaYolu.ShowDialog();
            string dosyaAdi = dosyaYolu.FileName;
            textDosya.Text = dosyaAdi;
        }

        private void ciz_Click(object sender, EventArgs e)
        {

            string kmstr = textIksakm.Text;
            string[] kmdizi = kmstr.Split(new char[] { '+' });
            double km = Convert.ToInt32(kmdizi[0]) * 1000 + Convert.ToDouble(kmdizi[1]);

            
            string ruk = RayUstKotu.RayUstu(km).ToString("0.###");
            string iksaNo = textIksano.Text;
            string klas = "";
            string tarih = textTarih.Text;

            string isim = "";
            Point3d mzx = new Point3d(0.000, RayUstKotu.RayUstu(km), 0.00);
            string blokisim = "";
            double yaricap;
            
            Teslimat teslimat = new Teslimat();
            if (c2Kemerli.Checked == true)
            {
                blokisim = "C2_KEMERLI";
                teslimat.InsertBlock(mzx, blokisim);
                isim = "C2 TABAN KEMERLI";
                klas = "C2 ÜST YARI";
                yaricap = 6.81;
            }
            else if (b3Kemersiz.Checked == true)
            {
                blokisim = "B3_KEMERSIZ";
                teslimat.InsertBlock(mzx, blokisim);
                isim = "B3 TABAN KEMERSIZ";
                klas = "B3 ÜST YARI";
                yaricap = 6.76;
            }
            else
            {
                blokisim = "B3_KEMERLI";
                teslimat.InsertBlock(mzx, blokisim);
                isim = "B3 TABAN KEMERLI";
                klas = "B3 ÜST YARI";
                yaricap = 6.76;
            }

            Point3d mzx2 = new Point3d(mzx.X-8.748, mzx.Y-9.992, 0.00);
            blokisim = "SABLON";
            teslimat.InsertBlock(mzx2, blokisim);

            teslimat.BilgiKutusu(mzx,isim,kmstr,ruk,iksaNo,klas,tarih);

            int dizisay = 0;
            dizisay = SatirSayisi.satirSay(textDosya.Text);
            string line;

            Nokta[] okunan = new Nokta[dizisay];

            StreamReader sr = new StreamReader(textDosya.Text);

            int j = 0;
            line = sr.ReadLine();
            while (line != null)
            {
                string[] bol = line.Split(' ');
                okunan[j] = new Nokta();
                okunan[j].nno = Convert.ToInt32(bol[0]);
                
                okunan[j].ykoor = Convert.ToDouble(bol[1]);
                
                okunan[j].xkoor = Convert.ToDouble(bol[2]);
                
                okunan[j].zkoor = Convert.ToDouble(bol[3]);

                line = sr.ReadLine();
                j++;
            }
            sr.Close();

            KmOf[] kmofsetdizi = new KmOf[dizisay];
         
            for (int i = 0; i < dizisay; i++)
            {
                KmOfset.kmOfsetgetir(okunan[i].ykoor, okunan[i].xkoor);
                kmofsetdizi[i] = new KmOf();
                kmofsetdizi[i].nno_ok = okunan[i].nno;
                kmofsetdizi[i].Km_ok = KmOfset.Km;
                kmofsetdizi[i].Ofs_ok = KmOfset.Ofset;
                kmofsetdizi[i].Kot_ok = okunan[i].zkoor;
            }

            double dyug = 8.874;
            for (int i = 0; i < dizisay; i++)
            {
                CembereDikinme.cembereDik(yaricap, km, okunan[i].zkoor, okunan[i].ykoor, okunan[i].xkoor);
                ProjeKoord.projeKoordgetir(kmofsetdizi[i].Km_ok, CembereDikinme.cemberY, CembereDikinme.cemberX);
                teslimat.KoordinatYaz(kmofsetdizi[i].nno_ok, ProjeKoord.projeY, ProjeKoord.projeX, ProjeKoord.projeZ, 13.333, RayUstKotu.RayUstu(km) + dyug);
                dyug -= 0.498;
            }


            Sıralama sırala = new Sıralama();
            sırala.Sırala(kmofsetdizi, okunan);
            teslimat.EkranaRoleveCiz(kmofsetdizi,dizisay,yaricap);

            for (int i = 0; i < dizisay; i++)
            {
                CembereDikinme.cembereDik(yaricap,km,okunan[i].zkoor,okunan[i].ykoor,okunan[i].xkoor);
                teslimat.FarkCiz(CembereDikinme.cemberY,CembereDikinme.cemberX,kmofsetdizi[i].Ofs_ok, kmofsetdizi[i].Kot_ok,CembereDikinme.Uzunluk,kmofsetdizi[i].nno_ok);
            }

            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
