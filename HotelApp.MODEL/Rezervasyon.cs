using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.MODEL
{
    public class Rezervasyon
    {
        public int RezervasyonID { get; set; }
        public string MisafirTc { get; set; }
        public string OdaNumarasi { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public decimal ToplamFiyat { get; set; }
    }
}
