using HotelApp.BLL;
using HotelApp.MODEL;
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
    public partial class GuestsControl : UserControl
    {
        public GuestsControl()
        {
            InitializeComponent();
            LoadData();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Misafir misafir = new Misafir
            {
                MisafirTc = txtTc.Text.Trim(),
                Ad = txtAd.Text.Trim(),
                Soyad = txtSoyad.Text.Trim(),
                TelefonNumarasi = txtTelefon.Text.Trim(),
                Eposta = txtEmail.Text.Trim(),
                DogumTarihi=dateTimePicker1.Value
            };
            MisafirBL misafirBL = new MisafirBL();
            bool result = misafirBL.MisafirEkle(misafir);
            if (result)
            {
                MessageBox.Show("Kayıt başarılı.");
                textboxClear();
            }
            else
            {
                MessageBox.Show("Kayıt başarısız. Lütfen bilgilerinizi kontrol edin.");
            }

        }
        private void textboxClear()
        {
            txtTc.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            dateTimePicker1.Value = DateTime.Now;

        }
        MisafirBL misafirBL = new MisafirBL();
        public void LoadData()
        {
            try
            {
                DataTable misafirlerTable = misafirBL.GetAllMisafirler();
                dataGridView1.DataSource = misafirlerTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme işlemi sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.misafirlerTableAdapter.FillBy(this.otelResepsiyonDBDataSet.Misafirler);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
