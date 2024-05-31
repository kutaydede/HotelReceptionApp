using HotelApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;

namespace HotelReceptionApp
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            var resepsiyon = Resepsiyonist.Instance;
            label3.Text = $"{resepsiyon.Ad} {resepsiyon.Soyad}";
        }
        private void addController(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();

        }
        private void odalarButton_Click(object sender, EventArgs e)
        {
            RoomsControl roomsControl = new RoomsControl();
            addController(roomsControl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReservationControl reservationControl = new ReservationControl();
            addController(reservationControl);

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GuestsControl guestsControl = new GuestsControl();
            addController(guestsControl);
        }
    }
}
