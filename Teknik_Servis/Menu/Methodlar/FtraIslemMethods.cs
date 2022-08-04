using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu.Properties;                                //==>Teknik Servis Menu Projem altındaki Menu Klasörünün Altındaki Tanımladığım Propertylerimi Referans almak için buraya yazdım

namespace Teknik_Servis.Menu.Methodlar
{

    public class FtraIslemMethods : FtrIslmProperty                 //FtrIslmProperty altından da Property bilgilerini miras(Inheritance) aliyorum.
    {
        public static List<FtraIslemMethods> ftraIslems;            //==> BU classa ftraIslems adında bir obje yaratiyorum ve cagiracagim methodlar için yaziyorum.
        public static void FaturaListele(string mesajF = "", bool faturaListele = false)    //FaturaListele Methoduma (Oluştururken bir başlık mesajı, Islem Bittiginde Geri Dönmemesi 
        {   
            AnaSayfa.EkranTemizle();                                                        //için bir false Değer atiyorum.

            Console.WriteLine("Fatura Bilgileri ");
            Console.WriteLine("---------------------------");

            if (!string.IsNullOrEmpty(mesajF))                                               //Eger Cagrildigi yerde FaturaListele içi bos veya null ise
            {
                Console.WriteLine(mesajF);                                                   //(mesaj parametresi ="baslik" yazdiriyorum)   
            }


            Console.WriteLine($"\nNo {"Açıklama".PadRight(17)}{"Tarih".PadRight(22)}{"Ad Soyad".PadRight(17)}{"Telefon".PadRight(17)}{"Miktar".PadRight(17)}{"Birim Fiyatı".PadRight(17)}{"Tutar".PadRight(17)}");

                                                                                             //FaturaListele Methodumdaki başlıklarımı yaziyorum


            var sayac = 1;                                                                  //Bir sayac degeri atiyorum ki listelenirken 1-2-3-4-5 seklinde gitsin

            if (ftraIslems == null)                                                          //ftraIslems isimli liste içeriğim null(içinde bir her hangi bir değer
            {
                FaturaMenu.FaturaBilgiOlustur();                                            //parametre vs. var mı) mu diye kontrol ettiriyorum
            }                                                                               //Eger bos ise FaturaMenu Classı altındaki FaturaBilgiOlustur Methodumu cagirarak içindekileri yazdiriyorum.


            foreach (var fatura in ftraIslems)
            {
                Console.WriteLine($"{sayac} - {fatura.Aciklama.PadRight(16)}{fatura.Tarih.ToString().PadRight(22)}{fatura.AdSoyad.PadRight(17)}{fatura.Telefon.PadRight(17)}{fatura.Miktar.ToString().PadRight(17)}{fatura.BirimFiyati.ToString().PadRight(17)}{fatura.Tutar.ToString().PadRight(17)}");
                sayac++;
            }

                                                                    //Son olarak ftraIslems listemdeki fatura isminde bir item atayarak içeriğinde gezdiriyorum ve ekrana bu değerlerin karşılığını yazdırıyorum.

            if (!faturaListele)
            {
                AnaSayfa.MenuyeDon();                               //Islem Bitince Menuye Donmesini Sagliyorum.
            }
        }

        public static void FaturaSil()                                                      //==>FaturaSil Methodum
        {
            AnaSayfa.EkranTemizle();
            FaturaListele("\n Fatura Bilgisi Silme", true);                                 //Fatura Bilgisi Üzerinde Değişiklikler Yapmak için Methodu Çağrıyorum.    
            Console.WriteLine("------------------------------");
            Console.Write("Silinecek faturanın müşteri adını giriniz = ");
            var faturaSil = Console.ReadLine();
            var faturaS = ftraIslems.FirstOrDefault(f => f.AdSoyad == faturaSil);           //Console'dan girilen faturaSil ile ftraIslems isimli listemdeki AdSoyad kıyasliyorum doğru ise

            ftraIslems.Remove(faturaS);                                                     //==>Remove Methodu ile "faturaS" listemdeki kaydı sildiriyorum.

            FaturaListele($"{faturaS.AdSoyad} isimli müşteri kaydı silindi.");              //==>Islem sonunda mesajın silindiğine ait bilgi mesajı veriyorum.
        }

