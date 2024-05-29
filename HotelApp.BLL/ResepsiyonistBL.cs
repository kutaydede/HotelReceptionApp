using DAL;
using HotelApp.MODEL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp.BLL
{
    public class ResepsiyonistBL
    {
        public bool ResepsiyonistGiris(string ad, string soyad, string sifre)
        {
            var hlp = Helper.helper;
            SqlParameter[] p = {
        new SqlParameter("@Ad", ad),
        new SqlParameter("@Soyad", soyad),
        new SqlParameter("@Sifre", sifre)
    };

            var dr = hlp.ExecuteReader("SELECT * FROM Resepsiyonistler WHERE Ad=@Ad AND Soyad=@Soyad AND Sifre=@Sifre", p);
            bool girisBasarili = false;

            if (dr.Read())
            {
                girisBasarili = true; // Kullanıcı bulunduğunda giriş başarılı
            }
            dr.Close();
            return girisBasarili;
        }
    }
}

