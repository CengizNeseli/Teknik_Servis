using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu;                                             //==> Projem altında Menu Klasörünü kullanmak için referans alıyorum.
using Teknik_Servis.Menu.Methodlar;                                   //==> Projem altında Methodlar Klasörünü kullanmak için referans alıyorum

namespace Teknik_Servis
{
    public class RaporMenu
    {
        public static void RaporIslem()
        {
            
            AnaSayfa.EkranTemizle();
            Console.WriteLine("[1] - TESLİM ALINAN RAPOR LISTELESİ");
            Console.WriteLine("------------------");
            Console.WriteLine("[2] - TESLİM EDİLEN RAPOR LISTELESİ");
            Console.WriteLine("---------------");

            Console.Write("Yapılacak Işlemi Seciniz = ");

            var raporIslemSec = Console.ReadLine();                 //Yapılması istenilen işlemi girmesi için raporIslemSec adında bir değişken değeri bekliyorum.

            switch (raporIslemSec)                                  //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
            {

                case "1":
                    RaporIslmMethods.TeslimAlma();
                    break;
                case "2":
                    RaporIslmMethods.TeslimEtme();
                    break;
                default:
                    break;
            }


        }

        public static void TeslimAlmaIstatigiOlustur()
        {

            RaporIslmMethods.TeslimAlanList = new List<RaporIslmMethods>();                 //==>RaporIslmMethods classımdaki referans aldığım TeslimAlanList isimli yeni bir liste oluşturuyorum.
            RaporIslmMethods.TeslimAlanList.Add(new RaporIslmMethods                        //==>RaporIslmMethods classımdaki referans aldığım TeslimAlanList listeme yazdığım property değerlerini ekliyorum.
            {
                KontrolEdilecek = 5,
                ParcaSiparis = 2,
                GarantiyeGonderim = 1,
                BakimYapilacak = 4

            });

            RaporIslmMethods.TeslimAlanList.Add(new RaporIslmMethods
            {
                KontrolEdilecek = 3,
                ParcaSiparis = 7,
                GarantiyeGonderim = 9,
                BakimYapilacak = 4

            });
        }

        public static void TeslimEtmeIstatigiOlustur()
        {
            RaporIslmMethods.TeslimEdenList = new List<RaporIslmMethods>();                 //==>RaporIslmMethods classımdaki referans aldığım TeslimEdenList isimli yeni bir liste oluşturuyorum.
            RaporIslmMethods.TeslimEdenList.Add(new RaporIslmMethods                        //==>RaporIslmMethods classımdaki referans aldığım TeslimEdenList listeme yazdığım property değerlerini ekliyorum
            {
                OnarılmisOlan = 5,
                GeriIade = 2,
                TeslimEdilen = 6,
                DisServis = 4,
                Onarılamayan = 0
            });
            RaporIslmMethods.TeslimEdenList.Add(new RaporIslmMethods
            {
                OnarılmisOlan = 5,
                GeriIade = 2,
                TeslimEdilen = 1,
                DisServis = 4,
                Onarılamayan = 8
            });
        }
    }
}