        public static void FaturaEkle()
        {
            AnaSayfa.EkranTemizle();
            FaturaListele("\n Fatura Bilgisi Ekleme - Fatura Listesi", true);              //FaturaListele Methodu çağrıyorum ve Urun Ekleme başlık mesajını veriyorum.
            Console.WriteLine("--------------------");


            Console.Write("\n Aciklama giriniz = ");
            var yeniFatura = new FtraIslemMethods();                                            //==> FtraIslemMethods Class ı altında yeniUrun adında bir nesne,obje oluşturuyorum.
            yeniFatura.Aciklama = Console.ReadLine();                                               
            var yeniFaturaE = ftraIslems.FirstOrDefault(f => f.Aciklama == yeniFatura.Aciklama);    //==>Konsoldan girilen yeniFatura.Aciklama ile ftraIslems isimli listemdeki Aciklama Kıyasliyorum. Eğer yok ise ekliyor

            Console.Write("Fatura tarihi giriniz = ");
            yeniFatura.Tarih = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Musteri ad ve soyad bilgisi giriniz = ");                                   // ve ardından geri kalan diğer tüm nitelikler (Tarih-AdSoyad-Telefon vs)
            yeniFatura.AdSoyad = Console.ReadLine();

            Console.Write("Musteri telefon numarası giriniz = ");                                   //Fatura bilgilerini girmeye başladığım için listede ki obje özelliklerine değerler girildikçe eklenmeye devam ediyor
            yeniFatura.Telefon = Console.ReadLine();

            Console.Write("Miktar değerini giriniz = ");
            yeniFatura.Miktar = Convert.ToInt32(Console.ReadLine());


            Console.Write("Birim fiyatı giriniz = ");
            yeniFatura.BirimFiyati = Convert.ToInt32(Console.ReadLine());

            Console.Write("Fatura tutarı giriniz = ");
            yeniFatura.Tutar = Convert.ToInt32(Console.ReadLine());

            ftraIslems.Add(yeniFatura);                                                             //Islem Sonunda oluşturmuş olduğum yeniFatura nesne,objemi FtraIslemMethods classındaki listeme ekliyorum.

            FaturaListele($"{yeniFatura.AdSoyad} kaydı başarıyla gerçekleştirildi. ");              //Islem sonunda bilgi mesajı veriyorum.
        }

