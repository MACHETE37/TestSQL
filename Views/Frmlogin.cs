using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Views
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {

            string usuario = Properties.Settings.Default.Usuario;
            string password = Properties.Settings.Default.Password;

            string _txtusuario = txtusuario.Text;
            string _txtpassword = txtpassword.Text;

            byte[] bytesCadena = Encoding.UTF8.GetBytes(_txtpassword);

            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(bytesCadena);
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            string hashString = builder.ToString();

            if (hashString== password)
            {
                FrmMenu Frm = new FrmMenu();
                this.Hide();
                Frm.Show();
            }
            else
            {
                MessageBox.Show("ERROR: USUARIO O PASSWORD EQUIVOCADO");
            }
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login()
        { }
    }
}
