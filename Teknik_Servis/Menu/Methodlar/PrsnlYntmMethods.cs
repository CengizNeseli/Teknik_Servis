using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu.Properties;                                    //==>Teknik Servis Menu Projem altındaki Menu Klasörünün Altındaki Tanımladığım Propertylerimi Referans almak için buraya yazdım

namespace Teknik_Servis.Menu.Methodlar
{
    public class PrsnlYntmMethods : PrsnlYntmProperty                   //PrsnlYntmProperty altından da Property bilgilerini miras(Inheritance) aliyorum.
    {
        public static List<PrsnlYntmMethods> prslYntms;                  //==> BU classa prslYntms adında bir obje yaratiyorum ve cagiracagim methodlar için yaziyorum.

        public static void PersonelListele(string mesajP="", bool personelListele=false)        //==> PersonelListele Methoduma (Oluştururken bir başlık mesajı, Islem Bittiginde Geri Dönmemesi
        {                                                                                       //==> için bir false Değer atiyorum.
            AnaSayfa.EkranTemizle();

            Console.WriteLine("Personel Bilgileri ");
            Console.WriteLine("-------------------");

            if (!string.IsNullOrEmpty(mesajP))                                                   //Eger Cagrildigi yerde UrunListele içi bos veya null ise 
            {
                Console.WriteLine(mesajP);                                                        //(mesaj parametresi ="baslik" yazdiriyorum)
            }


            Console.WriteLine($"\nNo {"Tc No".PadRight(17)}{"Adı Soyadı".PadRight(17)}{"Doğum Tarihi".PadRight(22)}{"Telefon".PadRight(17)}{"Ise Giris Tarihi".PadRight(17)}{"Durum".PadRight(17)}");

                                                                                                  //PersonelListele Methodumdaki başlıklarımı yaziyorum


            var sayac = 1;                                                                       //Bir sayac degeri atiyorum ki listelenirken 1-2-3-4-5 seklinde gitsin                                           

            if (prslYntms == null)                                                                //prslYntms isimli liste içeriğim null(içinde bir her hangi bir değer parametre vs. var mı) mu diye kontrol ettiriyorum
            {
                PersonelMenu.PersonelBilgiOlustur();                                            //Eger bos ise PersonelMenu Classı altındaki PersonelBilgiOlustur Methodumu cagirarak içindekileri yazdiriyorum
            }


            foreach (var personel in prslYntms)
            {
                Console.WriteLine($"{sayac} - {personel.TcNo.PadRight(16)}{personel.AdSoyad.PadRight(16)}{personel.DogumTarihi.PadRight(22)}{personel.Telefon.PadRight(17)}{personel.IseGirisTarihi.PadRight(16)}{personel.Durum.PadRight(16)}");
                sayac++;
            }

                                                                                                //Son olarak prslYntms listemdeki personel isminde bir item atayarak
                                                                                                //içeriğinde gezdiriyorum ve ekrana bu değerlerin karşılığını yazdırıyorum.

            if (!personelListele)
            {
                AnaSayfa.MenuyeDon();                                                           //Islem Bitince Menuye Donmesini Sagliyorum.
            }
        }

