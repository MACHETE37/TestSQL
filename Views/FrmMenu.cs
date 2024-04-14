using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Views
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmListado frm = new FrmListado();
            frm.ShowDialog();

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmThirdParties frm = new FrmThirdParties();
            frm.ShowDialog();
        }
    }
}
