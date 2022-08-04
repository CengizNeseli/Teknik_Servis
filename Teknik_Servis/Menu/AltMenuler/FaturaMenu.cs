using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu;                                               //==> Projem altında Menu Klasörünü kullanmak için referans alıyorum.
using Teknik_Servis.Menu.Methodlar;                                     //==> Projem altında Methodlar Klasörünü kullanmak için referans alıyorum.

namespace Teknik_Servis
{
    public class FaturaMenu
    {
        public static void FaturaIslem()
        {
            AnaSayfa.EkranTemizle();
            Console.WriteLine("[1] - FATURA BILGILERINI LISTELE");
            Console.WriteLine("------------------");
            Console.WriteLine("[2] - FATURA EKLE");
            Console.WriteLine("---------------");
            Console.WriteLine("[3] - FATURA DUZENLE");
            Console.WriteLine("------------------");
            Console.WriteLine("[4] - FATURA SIL");

            Console.Write("\nYapılacak işlemi seçiniz = ");
            var musteriIslemSec = Console.ReadLine();                              //Yapılması istenilen işlemi girmesi için musteriIslemSec adında bir değişken değeri bekliyorum.

            switch (musteriIslemSec)                                               //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
            {
                case "1":
                    FtraIslemMethods.FaturaListele();
                    break;
                case "2":
                    FtraIslemMethods.FaturaEkle();
                    break;
                case "3":
                    FtraIslemMethods.FaturaGuncelle();
                    break;
                case "4":
                    FtraIslemMethods.FaturaSil();
                    break;
                case "5":
                    AnaSayfa.Cikis();
                    break;
                default:
                    Console.WriteLine("Yanlis bir tuslama gerçekleştirdiniz.");
                    break;
            }
        }
        public static void FaturaBilgiOlustur()
        {
            Random rnd = new Random();                                                          //==> Method altında oluşturacağım yeni nesnelerime random tarih değeri vermek için kullandim.
            FtraIslemMethods.ftraIslems = new List<FtraIslemMethods>();                         //==>FtraIslemMethods classımdaki referans aldığım ftraIslems isimli yeni bir liste oluşturuyorum.
            FtraIslemMethods.ftraIslems.Add(new FtraIslemMethods                                //==>FtraIslemMethods classımdaki referans aldığım ftraIslems listeme yazdığım property değerlerini ekliyorum.
            {
                
                Miktar = 5,
                Aciklama = "Anakart Tamiri",
                Tarih = DateTime.Now.AddDays(rnd.Next(-30,-1)),
                AdSoyad = "Demet Şahin",
                Telefon = "05310951206",
                BirimFiyati = 25,
                Tutar = 125

            }) ;
            FtraIslemMethods.ftraIslems.Add(new FtraIslemMethods
            {

                Miktar = 2,
                Aciklama = "Ram Değişimi",
                Tarih = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                AdSoyad = "Yusuf Pehlivan",
                Telefon = "05362478912",
                BirimFiyati = 300,
                Tutar = 600

            });
            FtraIslemMethods.ftraIslems.Add(new FtraIslemMethods
            {

                Miktar = 2,
                Aciklama = "Format Update",
                Tarih = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                AdSoyad = "Mert ATA",
                Telefon = "05450612493",
                BirimFiyati = 50,
                Tutar = 100

            });
            FtraIslemMethods.ftraIslems.Add(new FtraIslemMethods
            {

                Miktar = 1,
                Aciklama = "Laptop Bakım",
                Tarih = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                AdSoyad = "Merve Yalçın",
                Telefon = "05550147236",
                BirimFiyati = 200,
                Tutar = 200

            });
            FtraIslemMethods.ftraIslems.Add(new FtraIslemMethods
            {

                Miktar = 10,
                Aciklama = "Toner Dolum",
                Tarih = DateTime.Now.AddDays(rnd.Next(-30, -1)),
                AdSoyad = "Dursun Kaya",
                Telefon = "05310951206",
                BirimFiyati = 50,
                Tutar = 500

            });


        }
    }
}