        public static void PersonelEkle()                                                       
        {
            AnaSayfa.EkranTemizle();
            PersonelListele("\n Personel Bilgisi Ekleme - Personel Listesi", true);              //PersonelListele Methodu çağrıyorum ve Personel Bilgisi Ekleme başlık mesajını veriyorum.
            Console.WriteLine("--------------------");


            Console.Write("\n Tc No giriniz = ");                                               
            var yeniPersonel = new PrsnlYntmMethods();                                          //==> PrsnlYntmMethods Class ı altında yeniPersonel adında bir nesne,obje oluşturuyorum.
            yeniPersonel.TcNo = Console.ReadLine();
            var yeniPersonelA = prslYntms.FirstOrDefault(f => f.TcNo == yeniPersonel.TcNo);     //==>Konsoldan girilen TcNo ile prslYntms isimli listemdeki TcNo Kıyasliyorum. Eğer yok ise ekliyor

            Console.Write("İsim ve soyisim giriniz = ");
            yeniPersonel.AdSoyad = Console.ReadLine();

            Console.Write("Dogum tarihi giriniz = ");                                           // ve ardından geri kalan diğer tüm nitelikler (AdSoyad-Telefon vs)
            yeniPersonel.DogumTarihi = Console.ReadLine();

            Console.Write("Telefon numarası giriniz = ");
            yeniPersonel.Telefon = Console.ReadLine();                                           //Personel bilgilerine girmeye başladığım için listede ki obje özelliklerine değerler girildikçe eklenmeye devam ediyor   

            Console.Write("Ise giris tarihi giriniz = ");               
            yeniPersonel.IseGirisTarihi = Console.ReadLine();

            Console.Write("Durum bilgisini giriniz = ");
            yeniPersonel.Durum = Console.ReadLine();

            prslYntms.Add(yeniPersonel);                                                        //==>Islem Sonunda oluşturmuş olduğum yeniPersonel nesne,objemi PrsnlYntmMethods classındaki listeme ekliyorum.

            PersonelListele($"{yeniPersonelA.AdSoyad} kaydı başarıyla gerçekleştirildi. ");     //Islem sonunda bilgi mesajı veriyorum.
        }

