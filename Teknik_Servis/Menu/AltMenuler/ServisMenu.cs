using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu;                                               //==> Projem altında Menu Klasörünü kullanmak için referans alıyorum.
using Teknik_Servis.Menu.Methodlar;                                     //==> Projem altında Methodlar Klasörünü kullanmak için referans alıyorum.

namespace Teknik_Servis
{
    public class ServisMenu 
    {

        public static void ServisIslem()
        {
            AnaSayfa.EkranTemizle(); 
            Console.WriteLine("[1] - SERVIS URUNLERINI LISTELE");
            Console.WriteLine("------------------");
            Console.WriteLine("[2] - SERVISE URUN EKLE");
            Console.WriteLine("---------------");
            Console.WriteLine("[3] - SERVIS URUN DUZENLE");
            Console.WriteLine("------------------");
            Console.WriteLine("[4] - SERVIS URUNLERI SIL");

            Console.Write("\nYapılacak işlemi seçiniz = ");

            var servisIslemSec = Console.ReadLine();                           //Yapılması istenilen işlemi girmesi için servisIslemSec adında bir değişken değeri bekliyorum.

            switch (servisIslemSec)                                            //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
            {
                case "1":
                    SrvIslmMethods.UrunListele();
                    break;
                case "2":
                    SrvIslmMethods.UrunEkle();
                    break;
                case "3":
                    SrvIslmMethods.UrunGuncelle();
                    break;
                case "4":
                    SrvIslmMethods.UrunSil();
                    break;
                case "5":
                    AnaSayfa.Cikis();
                    break;
                default:
                    Console.WriteLine("Yanlis bir tuşlama gerçekleştirdiniz.");
                    break;
            }



        }

        public static void ServisUrunOlustur()          
        {

            Random rnd = new Random();                                                          //==> Method altında oluşturacağım yeni nesnelerime random tarihi vermek için kullandim.                                                 
            SrvIslmMethods.srvIslList = new List<SrvIslmMethods>();                             //==>SrvIslmMethods classımdaki referans aldığım srvIslList isimli yeni bir liste oluşturuyorum.
            SrvIslmMethods.srvIslList.Add(new SrvIslmMethods                                    //==>SrvIslmMethods classımdaki referans aldığım srvIslList listeme yazdığım property değerlerini ekliyorum.
            {

                StockKodu = "U1000",
                TeslimAlmaTarihi = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                CihazTuru = "Notebook",
                Marka = "Asus",
                Model = "Vivobook",
                GarantisiVarMi = "Var",
                Sonuc = "Dış Servis"

            });
            SrvIslmMethods.srvIslList.Add(new SrvIslmMethods
            {
                StockKodu = "U1001",
                TeslimAlmaTarihi = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                CihazTuru = "Notebook",
                Marka = "Acer",
                Model = "x585",
                GarantisiVarMi = "Var",
                Sonuc = "Test Ediliyor"

            });
            SrvIslmMethods.srvIslList.Add(new SrvIslmMethods
            {
                StockKodu = "U1002",
                TeslimAlmaTarihi = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                CihazTuru = "Kartuş",
                Marka = "HP",
                Model = "C50",
                GarantisiVarMi = "Yok",
                Sonuc = "Dış Servis"

            });
            SrvIslmMethods.srvIslList.Add(new SrvIslmMethods
            {
                StockKodu = "U1003",
                TeslimAlmaTarihi = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                CihazTuru = "Toner",
                Marka = "Hp",
                Model = "16a",
                GarantisiVarMi = "Yok",
                Sonuc = "Onarıldı"

            });
            SrvIslmMethods.srvIslList.Add(new SrvIslmMethods
            {
                StockKodu = "U1004",
                TeslimAlmaTarihi = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                CihazTuru = "Masaustu",
                Marka = "Asus",
                Model = "Xhh",
                GarantisiVarMi = "Var",
                Sonuc = "Test Ediliyor"

            });


        }
        
    }



}

