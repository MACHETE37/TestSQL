using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test;
namespace Test.Views
{
    public partial class FrmThirdParties : Form
    {
        public FrmThirdParties()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveThirdParti();
            MessageBox.Show("SE HA GUARDADO EL REGISTRO");
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDocumentNumber.Text = "";
            txtPhoneNumber.Text = "";
            txtMobilePhoneNumber.Text = "";
            txtFaxNumber.Text = "";

        }

        private void SaveThirdParti()
        {
            ThirdParties ThirdParti = new ThirdParties
            {
                MODO=1,
                Address = txtAddress.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                DocumentNumber = txtDocumentNumber.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                VerificationDigit = 0,
                MobilePhoneNumber = txtMobilePhoneNumber.Text.Trim(),
                FaxNumber = txtFaxNumber.Text.Trim(),
                ID = 0,
                DocumentTypeID=int.Parse( cmbdocuments.SelectedValue .ToString()),
                CityIataCode=cmbcities.SelectedValue.ToString(),
                CountryID=int.Parse( cmbcountries.SelectedValue.ToString())
            };

            ThirdParti.PRC_ThirdParties();

        }

        private void FrmThirdParties_Load(object sender, EventArgs e)
        {
            LoadDocuments();
            LoadCountries();

        }

        private void LoadDocuments()
        {
            IdentificationDocuments IdentificationDocument = new IdentificationDocuments { MODO=2};

            cmbdocuments.DisplayMember = "name";
            cmbdocuments.ValueMember  = "ID";

            cmbdocuments.DataSource  = IdentificationDocument.PRC_IdentificationDocuments().Tables[0];

        }

        private void LoadCountries()
        {
            Countries countri = new Countries {MODO=2 };
            cmbcountries.ValueMember = "ID";
            cmbcountries.DisplayMember = "Name";
            cmbcountries.DataSource = countri.PRC_Countries().Tables[0];
        }
        private void LoadCities(int ID)
        {
            Countries countri = new Countries { 
            MODO =4,
            ID    = ID
            };

            cmbcities.ValueMember = "IATACode";
            cmbcities.DisplayMember = "Name";
            cmbcities.DataSource = countri.PRC_Countries().Tables[0];

        }

        private void cmbcountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcountries.Items.Count > 0)
            {
                LoadCities(int.Parse( cmbcountries.SelectedValue.ToString()));
            }
        }
    }
}
