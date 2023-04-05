using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IksaTeslim
{
    public class Teslimat
    {
        [CommandMethod("iksateslimat")]
        public static void Demo()
        {
            AnaForm mf = new AnaForm();
            mf.Show();

        }
        ///////Blok Ekle////////////////
        internal void InsertBlock(Point3d insPt, string blockName)
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            using (DocumentLock acLckDoc = doc.LockDocument())
            {
                using (var tr = db.TransactionManager.StartTransaction())
                {
                    // check if the block table already has the 'blockName'" block
                    var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                    if (!bt.Has(blockName))
                    {
                        try
                        {
                            // search for a dwg file named 'blockName' in AutoCAD search paths
                            var filename = HostApplicationServices.Current.FindFile(blockName + ".dwg", db, FindFileHint.Default);
                            // add the dwg model space as 'blockName' block definition in the current database block table
                            using (var sourceDb = new Database(false, true))
                            {
                                sourceDb.ReadDwgFile(filename, FileOpenMode.OpenForReadAndAllShare, true, "");
                                db.Insert(blockName, sourceDb, true);
                            }
                        }
                        catch
                        {
                            ed.WriteMessage($"\n'{blockName}' isimli blok bulunamadı.");
                            return;
                        }
                    }

                    // create a new block reference
                    using (var br = new BlockReference(insPt, bt[blockName]))
                    {
                        var space = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);
                        space.AppendEntity(br);
                        tr.AddNewlyCreatedDBObject(br, true);
                    }
                    tr.Commit();
                }
            }
        }
        ////////Blok Ekle Sonu///////////////////////////////////////////
        /////////////////////////////////////////////////////////////////
        ////////Bilgi Kutusu Baslangıcı//////////////////////////////////
        internal void BilgiKutusu(Point3d rukmerkez,string isim, string km, string ruk, string iksaNo, string klas, string tarih)
        //internal void BilgiKutusu(Point3d rukmerkez)
        {

            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            using (DocumentLock acLckDoc = doc.LockDocument())
            {
                using (var tr = db.TransactionManager.StartTransaction())
                {
                    BlockTable bt;
                    bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;


                    double dx = 1.828, dy = 3.656;
                    if (isim== "B3 TABAN KEMERSIZ")
                    {
                        dx = 1.845;
                        dy = 2.712; //Ray üst kotu merkezinden, yerleştirelecek kutunun ofset miktarları
                    }
                    else
                    {
                        dx = 1.828;
                        dy = 3.656;
                    }
                    
                    Point2d uygulamanokta = new Point2d(rukmerkez.X - dx, rukmerkez.Y - dy);

                    Polyline pl = new Polyline();
                    pl.AddVertexAt(0, uygulamanokta, 0, 0, 0);
                    pl.AddVertexAt(1, new Point2d(uygulamanokta.X + 3.965, uygulamanokta.Y), 0, 0, 0);
                    pl.AddVertexAt(2, new Point2d(uygulamanokta.X + 3.965, uygulamanokta.Y - 2.949), 0, 0, 0);
                    pl.AddVertexAt(3, new Point2d(uygulamanokta.X, uygulamanokta.Y - 2.949), 0, 0, 0);

                    pl.Closed=true;
                    pl.SetDatabaseDefaults();
                    btr.AppendEntity(pl);
                    tr.AddNewlyCreatedDBObject(pl, true);

                    TextStyleTable newTextStyleTable = tr.GetObject(doc.Database.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;

                    DBText acText1 = new DBText();
                    acText1.SetDatabaseDefaults();

                    acText1.Position = new Point3d(uygulamanokta.X + 0.530, uygulamanokta.Y-0.394, 0);
                    acText1.Height = 0.2;
                    acText1.TextString = isim;
                    acText1.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText1);
                    tr.AddNewlyCreatedDBObject(acText1, true);

                    DBText acText2 = new DBText();
                    acText2.SetDatabaseDefaults();
                    acText2.Position = new Point3d(uygulamanokta.X + 0.592, uygulamanokta.Y - 0.855, 0);
                    acText2.Height = 0.2;
                    acText2.TextString = "KM = "+ km ;
                    acText2.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText2);
                    tr.AddNewlyCreatedDBObject(acText2, true);

                    DBText acText3 = new DBText();
                    acText3.SetDatabaseDefaults();
                    acText3.Position = new Point3d(uygulamanokta.X + 0.714, uygulamanokta.Y - 1.317, 0);
                    acText3.Height = 0.2;
                    acText3.TextString = "RÜK = " + ruk;
                    acText3.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText3);
                    tr.AddNewlyCreatedDBObject(acText3, true);

                    DBText acText4 = new DBText();
                    acText4.SetDatabaseDefaults();
                    acText4.Position = new Point3d(uygulamanokta.X + 0.890, uygulamanokta.Y - 1.740, 0);
                    acText4.Height = 0.2;
                    acText4.TextString = "IKSA NO = " + iksaNo;
                    acText4.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText4);
                    tr.AddNewlyCreatedDBObject(acText4, true);

                    DBText acText5 = new DBText();
                    acText5.SetDatabaseDefaults();
                    acText5.Position = new Point3d(uygulamanokta.X + 0.423, uygulamanokta.Y - 2.240, 0);
                    acText5.Height = 0.2;
                    acText5.TextString = "KLAS = " + klas;
                    acText5.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText5);
                    tr.AddNewlyCreatedDBObject(acText5, true);

                    DBText acText6 = new DBText();
                    acText6.SetDatabaseDefaults();
                    acText6.Position = new Point3d(uygulamanokta.X + 0.391, uygulamanokta.Y - 2.768, 0);
                    acText6.Height = 0.2;
                    acText6.TextString = "TARIH = " + tarih;
                    acText6.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText6);
                    tr.AddNewlyCreatedDBObject(acText6, true);

                    tr.Commit();
                }
            }


        }
        ////////Bilgi Kutusu Sonu//////////////////////////////////
        ///
         ////////Rölevenin Ekrana Cizimi//////////////////////////////////
        internal void EkranaRoleveCiz(KmOf[] dizi, int dizisayisi, double yaricap)
        {

            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            using (DocumentLock acLckDoc = doc.LockDocument())
            {
                using (var tr = db.TransactionManager.StartTransaction())
                {
                    BlockTable bt;
                    bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    Polyline pl = new Polyline();

                    for (int i = 0; i < dizisayisi; i++)
                    {
                        double bulge = 0.000;
                        
                        if (i==(dizisayisi-1))
                        {
                            bulge = 0.000;
                        }
                        else
                        {
                            bulge = Math.Tan((Math.Asin((Math.Sqrt(Math.Pow(dizi[i + 1].Ofs_ok - dizi[i].Ofs_ok, 2) + Math.Pow(dizi[i + 1].Kot_ok - dizi[i].Kot_ok, 2))) / (2.00 * yaricap))) / 2);

                        }

                        pl.AddVertexAt(i, new Point2d(dizi[i].Ofs_ok,dizi[i].Kot_ok),bulge,0,0);
                    }



                    //pl.Closed = true;
                    pl.Layer = "SAHA_OKUMASI";
                    pl.SetDatabaseDefaults();
                    btr.AppendEntity(pl);
                    tr.AddNewlyCreatedDBObject(pl, true);

                    
                    tr.Commit();
                }
            }


        }
        ////////Rölevenin Ekrana Ciziminin Sonu//////////////////////////////////
        ///
         ////////İksa ve Röleve Arasındaki Çizgilerin Çizilip Yazısının Ekrana Yazılması //////////////////////////////////
        internal void FarkCiz(double x1,double x2,double x3, double x4, double uzunluk, int nno)
        {

            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            using (DocumentLock acLckDoc = doc.LockDocument())
            {
                using (var tr = db.TransactionManager.StartTransaction())
                {
                    BlockTable bt;
                    bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    Point3d noktaBir = new Point3d(x1, x2, 0);
                    Point3d noktaIki = new Point3d(x3, x4, 0);
                    Line acLine = new Line(noktaBir,noktaIki);
                    acLine.Layer = "FARK";
                    acLine.SetDatabaseDefaults();

                    btr.AppendEntity(acLine);
                    tr.AddNewlyCreatedDBObject(acLine, true);

                    TextStyleTable newTextStyleTable = tr.GetObject(doc.Database.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;

                    

                    double dxfark = 0.20;
                    double dyfark = 0.20;
                    
                    

                    DBText acText1 = new DBText();
                    acText1.SetDatabaseDefaults();
                    acText1.Position = new Point3d(x3+dxfark , x4+dyfark , 0.00);
                    acText1.Height = 0.15;
                    acText1.TextString = (uzunluk*100.000).ToString("0.0")+ " cm." ;
                    acText1.Layer = "FARK";
                    acText1.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText1);
                    tr.AddNewlyCreatedDBObject(acText1, true);

                    DBText acText2 = new DBText();
                    acText2.SetDatabaseDefaults();
                    acText2.Position = new Point3d(x1 - dxfark, x2 - dyfark, 0.00);
                    acText2.Height = 0.15;
                    acText2.TextString = nno.ToString();
                    acText2.Layer = "FARK";
                    acText2.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText2);
                    tr.AddNewlyCreatedDBObject(acText2, true);


                    tr.Commit();
                }
            }


        }
        ////////İksa ve Röleve Arasındaki Çizgilerin Çizilip Yazısının Ekrana Yazılması Sonu//////////////////////////////////
        ///
         ////////Koordinatları Ekrana Yazılması //////////////////////////////////
        internal void KoordinatYaz(int nno, double ykordnt, double xkordnt, double zkordnt, double xUygulama, double yUygulama)
        {

            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            using (DocumentLock acLckDoc = doc.LockDocument())
            {
                using (var tr = db.TransactionManager.StartTransaction())
                {
                    BlockTable bt;
                    bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                   TextStyleTable newTextStyleTable = tr.GetObject(doc.Database.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;

                    DBText acText1 = new DBText();
                    acText1.SetDatabaseDefaults();
                    acText1.Position = new Point3d(xUygulama, yUygulama, 0.00);
                    acText1.Height = 0.2;
                    acText1.TextString = nno.ToString();
                    acText1.Layer = "YAZI";
                    acText1.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText1);
                    tr.AddNewlyCreatedDBObject(acText1, true);

                    DBText acText2 = new DBText();
                    acText2.SetDatabaseDefaults();
                    acText2.Position = new Point3d(xUygulama+1.040, yUygulama, 0.00);
                    acText2.Height = 0.2;
                    acText2.TextString = ykordnt.ToString("0.000");
                    acText2.Layer = "YAZI";
                    acText2.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText2);
                    tr.AddNewlyCreatedDBObject(acText2, true);

                    DBText acText3 = new DBText();
                    acText3.SetDatabaseDefaults();
                    acText3.Position = new Point3d(xUygulama + 3.201, yUygulama, 0.00);
                    acText3.Height = 0.2;
                    acText3.TextString = xkordnt.ToString("0.000");
                    acText3.Layer = "YAZI";
                    acText3.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText3);
                    tr.AddNewlyCreatedDBObject(acText3, true);

                    DBText acText4 = new DBText();
                    acText4.SetDatabaseDefaults();
                    acText4.Position = new Point3d(xUygulama + 5.566, yUygulama, 0.00);
                    acText4.Height = 0.2;
                    acText4.TextString = zkordnt.ToString("0.000");
                    acText4.Layer = "YAZI";
                    acText4.TextStyleId = newTextStyleTable["KMG-TXT-0025-25"];
                    btr.AppendEntity(acText4);
                    tr.AddNewlyCreatedDBObject(acText4, true);

                    
                    tr.Commit();
                }
            }


        }
        ////////Koordinatların Ekrana Yazılması Sonu//////////////////////////////////

    }
}
