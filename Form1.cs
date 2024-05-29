using HotelApp.BLL;
using System;
using System.Windows.Forms;

namespace HotelReceptionApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResepsiyonistBL resepsiyonistBL = new ResepsiyonistBL();
            bool result = true;//resepsiyonistBL.ResepsiyonistGiris(txtAd.Text.Trim(), txtSoyad.Text.Trim(), txtSifre.Text.Trim());
            if (result)
            {
                var frm = new FormHome(this);
                frm.Show();
                this.Hide(); // Form1'i gizle
            }
            else
            {
                MessageBox.Show("Giriş başarısız. Lütfen bilgilerinizi kontrol edin.");
            }
        }
    }
}
