using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.MODEL
{
    public class Rezervasyon
    {
        public int RezervasyonID { get; set; }
        public int MisafirID { get; set; }
        public int OdaID { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public decimal ToplamFiyat { get; set; }
    }
}
