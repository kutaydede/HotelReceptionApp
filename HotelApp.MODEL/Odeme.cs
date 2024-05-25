using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.MODEL
{
    public class Odeme
    {
        public int OdemeID { get; set; }
        public int RezervasyonID { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public decimal Tutar { get; set; }
        public string OdemeYontemi { get; set; }
    }
}
