using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu;                                               //==> Projem altında Menu Klasörünü kullanmak için referans alıyorum.
using Teknik_Servis.Menu.Methodlar;                                     //==> Projem altında Methodlar Klasörünü kullanmak için referans alıyorum.

namespace Teknik_Servis
{
    public class MusteriMenu
    {

        
        public static void MusteriIslem()
        {
            AnaSayfa.EkranTemizle();
            Console.WriteLine("[1] - MUSTERI BILGILERINI LISTELE");
            Console.WriteLine("------------------");
            Console.WriteLine("[2] - MUSTERI EKLE");
            Console.WriteLine("---------------");
            Console.WriteLine("[3] - MUSTERI DUZENLE");
            Console.WriteLine("------------------");
            Console.WriteLine("[4] - MUSTERI SIL");
            Console.Write("\nYapılacak işlemi seçiniz = ");
            var musteriIslemSec = Console.ReadLine();                                           //Yapılması istenilen işlemi girmesi için musteriIslemSec adında bir değişken değeri bekliyorum.

            switch (musteriIslemSec)                                                            //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
            {
                case "1":
                    MusteriYntmMethods.MusteriListele();
                    break;
                case "2":
                    MusteriYntmMethods.MusteriEkle();
                    break;
                case "3":
                    MusteriYntmMethods.MusteriGuncelle();
                    break;
                case "4":
                    MusteriYntmMethods.MusteriSil();
                    break;
                case "5":
                    AnaSayfa.Cikis();
                    break;
                default:
                    Console.WriteLine("Yanlis bir tuslama gerçekleştirdiniz.");
                    break;
            }



        }

        public static void MusteriBilgiOlustur()
        {
            MusteriYntmMethods.musteriYntms = new List<MusteriYntmMethods>();                   //==>MusteriYntmMethods classımdaki referans aldığım musteriYntms isimli yeni bir liste oluşturuyorum.
            MusteriYntmMethods.musteriYntms.Add(new MusteriYntmMethods                          //==>MusteriYntmMethods classımdaki referans aldığım musteriYntms listeme yazdığım property değerlerini ekliyorum.
            {

                AdSoyad = "Cengiz Neşeli",
                Telefon = "0620338205",
                Mail = "cengizneseli@gmail.com"


            });
            MusteriYntmMethods.musteriYntms.Add(new MusteriYntmMethods
            {
                AdSoyad = "Erhan Çelik",
                Telefon = "05419581242",
                Mail = "erhancelik@gmail.com"

            });
            MusteriYntmMethods.musteriYntms.Add(new MusteriYntmMethods
            {
                AdSoyad = "Sercan DINCKAL",
                Telefon = "05428510312",
                Mail = "sercandinckal@gmail.com"

            });
            MusteriYntmMethods.musteriYntms.Add(new MusteriYntmMethods
            {
                AdSoyad = "Seçkin GUR",
                Telefon = "05532584666",
                Mail = "seckingur@gmail.com"

            });
            MusteriYntmMethods.musteriYntms.Add(new MusteriYntmMethods
            {
                AdSoyad = "Salih ASADOV",
                Telefon = "05535012316",
                Mail = "salihasadov@gmail.com"

            });


        }



    }
}
