using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using HotelApp.MODEL;
using DAL;

namespace HotelReceptionApp
{

    public partial class FormRooms : Form
    {
        FormHome formHome;
        public FormRooms(FormHome formHome)
        {
            InitializeComponent();
            this.formHome = formHome;
            LoadRooms();
        }
        private void LoadRooms()
        {
            List<Oda> odalar = GetOdalar();
            CreateRoomButtons(odalar);
        }

        private List<Oda> GetOdalar()
        {
            List<Oda> odalar = new List<Oda>();

            var hlp = Helper.helper;
            var dr = hlp.ExecuteReader("SELECT * FROM Odalar");

            while (dr.Read())
            {
                Oda oda = new Oda
                {
                    OdaID = (int)dr["OdaID"],
                    OdaNumarasi = dr["OdaNumarasi"].ToString(),
                    OdaTipi = dr["OdaTipi"].ToString(),
                    GecelikFiyat = (decimal)dr["GecelikFiyat"],
                    DoluMu = (bool)dr["DoluMu"]
                };
                odalar.Add(oda);
            }
            dr.Close();
            return odalar;
        }

        private void CreateRoomButtons(List<Oda> odalar)
        {
            int x = 10;
            int y = 10;
            int buttonWidth = 100;
            int buttonHeight = 50;
            int margin = 10;

            foreach (var oda in odalar)
            {
                Button button = new Button();
                button.Text = oda.OdaNumarasi;
                button.Width = buttonWidth;
                button.Height = buttonHeight;
                button.Left = x;
                button.Top = y;
                button.BackColor = oda.DoluMu ? Color.Red : Color.LightGreen;
                button.Click += (s, e) => RoomButton_Click(s, e, oda);

                this.Controls.Add(button);

                x += buttonWidth + margin;
                if (x + buttonWidth + margin > this.ClientSize.Width)
                {
                    x = 10;
                    y += buttonHeight + margin;
                }
            }
        }

        private void RoomButton_Click(object sender, EventArgs e, Oda oda)
        {
            MessageBox.Show($"Oda Numarası: {oda.OdaNumarasi}\nOda Tipi: {oda.OdaTipi}\nGecelik Fiyat: {oda.GecelikFiyat}\nDolu Mu: {oda.DoluMu}");
        }
    }
}
