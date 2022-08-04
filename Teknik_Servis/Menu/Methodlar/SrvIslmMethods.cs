using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu.Properties;                //==>Teknik Servis Menu Projem altındaki Menu Klasörünün Altındaki Tanımladığım Propertylerimi Referans almak için buraya yazdım

namespace Teknik_Servis.Menu.Methodlar
{
    public class SrvIslmMethods : SrvIslemProperty       //SrvIslemProperty altından da Property bilgilerini miras(Inheritance) aliyorum.
    {                                                       
        public static List<SrvIslmMethods> srvIslList;   //==> BU classa srvIslList adında bir obje yaratiyorum ve cagiracagim methodlar için yaziyorum.

        public static void UrunSil()                                //Urun Silme Methodum
        {

            AnaSayfa.EkranTemizle();
            UrunListele("\nÜrün Silme - Ürün Listesi", true);       //Güncel Ürün Listesini Getirip Üzerinde Değişiklikler Yapmak için Methodu Çağrıyorum.

            Console.WriteLine("------------------------------");
            Console.Write("Silinecek ürün kodunu giriniz = ");      
            var urunKodu1 = Console.ReadLine();                     
            var urun = srvIslList.FirstOrDefault(f => f.StockKodu == urunKodu1);    //Console'dan girilen urunKodu1 ile srvIslList isimli listemdeki StockKodu kıyasliyorum doğru ise
                                                                                     

            srvIslList.Remove(urun);                                                //==>Remove Methodu ile "urun" listemdeki kaydı sildiriyorum.

            UrunListele($"{urun} ürün silindi.");                                   //==>Islem sonunda mesajın silindiğine ait bilgi mesajı veriyorum.

        }

