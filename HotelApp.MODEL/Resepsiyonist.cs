using System;

namespace HotelApp.MODEL
{
    public class Resepsiyonist
    {
        private static Resepsiyonist _instance;
        private static readonly object _lock = new object();

        public int ResepsiyonistID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Eposta { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public string Sifre { get; set; }

        private Resepsiyonist() { }

        public static Resepsiyonist Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Resepsiyonist();
                        }
                    }
                }
                return _instance;
            }
        }
        public void ResepsiyonistBilgileri(int resepsiyonistID, string ad, string soyad, string telefonNumarasi, string eposta, DateTime baslamaTarihi, string sifre)
        {
            this.ResepsiyonistID = resepsiyonistID;
            this.Ad = ad;
            this.Soyad = soyad;
            this.TelefonNumarasi = telefonNumarasi;
            this.Eposta = eposta;
            this.BaslamaTarihi = baslamaTarihi;
            this.Sifre = sifre;
        }
    }
}
