using DAL;
using HotelApp.MODEL;
using HotelReceptionApp.Properties;
using Microsoft.ApplicationInsights.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReceptionApp
{
    public partial class RoomsControl : UserControl
    {
        private Panel panelContainer; // Panel nesnesi

        public RoomsControl()
        {
            InitializeComponent();
            LoadRooms();
        }

        private void LoadRooms()
        {
            List<Oda> odalar = GetOdalar();
            CreateRoomButtons(odalar);
            this.Size = new Size(1120, 465);
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
            int buttonWidth = 150;
            int buttonHeight = 80;
            int margin = 10;

            panelContainer = new Panel();
            panelContainer.AutoScroll = true; // Eğer butonlar panelin sınırlarını aşıyorsa kaydırma çubuğunu görüntüler
            panelContainer.Dock = DockStyle.Fill; // Panel, tüm kullanılabilir alanı kaplar
            this.Controls.Add(panelContainer); // Paneli form kontrolüne ekler

            foreach (var oda in odalar)
            {
                Button button = new Button();
                button.Text = oda.OdaNumarasi;
                button.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                button.Width = buttonWidth;
                button.Height = buttonHeight;
                button.Left = x;
                button.Top = y;
                button.BackColor = oda.DoluMu ? Color.DarkGray : Color.PaleGreen;
                button.Click += (s, e) => RoomButton_Click(s, e, oda);

                // Oda tipine göre resim ve boyutları belirle
                Image resim = null;
                int yeniGenislik = 0;
                int yeniYukseklik = 0;

                switch (oda.OdaTipi)
                {
                    case "Standart":
                        resim = Properties.Resource1.standartBed;
                        yeniGenislik = 40;
                        yeniYukseklik = 40;
                        break;
                    case "Deluxe":
                        resim = Properties.Resource1.deluxeBed;
                        yeniGenislik = 40;
                        yeniYukseklik = 40;
                        break;
                    case "Suite":
                        resim = Properties.Resource1.suitBed;
                        yeniGenislik = 40;
                        yeniYukseklik = 40;
                        break;
                }

                // Resmi yeniden boyutlandır
                Image yeniResim = new Bitmap(resim, yeniGenislik, yeniYukseklik);

                // Butonun resim ve boyutlarını ayarla
                button.Image = yeniResim;
                button.ImageAlign = ContentAlignment.TopCenter;
                button.TextImageRelation = TextImageRelation.ImageAboveText;

                // Butonu panel içine ekle
                panelContainer.Controls.Add(button);

                // Butonun konumunu ayarla
                y += buttonHeight + margin;

                if (y + buttonHeight > panelContainer.ClientSize.Height)
                {
                    y = 10;
                    x += buttonWidth + margin;
                }
            }
        }

        private void RoomButton_Click(object sender, EventArgs e, Oda oda)
        {
            MessageBox.Show($"Oda Numarası: {oda.OdaNumarasi}\nOda Tipi: {oda.OdaTipi}\nGecelik Fiyat: {oda.GecelikFiyat}\nDolu Mu: {oda.DoluMu}");
        }
    }
}
