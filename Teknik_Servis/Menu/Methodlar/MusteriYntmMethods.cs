using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu.Properties;                                    //==>Teknik Servis Menu Projem altındaki Menu Klasörünün Altındaki Tanımladığım Propertylerimi Referans almak için buraya yazdım

namespace Teknik_Servis.Menu.Methodlar
{
    public class MusteriYntmMethods : MstriYntmProperty                     //MstriYntmProperty altından da Property bilgilerini miras(Inheritance) aliyorum.
    {
        public static List<MusteriYntmMethods> musteriYntms;                //==> BU classa musteriYntms adında bir obje yaratiyorum ve cagiracagim methodlar için yaziyorum.

        public static void MusteriListele(string mesajM = "", bool musteriListele = false)              //MusteriListele Methoduma (Oluştururken bir başlık mesajı, Islem Bittiginde Geri Dönmemesi 
        {                                                                                               //için bir false Değer atiyorum.
            AnaSayfa.EkranTemizle();

            Console.WriteLine("Müsteri Bilgileri ");
            Console.WriteLine("---------------------------");
                
            if (!string.IsNullOrEmpty(mesajM))                                                           //Eger Cagrildigi yerde UrunListele içi bos veya null ise 
            {
                Console.WriteLine(mesajM);                                                               //(mesaj parametresi ="baslik" yazdiriyorum)
            }


            Console.WriteLine($"\nNo {"Adı Soyadı".PadRight(17)}{"Telefon No".PadRight(22)}{"Mail".PadRight(17)}");

                                                                                                         //MusteriListele Methodumdaki başlıklarımı yaziyorum

            var sayac = 1;                                                                               //Bir sayac degeri atiyorum ki listelenirken 1-2-3-4-5 seklinde gitsin



            if (musteriYntms == null)                                                                   // musteriYntms isimli liste içeriğim null(içinde bir her hangi bir değer
            {                                                                                           //parametre vs. var mı) mu diye kontrol ettiriyorum
                MusteriMenu.MusteriBilgiOlustur();                                                      //Eger bos ise MusteriMenu Classı altındaki MusteriBilgiOlustur Methodumu cagirarak içindekileri yazdiriyorum.
            }


            foreach (var musteri in musteriYntms)
            {
                Console.WriteLine($"{sayac} - {musteri.AdSoyad.PadRight(16)}{musteri.Telefon.PadRight(22)}{musteri.Mail.PadRight(17)}");
                sayac++;
            }

                                                        //Son olarak srvIslList listemdeki srvIsl isminde bir item atayarak içeriğinde gezdiriyorum ve ekrana bu değerlerin karşılığını yazdırıyorum.

            if (!musteriListele)
            {
                AnaSayfa.MenuyeDon();                   //Islem Bitince Menuye Donmesini Sagliyorum.
            }

        }

        public static void MusteriEkle()
        {
            AnaSayfa.EkranTemizle();
            MusteriListele("\n Musteri Bilgisi Ekleme - Musteri Listesi", true);                    //MusteriListele Methodu çağrıyorum ve Urun Ekleme başlık mesajını veriyorum.
            Console.WriteLine("--------------------");

            
            Console.Write("\n Ad ve Soyad Giriniz = ");
            var yeniMusteri = new MusteriYntmMethods();                                              //==> MusteriYntmMethods Class ı altında yeniUrun adında bir nesne,obje oluşturuyorum.
            yeniMusteri.AdSoyad = Console.ReadLine();                                                 
            var musteri = musteriYntms.FirstOrDefault(f => f.AdSoyad == yeniMusteri.AdSoyad);       //==>Konsoldan girilen AdSoyad ile srvIslList isimli listemdeki AdSoyad Kıyasliyorum. Eğer yok ise ekliyor
                                                                                                   
            Console.Write("Telefon Numarası Giriniz = ");                   
            yeniMusteri.Telefon = Console.ReadLine();                                               // ve ardından geri kalan diğer tüm nitelikler (AdSoyad-Telefon-Mail vs)

            Console.Write("Mail Adresi Giriniz = ");
            yeniMusteri.Mail = Console.ReadLine();                                                  //Musteri bilgilerini girmeye başladığım için listede ki obje özelliklerine değerler girildikçe eklenmeye devam ediyor




            musteriYntms.Add(yeniMusteri);                                                          //Islem Sonunda oluşturmuş olduğum yeniMusteri nesne,objemi MusteriYntmMethods classındaki listeme ekliyorum.

            MusteriListele($"{yeniMusteri.AdSoyad} adına ait müşteri bilgisi eklendi.");            //Islem sonunda bilgi mesajı veriyorum.

            AnaSayfa.MenuyeDon();

        }

