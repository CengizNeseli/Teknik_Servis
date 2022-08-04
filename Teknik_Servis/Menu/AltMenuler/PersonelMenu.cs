using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu;                                                //==> Projem altında Menu Klasörünü kullanmak için referans alıyorum.
using Teknik_Servis.Menu.Methodlar;                                      //==> Projem altında Methodlar Klasörünü kullanmak için referans alıyorum.

namespace Teknik_Servis
{
    public class PersonelMenu
    {
        public static void PersonelYonetim()
        {

            AnaSayfa.EkranTemizle();
            Console.WriteLine("[1] - PERSONEL BILGILERINI LISTELE");
            Console.WriteLine("------------------");
            Console.WriteLine("[2] - PERSONEL EKLE");
            Console.WriteLine("---------------");
            Console.WriteLine("[3] - PERSONEL DUZENLE");
            Console.WriteLine("------------------");
            Console.WriteLine("[4] - PERSONEL SIL");

            Console.Write("\nYapılacak işlemi seçiniz = ");
            var personelIslemSec = Console.ReadLine();                     //Yapılması istenilen işlemi girmesi için personelIslemSec adında bir değişken değeri bekliyorum.

            switch (personelIslemSec)                                       //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
            {
                case "1":
                    PrsnlYntmMethods.PersonelListele();
                    break;
                case "2":
                    PrsnlYntmMethods.PersonelEkle();
                    break;
                case "3":
                    PrsnlYntmMethods.PersonelGuncelle();
                    break;
                case "4":
                    PrsnlYntmMethods.PersonelSil();
                    break;
                case "5":
                    AnaSayfa.Cikis();
                    break;
                default:
                    Console.WriteLine("Yanlis bir tuşlama gerçekleştirdiniz.");
                    break;
            }



        }

        public static void PersonelBilgiOlustur()
        {

            PrsnlYntmMethods.prslYntms = new List<PrsnlYntmMethods>();                  //==>PrsnlYntmMethods classımdaki referans aldığım prslYntms isimli yeni bir liste oluşturuyorum.
            PrsnlYntmMethods.prslYntms.Add(new PrsnlYntmMethods                         //==>PrsnlYntmMethods classımdaki referans aldığım prslYntms listeme yazdığım property değerlerini ekliyorum.
            {
                TcNo = "94316310670",
                AdSoyad = "Hakan Çelik",
                DogumTarihi = "03.01.1992",
                Telefon = "05355124415",
                IseGirisTarihi = "25.01.2021",
                Durum = "Devam Ediyor"


            });
            PrsnlYntmMethods.prslYntms.Add(new PrsnlYntmMethods
            {
                TcNo = "39400060260",
                AdSoyad = "Selim Turker",
                DogumTarihi = "03.01.1982",
                Telefon = "05535761085",
                IseGirisTarihi = "25.07.2022",
                Durum = "Devam Ediyor"

            });
            PrsnlYntmMethods.prslYntms.Add(new PrsnlYntmMethods
            {
                TcNo = "39400060260",
                AdSoyad = "Hamit Akca",
                DogumTarihi = "03.01.1979",
                Telefon = "05417124690",
                IseGirisTarihi = "25.07.2022",
                Durum = "İşten Ayrıldı"

            });
            PrsnlYntmMethods.prslYntms.Add(new PrsnlYntmMethods
            {
                TcNo = "16445903158",
                AdSoyad = "Irmak Mayda",
                DogumTarihi = "03.01.1984",
                Telefon = "05375046197",
                IseGirisTarihi = "25.03.2022",
                Durum = "Devam Ediyor"

            });
            PrsnlYntmMethods.prslYntms.Add(new PrsnlYntmMethods
            {
                TcNo = "33803096024",
                AdSoyad = "Didem Kansu",
                DogumTarihi = "03.01.1997",
                Telefon = "05445912307",
                IseGirisTarihi = "25.07.2022",
                Durum = "İşten Ayrıldı"

            });


        }
    }
}
