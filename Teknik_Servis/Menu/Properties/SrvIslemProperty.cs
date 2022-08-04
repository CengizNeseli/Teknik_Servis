using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknik_Servis.Menu.Properties
{
    public class SrvIslemProperty
    {
        public string TeslimEdilmeTarihi { get; set; }
        public string StockKodu { get; set; }
        public DateTime TeslimAlmaTarihi { get; set; }
        public string CihazTuru { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string GarantisiVarMi { get; set; }
        public double Ucret { get; set; }
        public string Sonuc { get; set; }
    }
}
