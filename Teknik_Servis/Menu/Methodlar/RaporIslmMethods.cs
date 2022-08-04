using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknik_Servis.Menu.Properties;                                     //==>Teknik Servis Menu Projem altındaki Menu Klasörünün Altındaki Tanımladığım Propertylerimi Referans almak için buraya yazdım

namespace Teknik_Servis.Menu.Methodlar
{
    public class RaporIslmMethods : RaporIslmProperty                       //RaporIslmProperty altından da Property bilgilerini miras(Inheritance) aliyorum.
    {
        public static List<RaporIslmMethods> TeslimEdenList;                //==> BU classa TeslimEdenList adında bir obje yaratiyorum ve cagiracagim methodlar için yaziyorum.

        public static List<RaporIslmMethods> TeslimAlanList;                //==> BU classa TeslimAlanList adında bir obje yaratiyorum ve cagiracagim methodlar için yaziyorum.

        public static void TeslimAlma(string mesajRTA = "", bool raporTaListele = false)  //==> TeslimAlma Methoduma (Oluştururken bir başlık mesajı, Islem Bittiginde Geri Dönmemesi 
        {                                                                                 //==> için bir false Değer atiyorum.
            AnaSayfa.EkranTemizle();
            Console.WriteLine("Rapor Teslim Alma Bilgileri ");
            Console.WriteLine("---------------------------");

            if (!string.IsNullOrEmpty(mesajRTA))                                //Eger Cagrildigi yerde UrunListele içi bos veya null ise 
            {
                Console.WriteLine(mesajRTA);                                     //(mesaj parametresi ="baslik" yazdiriyorum)
            }


            Console.WriteLine($"\nNo {"Kontrol Edilecek".PadRight(25)}{"Parca Siparis".PadRight(22)}{"Garantiye Gönderim".PadRight(25)}{"Bakim Yapılacak".PadRight(17)}");
                                                                                  //TeslimAlma Methodumdaki başlıklarımı yaziyorum
            var sayac = 1;
                                                                                  //Bir sayac degeri atiyorum ki listelenirken 1-2-3-4-5 seklinde gitsin
            if (TeslimAlanList == null)
            {                                                                       //TeslimAlanList isimli liste içeriğim null(içinde bir her hangi bir değer parametre vs. var mı) mu diye kontrol ettiriyorum
                RaporMenu.TeslimAlmaIstatigiOlustur();                              //Eger bos ise RaporMenu Classı altındaki TeslimAlmaIstatigiOlustur Methodumu cagirarak içindekileri yazdiriyorum.
            }
            

            foreach (var TeslimAlan in TeslimAlanList)
            {
                Console.WriteLine($"{sayac} - {TeslimAlan.KontrolEdilecek.ToString().PadRight(25)}{TeslimAlan.ParcaSiparis.ToString().PadRight(22)}{TeslimAlan.GarantiyeGonderim.ToString().PadRight(25)}{TeslimAlan.BakimYapilacak.ToString().PadRight(17)}");
                sayac++;
            }
                                                                                        //Son olarak TeslimAlanList listemdeki TeslimAlan isminde bir item atayarak 
                                                                                         //içeriğinde gezdiriyorum ve ekrana bu değerlerin karşılığını yazdırıyorum.  
            if (!raporTaListele)                                                    
            {
                AnaSayfa.MenuyeDon();                                                   //Islem Bitince Menuye Donmesini Sagliyorum.
            }

        }

        public static void TeslimEtme(string mesajRTE = "", bool raporTeListele = false)    //==> TeslimEden Methoduma (Oluştururken bir başlık mesajı, Islem Bittiginde Geri Dönmemesi 
        {                                                                                   //==> için bir false Değer atiyorum.
            AnaSayfa.EkranTemizle();
            Console.WriteLine("Rapor Teslim Etme Bilgileri ");
            Console.WriteLine("---------------------------");

            if (!string.IsNullOrEmpty(mesajRTE))                                            //==> TeslimEden Methoduma (Oluştururken bir başlık mesajı, Islem Bittiginde Geri Dönmemesi 
            {
                Console.WriteLine(mesajRTE);                                                //==> için bir false Değer atiyorum.
            }


            Console.WriteLine($"\nNo {"Onarılan".PadRight(17)}{"Geri Iade".PadRight(22)}{"Teslim Edilen".PadRight(17)}{"Dış Servis".PadRight(17)}{"Onarılamayan".PadRight(17)}");

                                                                                             //TeslimEtme Methodumdaki başlıklarımı yaziyorum
            var sayac = 1;

            if (TeslimEdenList == null)                                                 //TeslimEdenList isimli liste içeriğim null(içinde bir her hangi bir değer parametre vs. var mı) mu diye kontrol ettiriyorum
            {
                RaporMenu.TeslimEtmeIstatigiOlustur();                                  //Eger bos ise RaporMenu Classı altındaki TeslimEtmeIstatigiOlustur Methodumu cagirarak içindekileri yazdiriyorum.
            }


            foreach (var TeslimEden in TeslimEdenList)
            {
                Console.WriteLine($"{sayac} - {TeslimEden.OnarılmisOlan.ToString().PadRight(16)}{TeslimEden.GeriIade.ToString().PadRight(22)}{TeslimEden.TeslimEdilen.ToString().PadRight(17)}{TeslimEden.DisServis.ToString().PadRight(17)}{TeslimEden.Onarılamayan.ToString().PadRight(17)}");
                sayac++;
            }
                                                                                                    //Son olarak TeslimEdenList listemdeki TeslimEden isminde bir item atayarak    
                                                                                                     //içeriğinde gezdiriyorum ve ekrana bu değerlerin karşılığını yazdırıyorum. 
            if (!raporTeListele)
            {
                AnaSayfa.MenuyeDon();                                                               //Islem Bitince Menuye Donmesini Sagliyorum.
            }
        }
    }
}
