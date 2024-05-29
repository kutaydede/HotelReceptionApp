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
    public partial class FormHome : Form
    {
        Form1 form1;
        public FormHome(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new FormRooms(this);
            frm.Show();
        }
    }
}
