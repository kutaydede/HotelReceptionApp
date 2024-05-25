using DAL;
using HotelApp.MODEL;
using Microsoft.Data.SqlClient;
using System;

namespace HotelApp.BLL
{
    public class MisafirBL
    {
        public bool MisafirEkle(Misafir misafir)
        {
            try
            {
                SqlParameter[] p = {
                           new SqlParameter("@Ad",misafir.Ad),
                           new SqlParameter("@Soyad",misafir.Soyad),
                           new SqlParameter("@Telefon",misafir.TelefonNumarasi),
                           new SqlParameter("@Eposta",misafir.Eposta),
                           new SqlParameter("@DTarihi",misafir.DogumTarihi),

                     };

                var hlp = Helper.helper;
                return hlp.ExecuteNonQuery("Insert into Misafirler (Ad,Soyad,TelefonNumarasi,Eposta,DogumTarihi) values (@Ad,@Soyad,@Telefon,@Eposta,@DTarihi)", p) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}