        public static void FaturaGuncelle()
        {
            AnaSayfa.EkranTemizle();
            FaturaListele("\nFatura Bilgisi Güncelleme - Fatura Listesi", true);    //FaturaListele Üzerinde Değişiklikler Yapmak için Methodu Çağrıyorum. 

            Console.WriteLine("------------------------------");                    

            Console.WriteLine("\n[1] - Miktar Değişikliği");
            Console.WriteLine("[2] - Açıklama Değişikliği");
            Console.WriteLine("[3] - Tarih Değişikliği");
            Console.WriteLine("[4] - Ad Soyad Değişikliği");
            Console.WriteLine("[5] - Telefon Değişikliği");
            Console.WriteLine("[6] - Birim Fiyat Değişikliği");
            Console.WriteLine("[7] - Tutar Değişikliği");
            Console.WriteLine("[8] - Çıkış");

            Console.WriteLine("\n------------------------------");

            Console.Write("\n Yapmak istediğiniz işlemi seciniz = ");
            var guncelFaturaIslem = Console.ReadLine();                                     //Yapılması istenilen işlemi girmesi için guncelFaturaIslem adında bir değişken değeri bekliyorum. 



            switch (guncelFaturaIslem)                                                       //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
            {
                case "1":
                    FaturaListele("Fatura Miktar Değişikliği ", true);                              //FaturaListele Methodu içerisine Stock Kodu Değişikliği başlığı ile Methodu çağrıyorum
                    Console.WriteLine("\n-----------------------------");
                    Console.Write("\n Miktarı değiştirmek istediğiniz kişinin isim ve soyismini giriniz = ");

                    var faturaMiktar = Console.ReadLine();
                    var faturaG = ftraIslems.FirstOrDefault(f => f.AdSoyad == faturaMiktar);        //Console'dan girilen faturaMiktar ile srvIslList isimli listemdeki
                    Console.Write("Değiştirelecek yeni miktarı giriniz = ");                        // AdSoyad kıyasliyorum doğru ise (referans değişkenler)
                    faturaG.Miktar = Convert.ToInt32(Console.ReadLine());                            // Listemdeki Seçilen Ad Soyadına ait Miktar Kısmına yazdiriyorum.

                    FaturaListele($"{faturaG.Miktar} güncellemesi yapılmıştır.");                   // Islem sonunda bilgi mesajı veriyorum. Diğer Switch keylerin hepsi de aynı mantıkta çalişiyor. 1-7
                    break;  

                case "2":
                    FaturaListele("Aciklama Değişikliği ", true);
                    Console.WriteLine("\n-----------------------------");
                    Console.Write("\n Değiştirmek istediğiniz aciklama kaydına ait kişinin isim ve soyismini girin = ");
                    var faturaAciklama = Console.ReadLine();
                    var faturaAc = ftraIslems.FirstOrDefault(f => f.AdSoyad == faturaAciklama);
                    Console.Write("Değiştirelecek yeni aciklamayi yaziniz = ");
                    faturaAc.Aciklama = Console.ReadLine();

                    FaturaListele($"{faturaAc.Aciklama} aciklama güncellenmesi yapılmıştır.");
                    break;

                case "3":
                    FaturaListele("Fatura Tarihi Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nDeğiştirmek istediğiniz tarihin faturaya kayıtlı kişinin isim ve soyismini yazınız = ");
                    var faturaTarihi = Console.ReadLine();
                    var faturaTa = ftraIslems.FirstOrDefault(f => f.AdSoyad == faturaTarihi);
                    Console.Write("Değiştirelecek yeni fatura tarihini giriniz = ");
                    faturaTa.Tarih = Convert.ToDateTime(Console.ReadLine());

                    FaturaListele($"{faturaTa.Tarih} tarihi değiştirilmiştir.");
                    break;

                case "4":
                    FaturaListele("Fatura Ad Soyad Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nDeğiştirmek istediğiniz kişinin isim ve soyismini yazınız = ");
                    var faturaAdSoyad = Console.ReadLine();
                    var faturaAd = ftraIslems.FirstOrDefault(f => f.AdSoyad == faturaAdSoyad);
                    Console.Write("Değiştirelecek yeni isim ve soyisim giriniz = ");
                    faturaAd.AdSoyad = Console.ReadLine();

                    FaturaListele($"{faturaAd.AdSoyad} kaydı yapılmıştır.");
                    break;

                case "5":
                    FaturaListele("Fatura Kisi Telefon Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nMail Adresini değiştirmek istediğiniz kişinin isim ve soyismini yazınız = ");
                    var faturaTelefon = Console.ReadLine();
                    var faturaTel = ftraIslems.FirstOrDefault(f => f.AdSoyad == faturaTelefon);
                    Console.Write("Değiştirelecek yeni telefon numarası giriniz = ");
                    faturaTel.Telefon = Console.ReadLine();

                    FaturaListele($"{faturaTel.Telefon} telefon numarası güncellenmiştir.");
                    break;

                case "6":
                    FaturaListele("Fatura Birim Fiyat Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nDeğiştirmek istediğiniz birim fiyatina ait kişinin isim ve soyismini yazınız = ");
                    var faturaBirim = Console.ReadLine();
                    var faturaB = ftraIslems.FirstOrDefault(f => f.AdSoyad == faturaBirim);
                    Console.Write("Değiştirelecek yeni birim fiyatı giriniz = ");
                    faturaB.BirimFiyati = Convert.ToInt32(Console.ReadLine()); 

                    FaturaListele($"{faturaB.BirimFiyati} birim fiyatı güncellenmiştir.");
                    break;


                case "7":
                    FaturaListele("Fatura Tutar Değişikliği ", true);
                    Console.WriteLine("\n--------------------------------");
                    Console.Write("\nMail Adresini Değiştirmek istediğiniz kişinin ismini yazınız = ");
                    var faturaTutar = Console.ReadLine();
                    var faturaTu = ftraIslems.FirstOrDefault(f => f.AdSoyad == faturaTutar);
                    Console.Write("Değiştirelecek yeni tutarı giriniz = ");
                    faturaTu.Tutar = Convert.ToInt32(Console.ReadLine());

                    FaturaListele($"{faturaTu.Tutar} tutar kaydı yapılmıştır.");
                    break;

                case "8":
                    AnaSayfa.Cikis();
                    break;
                default:
                    Console.WriteLine("Hatalı tuş işlemi yaptınız");
                    break;
            }
        }


    }
}