        public static void UrunGuncelle()
        {
            {
                AnaSayfa.EkranTemizle();
                UrunListele("\nÜrün Güncelleme - Ürün Listesi", true);          //Güncel Ürün Listesini Getirip Üzerinde Değişiklikler Yapmak için Methodu Çağrıyorum.

                Console.WriteLine("------------------------------");

                Console.WriteLine("\n[1] - Stock Kodu Değişikliği");
                Console.WriteLine("[2] - Teslim Alma Tarihi Değişikliği");
                Console.WriteLine("[3] - Ürün Türü Değişikliği");
                Console.WriteLine("[4] - Ürün Markası Değişikliği");
                Console.WriteLine("[5] - Ürün Modeli Değişikliği");
                Console.WriteLine("[6] - Ürün Garanti Değişikliği");
                Console.WriteLine("[7] - Ürüne Yapılan İşlem Değişikliği");
                Console.WriteLine("[8] - Çıkış");

                Console.WriteLine("\n------------------------------");

                Console.Write("\n Yapmak istediğiniz işlemi seciniz = ");        
                var guncelIslemTuru = Console.ReadLine();                           //Yapılması istenilen işlemi girmesi için guncelIslemTuru adında bir değişken değeri bekliyorum. 


                switch (guncelIslemTuru)                                            //Switch altında hangi tuşlama yapıldıysa ona göre kod bloğuna gidiyor.
                {
                    case "1":

                        UrunListele("Stock Kodu Değişikliği ", true);                   //UrunListele Methodu içerisine Stock Kodu Değişikliği başlığı ile Methodu çağrıyorum.
                        Console.Write("Değiştirelecek kodu giriniz = ");
                        var urunStockKodu = Console.ReadLine();
                        var urunStock = srvIslList.FirstOrDefault(f => f.StockKodu == urunStockKodu);   //Console'dan girilen Stock kodu ile srvIslList isimli listemdeki                                                                                       
                        Console.Write("Yeni kodu giriniz = ");                                          // StockKodu kıyasliyorum doğru ise (referans değişkenler)
                        urunStock.StockKodu = Convert.ToString(Console.ReadLine());                     // Listemdeki StockKodun üzerine yazdiriyorum.

                        UrunListele($"{urunStockKodu} tarihli StockKodu değişikliği gerçekleştirilmiştir."); // Islem sonunda bilgi mesajı veriyorum. Diğer Switch keylerin hepsi de aynı mantıkta çalişiyor. 1-7
                        break;
                    case "2":
                        UrunListele("Teslim Tarihi Değişikliği ", true);
                        Console.Write("Değiştirelecek tarihi giriniz = ");
                        var urunTeslimTarihi = Console.ReadLine();
                        var urunTarih = srvIslList.FirstOrDefault(f => f.TeslimAlmaTarihi.ToString() == urunTeslimTarihi);
                        Console.Write("Yeni tarih değişikliği değerini giriniz = ");
                        urunTarih.TeslimAlmaTarihi = Convert.ToDateTime(Console.ReadLine());

                        UrunListele($"{urunTeslimTarihi} tarihli kayıt değişikliği gerçekleştirilmiştir.");
                        break;
                    case "3":
                        UrunListele("Cihaz Türü Değişikliği ", true);
                        Console.Write("Değiştirelecek cihaz turu Giriniz = ");
                        var urunCihazTuru = Console.ReadLine();
                        var UrunTuru = srvIslList.FirstOrDefault(f => f.CihazTuru == urunCihazTuru);
                        Console.Write("Yeni cihaz türünü Giriniz = ");
                        UrunTuru.CihazTuru = Convert.ToString(Console.ReadLine());

                        UrunListele($"{urunCihazTuru}  kaydı gerçekleştirilmiştir.");
                        break;
                    case "4":
                        UrunListele("Cihaz Markası Değişikliği ", true);
                        Console.Write("Değiştirelecek markanın adını giriniz = ");
                        var urunCihazMarkasi = Console.ReadLine();
                        var urunMarkasi = srvIslList.FirstOrDefault(f => f.Marka == urunCihazMarkasi);
                        Console.Write("Yeni cihaz markasını giriniz = ");
                        urunMarkasi.Marka = Convert.ToString(Console.ReadLine());

                        UrunListele($"{urunCihazMarkasi} kaydı gerçekleştirilmiştir.");
                        break;
                    case "5":
                        UrunListele("Cihaz Modeli Değişikliği ", true);
                        Console.Write("Değiştirelecek modelin adını giriniz = ");
                        var urunCihazModeli = Console.ReadLine();
                        var urunModeli = srvIslList.FirstOrDefault(f => f.Model == urunCihazModeli);
                        Console.Write("Yeni cihaz modelini giriniz = ");
                        urunModeli.Model = Convert.ToString(Console.ReadLine());

                        UrunListele($"{urunCihazModeli}  kaydı gerçekleştirilmiştir.");
                        break;
                    case "6":
                        UrunListele("Cihaz Garanti Değişikliği ", true);
                        Console.Write("Değiştirelecek garanti değerini giriniz = ");
                        var urunGarantisiVarMi = Console.ReadLine();
                        var urunGarantisi = srvIslList.FirstOrDefault(f => f.GarantisiVarMi == urunGarantisiVarMi);
                        Console.Write("Yeni cihaz garanti değerini Giriniz = ");
                        urunGarantisi.GarantisiVarMi = Convert.ToString(Console.ReadLine());

                        UrunListele($"{urunGarantisiVarMi} kaydı gerçekleştirilmiştir.");
                        break;
                    case "7":
                        UrunListele("Cihaz Sonuc Değişikliği ", true);
                        Console.Write("Değiştirelecek işlem sonucunu giriniz = ");
                        var urunCihazSonucu = Console.ReadLine();
                        var urunSonuc = srvIslList.FirstOrDefault(f => f.Sonuc == urunCihazSonucu);
                        Console.Write("Yeni yapılacak olan işlemi giriniz = ");
                        urunSonuc.Sonuc = Convert.ToString(Console.ReadLine());

                        UrunListele($"{urunCihazSonucu} kaydı gerçekleştirilmiştir.");
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

        public static void UrunEkle()
        {
            AnaSayfa.EkranTemizle();
            UrunListele("\nÜrün Ekleme - Ürün Listesi", true);                                      //UrunListele Methodu çağrıyorum ve Urun Ekleme başlık mesajını veriyorum.
            Console.WriteLine("--------------------");

            var yeniUrun = new SrvIslmMethods();                                                    //==> SrvIslmMethods Class ı altında yeniUrun adında bir nesne,obje oluşturuyorum.
            Console.Write("\nStock Kodunu Giriniz = ");                                             
            yeniUrun.StockKodu = Console.ReadLine();                                                //==>Konsoldan girilen StockKodu ile srvIslList isimli listemdeki StockKodu Kıyasliyorum. Eğer yok ise ekliyor
            var urun = srvIslList.FirstOrDefault(f => f.StockKodu == yeniUrun.StockKodu);           
            Console.Write("Teslim Alma Tarihi Giriniz = ");                                         
            yeniUrun.TeslimAlmaTarihi = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Cihaz Türünü Giriniz = ");                                               // ve ardından geri kalan diğer tüm nitelikler (Teslim Alma-Cihaz Türü vs)
            yeniUrun.CihazTuru = Console.ReadLine();

            Console.Write("Cihaz Markasını Giriniz = ");
            yeniUrun.Marka = Console.ReadLine();                                                    //Ürün bilgilerine girmeye başladığım için listede ki obje özelliklerine değerler girildikçe eklenmeye devam ediyor

            Console.Write("Cihaz Modelini Giriniz = ");
            yeniUrun.Model = Console.ReadLine();

            Console.Write("Cihazın Garantisi Mevcut mu ? = ");
            yeniUrun.GarantisiVarMi = Console.ReadLine();

            Console.Write("Cihaz için yapılan son işlemi girin = ");
            yeniUrun.Sonuc = Console.ReadLine();


            srvIslList.Add(yeniUrun);                                                               //Islem Sonunda oluşturmuş olduğum yeniUrun nesne,objemi SrvIslmMethods classındaki listeme ekliyorum.                

            UrunListele($"{yeniUrun.StockKodu} StockKoduna ait ürün eklendi.");                     //Islem sonunda bilgi mesajı veriyorum.

            AnaSayfa.MenuyeDon();

        }

        public static void UrunListele(string mesajS = "", bool urunListele = false)                //UrunListele Methoduma (Oluştururken bir başlık mesajı, Islem Bittiginde Geri Dönmemesi 
        {                                                                                           //için bir false Değer atiyorum.

            AnaSayfa.EkranTemizle();

            Console.WriteLine("Servise Gelen Ürün Listesi ");
            Console.WriteLine("---------------------------");

            if (!string.IsNullOrEmpty(mesajS))                                                      //Eger Cagrildigi yerde UrunListele içi bos veya null ise 
            {
                Console.WriteLine(mesajS);                                                          //(mesaj parametresi ="baslik" yazdiriyorum)
            }


            Console.WriteLine($"\nNo {"Stock Kodu".PadRight(17)}{"Teslim Alma Tarihi".PadRight(22)}{"Cihaz Türü".PadRight(17)}{"Marka".PadRight(20)}{"Model".PadRight(20)}{"Garanti".PadRight(15)}{"Sonuc"}"); 

                                                                                                   //Urun Listele Methodumdaki başlıklarımı yaziyorum

            var sayac = 1;                                                                         //Bir sayac degeri atiyorum ki listelenirken 1-2-3-4-5 seklinde gitsin
        
            if (srvIslList == null)                                                                 //srvIslList isimli liste içeriğim null(içinde bir her hangi bir değer 
            {                                                                                       //parametre vs. var mı) mu diye kontrol ettiriyorum
                ServisMenu.ServisUrunOlustur();                                                     //Eger bos ise ServisMenu Classı altındaki ServisUrunOlustur Methodumu cagirarak içindekileri yazdiriyorum.
            
            }


            foreach (var srvIsl in srvIslList)
            {
                Console.WriteLine($"{sayac} - {srvIsl.StockKodu.PadRight(16)}{srvIsl.TeslimAlmaTarihi.ToString().PadRight(22)}{srvIsl.CihazTuru.PadRight(17)}{srvIsl.Marka.PadRight(20)}{srvIsl.Model.PadRight(20)}{srvIsl.GarantisiVarMi.PadRight(15)}{srvIsl.Sonuc}");
                sayac++;
            }

            //Son olarak srvIslList listemdeki srvIsl isminde bir item atayarak içeriğinde gezdiriyorum ve ekrana bu değerlerin karşılığını yazdırıyorum.


            if (!urunListele)
            {
                AnaSayfa.MenuyeDon();
            }

            //Islem Bitince Menuye Donmesini Sagliyorum.

           




        }
    }
}

