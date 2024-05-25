using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.MODEL
{
    public class Oda
    {
        public int OdaID { get; set; }
        public string OdaNumarasi { get; set; }
        public string OdaTipi { get; set; }
        public decimal GecelikFiyat { get; set; }
        public bool DoluMu { get; set; }
    }
}
