using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test;
namespace Test.Views
{
    public partial class FrmListado : Form
    {
        public FrmListado()
        {
            InitializeComponent();
        }

        private void FrmListado_Load(object sender, EventArgs e)
        {
            ThirdParties thirdPartie = new ThirdParties { MODO = 2 };
            DataTable Dt = thirdPartie.PRC_ThirdParties().Tables[0];
            if (Dt.Rows.Count > 0)
            {
                dglistado.DataSource = Dt;
                dglistado.Columns[0].Visible = false;
                ReadJson();
            }
            else
            {
                dglistado.DataSource = null;
                dglistado.Rows.Clear();
            }
        }
        private void ReadJson()
        {
            string nombreArchivo = "JsonXml.txt"; 
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", nombreArchivo);

            if (File.Exists(rutaCompleta))
            {
                    string JsonString = File.ReadAllText(rutaCompleta);
                    JsonTest json = JsonConvert.DeserializeObject<JsonTest>(JsonString);
                    LstJson.Items.Add($"ID: {json.Id}");
                    LstJson.Items.Add($"Nombre: {json.Nombre}");
                    LstJson.Items.Add($"Apellido: {json.Apellido}");
                    LstJson.Items.Add($"Identificación: {json.Identificacion}");
                    LstJson.Items.Add($"Tipo: {json.Tipo}");
                    LstJson.Items.Add($"Validar: {json.Validar}");
            }
        }
    }
}
