using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu.Methodlar;  //=> Methodlar Klasörünü Referans Olarak Kullanıyorum. Böylelikle ordaki classtan methodlarımı çağırabilirim.

namespace Teknik_Servis.Menu
{
    public class AnaSayfa
    {   
        
        public static void EkranTemizle() 
        {
            Console.Clear();    //==> Console Ekran Temizleme Parametre
            Header();           //==> Başlık Çağrıyorum
            
        }
        public static void Header()
        {
            Console.WriteLine("TEKNİK PERSONEL PROGRAMI");
            Console.WriteLine("------------------------");
        }

        public static void Menu()
        {
            EkranTemizle();
            Console.WriteLine("[1] - ANASAYFA");
            Console.WriteLine("--------------");
            Console.WriteLine("[2] - SERVİS İŞLEMLERİ");
            Console.WriteLine("----------------------");
            Console.WriteLine("[3] - FATURA İŞLEMLERİ");
            Console.WriteLine("----------------------");
            Console.WriteLine("[4] - MÜŞTERİ YÖNETİMİ");
            Console.WriteLine("----------------------");
            Console.WriteLine("[5] - PERSONEL YÖNETİMİ");
            Console.WriteLine("----------------------");
            Console.WriteLine("[6] - RAPOR İŞLEMLERİ");
            Console.WriteLine("---------------------");
            Console.WriteLine("[7] - ÇIKIŞ");
            Console.WriteLine("-----------");

            Console.Write("Lütfen yapılacak işlemi seçin = "); //==> Yapılacak Islemi Sectiriyorum.
            var menuIslem = Console.ReadLine();

            switch (menuIslem)                                 //==>Switch altındaki menuIslem kodu ile tüm key değerleri
                                                               //Menu Klasoru altından referans ile class içinden çağrıyorum.
            {
                case "1":
                    Anasayfa();
                    
                    break;
                case "2":
                    ServisMenu.ServisIslem();
                    break;
                case "3":
                    FaturaMenu.FaturaIslem();
                    break;
                case "4":
                    MusteriMenu.MusteriIslem();
                    break;
                case "5":
                    PersonelMenu.PersonelYonetim();
                    break;
                case "6":
                    RaporMenu.RaporIslem();
                    break;
                case "7":
                    Cikis();
                    break;
                default:
                    Console.WriteLine("Yanlis bir tuslama yaptiniz.");
                    break;
            }
        }

        public static void Anasayfa()
        {
            SrvIslmMethods.UrunListele();
            //RaporIslmMethods.TeslimEtme();

        }

        public static void MenuyeDon()                                          //==> Islem Bittiginde Menuye Geri Gitmesi için Method Yazdim.
        {
            Console.Write("\nMenüye dönmek için bir tuşa basın");
            Console.ReadKey();
            Menu();
        }

        public static void Cikis()                                              //Uygulamadan Cikis Methodum.
        {
            Environment.Exit(0);
        }
    }
}