        public static void MusteriGuncelle()
        {
            AnaSayfa.EkranTemizle();
            MusteriListele("\nMüşteri Bilgisi Güncelleme - Müşteri Listesi", true);      //MusteriListele Üzerinde Değişiklikler Yapmak için Methodu Çağrıyorum.

            Console.WriteLine("------------------------------");

            Console.WriteLine("\n[1] - Ad Soyad Değişikliği");
            Console.WriteLine("[2] - Telefon Değişikliği");
            Console.WriteLine("[3] - Mail Adres Değişikliği");
            Console.WriteLine("[4] - Çıkış");

            Console.WriteLine("\n------------------------------");

            Console.Write("\n Yapmak istediğiniz işlemi seciniz = ");

            var guncelMusteriIslem = Console.ReadLine();                                //Yapılması istenilen işlemi girmesi için guncelMusteriIslem adında bir değişken değeri bekliyorum.



            switch (guncelMusteriIslem)                                                 //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
            {
                case "1":

                    MusteriListele("Musteri Ad Soyad Değişikliği ", true);                  //MusteriListele Methodu içerisine Ad Soyad Değişikliği başlığı ile Methodu çağrıyorum.
                    Console.WriteLine("\n------------------------");
                    Console.Write("\nHangi İsmi Değiştirmek istiyorsunuz ? = ");
                    var musteriAdSoyad = Console.ReadLine();
                    var musteriA = musteriYntms.FirstOrDefault(f => f.AdSoyad == musteriAdSoyad);    //Console'dan girilen musteriAdSoyad ile srvIslList isimli listemdeki
                    Console.Write("Değiştirelecek yeni ad soyad giriniz = ");                        // AdSoyad kıyasliyorum doğru ise (referans değişkenler)
                    musteriA.AdSoyad = Console.ReadLine();                                           //// Listemdeki AdSoyad üzerine yazdiriyorum.

                    MusteriListele($"{musteriA.AdSoyad} ismine ait güncelleme yapılmıştır.");       // Islem sonunda bilgi mesajı veriyorum. Diğer Switch keylerin hepsi de aynı mantıkta çalişiyor. 1-3
                    break;
                case "2":
                    MusteriListele("Musteri Telefon Değişikliği ", true);
                    Console.WriteLine("\n-----------------------------");
                    Console.Write("\nTelefon numarasını değiştirmek istediğiniz kişinin isim ve soyismini yazın = ");
                    var musteriTelefon = Console.ReadLine();
                    var musteriIsım = musteriYntms.FirstOrDefault(f => f.AdSoyad == musteriTelefon);
                    Console.Write("Değiştirelecek yeni telefon numarası giriniz = ");
                    musteriIsım.Telefon = Console.ReadLine();

                    MusteriListele($"{musteriIsım.Telefon} telefon numarası güncellemesi yapılmıştır.");
                    break;
                case "3":
                    MusteriListele("Musteri Mail Adres Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nMail Adresini Değiştirmek istediğiniz kişinin isim ve soyismini yazınız = ");
                    var musteriMail = Console.ReadLine();
                    var musteriM = musteriYntms.FirstOrDefault(f => f.AdSoyad == musteriMail);
                    Console.Write("Değiştirelecek yeni mail adresi giriniz = ");
                    musteriM.Mail = Console.ReadLine();

                    MusteriListele($"{musteriM.Mail} mail adresi güncelleme yapılmıştır.");
                    break;
                case "4":
                    AnaSayfa.Cikis();
                    break;
                default:
                    Console.WriteLine("Hatalı tuş işlemi yaptınız");
                    break;
            }
        }

        public static void MusteriSil()
        {
                AnaSayfa.EkranTemizle();
                MusteriListele("\nMusteri Bilgisi Silme", true);                            //MusteriListele Üzerinde Değişiklikler Yapmak için Methodu Çağrıyorum.
            Console.WriteLine("------------------------------");
                Console.Write("Silinecek müşterinin ismini ve soyismini giriniz = ");
                var musteriSil = Console.ReadLine();
                var musteriS = musteriYntms.FirstOrDefault(f => f.AdSoyad == musteriSil);   //Console'dan girilen musteriSil ile musteriYntms isimli listemdeki AdSoyad kıyasliyorum doğru ise

            musteriYntms.Remove(musteriS);                                                  //==> Remove Methodu ile "musteriS" listemdeki kaydı sildiriyorum.

            MusteriListele($"{musteriS} isimli müşteri kaydı silindi.");                    //==>Islem sonunda mesajın silindiğine ait bilgi mesajı veriyorum.

        }
    }
}

