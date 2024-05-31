using DAL;
using HotelApp.MODEL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HotelApp.BLL
{
    public class MisafirBL
    {
        public bool MisafirEkle(Misafir misafir)
        {
            try
            {
                SqlParameter[] p = {
                    new SqlParameter("@MisafirTc", misafir.MisafirTc),
                    new SqlParameter("@Ad", misafir.Ad),
                    new SqlParameter("@Soyad", misafir.Soyad),
                    new SqlParameter("@Telefon", misafir.TelefonNumarasi),
                    new SqlParameter("@Eposta", misafir.Eposta),
                    new SqlParameter("@DTarihi", misafir.DogumTarihi)
                };

                var hlp = Helper.helper;
                return hlp.ExecuteNonQuery("INSERT INTO Misafirler (MisafirTc, Ad, Soyad, TelefonNumarasi, Eposta, DogumTarihi) VALUES (@MisafirTc, @Ad, @Soyad, @Telefon, @Eposta, @DTarihi)", p) > 0;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetAllMisafirler()
        {
            string query = "SELECT * FROM Misafirler";
            using (Helper helper = Helper.helper)
            {
                SqlDataReader reader = helper.ExecuteReader(query);
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
    }
}