        public static void PersonelGuncelle()
        {
            AnaSayfa.EkranTemizle();
            PersonelListele("\nPersonel Bilgisi Güncelleme - Personel Listesi", true);               //Personel Listesini Getirip Üzerinde Değişiklikler Yapmak için Methodu Çağrıyorum.

            Console.WriteLine("------------------------------");

            Console.WriteLine("\n[1] - Tc No Değişikliği");
            Console.WriteLine("[2] - Ad Soyad Değişikliği");
            Console.WriteLine("[3] - Dogum Tarihi Değişikliği");
            Console.WriteLine("[4] - Telefon No Değişikliği");
            Console.WriteLine("[5] - Ise Giris Tarihi Değişikliği");
            Console.WriteLine("[6] - Durum Değişikliği");
            Console.WriteLine("[7] - Çıkış");

            Console.WriteLine("\n------------------------------");

            Console.Write("\n Yapmak istediğiniz işlemi seciniz = ");
            var guncelPersonelIslem = Console.ReadLine();                                           // Yapılması istenilen işlemi girmesi için guncelIslemTuru adında bir değişken değeri bekliyorum. 



            switch (guncelPersonelIslem)                                                            //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
            {
                case "1":

                    PersonelListele("Personel Tc No Değişikliği ", true);                           //PersonelListele Methodu içerisine Personel Tc No Değişikliği başlığı ile Methodu çağrıyorum.
                    Console.WriteLine("\n------------------------");
                    Console.Write("\nHangi TcNo değiştirmek istiyorsunuz ? = ");
                    var personelTc = Console.ReadLine();
                    var personelT = prslYntms.FirstOrDefault(f => f.TcNo == personelTc);            //Console'dan girilen personelTc ile prslYntms isimli listemdeki
                    Console.Write("Değiştirelecek yeni TcNo giriniz = ");                       // personelTc kıyasliyorum doğru ise (referans değişkenler)
                    personelT.AdSoyad = Console.ReadLine();                                         // Listemdeki StockKodun üzerine yazdiriyorum.

                    PersonelListele($"{personelT.TcNo} ait güncelleme yapılmıştır.");               // Islem sonunda bilgi mesajı veriyorum. Diğer Switch keylerin hepsi de aynı mantıkta çalişiyor. 1-6
                    break;
                case "2":
                    PersonelListele("Personel Ad Soyad Değişikliği ", true);
                    Console.WriteLine("\n------------------------");
                    Console.Write("\nHangi İsmi değiştirmek istiyorsunuz ? = ");
                    var personelAdSoyad = Console.ReadLine();
                    var personelA = prslYntms.FirstOrDefault(f => f.AdSoyad == personelAdSoyad);
                    Console.Write("Değiştirelecek yeni ad soyad giriniz = ");
                    personelA.AdSoyad = Console.ReadLine();

                    PersonelListele($"{personelA.AdSoyad} ismine ait güncelleme yapılmıştır.");
                    break;
                case "3":
                    PersonelListele("Personel Doğum Tarihi Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nDoğum tarihini değiştirmek istediğiniz kişinin ismini yazınız = ");
                    var personelDogum = Console.ReadLine();
                    var personelDT = prslYntms.FirstOrDefault(f => f.AdSoyad == personelDogum);
                    Console.Write("Değiştirelecek yeni doğum tarihini giriniz = ");
                    personelDT.DogumTarihi = Console.ReadLine();

                    PersonelListele($"{personelDT.DogumTarihi} tarihine ait güncelleme yapılmıştır.");
                    break;
                case "4":
                    PersonelListele("Personel Telefon Adres Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nTelefon numarasını değiştirmek istediğiniz kişinin ismini yazınız = ");
                    var personelTelefon = Console.ReadLine();
                    var personelTel = prslYntms.FirstOrDefault(f => f.AdSoyad == personelTelefon);
                    Console.Write("Değiştirelecek yeni telefon numarasını giriniz = ");
                    personelTel.Telefon = Console.ReadLine();

                    PersonelListele($"{personelTel.Telefon} numaralı telefon güncellemesi yapılmıştır.");
                    break;
                case "5":
                    PersonelListele("Personel Ise Giris Tarihi Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nIse giris tarihini değiştirmek istediğiniz kişinin ismini yazınız = ");
                    var personelIseGiris = Console.ReadLine();
                    var personelIG = prslYntms.FirstOrDefault(f => f.AdSoyad == personelIseGiris);
                    Console.Write("Değiştirelecek yeni işe giriş tarihini giriniz = ");
                    personelIG.DogumTarihi = Console.ReadLine();

                    PersonelListele($"{personelIG.DogumTarihi} tarihli güncelleme yapılmıştır.");
                    break;
                case "6":
                    PersonelListele("Personel Durum Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\n Is durumunu değiştirmek istediğiniz kişinin ismini yazınız = ");
                    var personelDurum = Console.ReadLine();
                    var personelD = prslYntms.FirstOrDefault(f => f.AdSoyad == personelDurum);
                    Console.Write("Değiştirelecek durum bilgisini giriniz = ");
                    personelD.Durum = Console.ReadLine();

                    PersonelListele($"{personelD.Durum} durum güncellemesi yapılmıştır.");
                    break;

                case "7":
                    AnaSayfa.Cikis();
                    break;
                default:
                    Console.WriteLine("Hatalı tuş işlemi yaptınız");
                    break;
            }
        }

        public static void PersonelSil()                                                         //Personel Silme Methodum
        {
            AnaSayfa.EkranTemizle();
            PersonelListele("\n Personel Bilgisi Silme", true);                                 //Personel Listesini Getirip Üzerinde Değişiklikler Yapmak için Methodu Çağrıyorum.
            Console.WriteLine("------------------------------");
            Console.Write("Silinecek Personel Adını giriniz = ");
            var personelSil = Console.ReadLine();
            var personelS = prslYntms.FirstOrDefault(f => f.AdSoyad == personelSil);            //Console'dan girilen personelSil ile srvIslList isimli listemdeki AdSoyad kıyasliyorum doğru ise

            prslYntms.Remove(personelS);                                                        //==>Remove Methodu ile "personelS" listemdeki kaydı sildiriyorum.

            PersonelListele($"{personelS} isimli personel kaydı silindi.");                     //==>Islem sonunda mesajın silindiğine ait bilgi mesajı veriyorum.
        }
    }
}
