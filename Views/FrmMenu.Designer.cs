
namespace Test.Views
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnVerListado = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnVerListado
            // 
            this.BtnVerListado.Location = new System.Drawing.Point(12, 12);
            this.BtnVerListado.Name = "BtnVerListado";
            this.BtnVerListado.Size = new System.Drawing.Size(75, 23);
            this.BtnVerListado.TabIndex = 0;
            this.BtnVerListado.Text = "Ver Listado";
            this.BtnVerListado.UseVisualStyleBackColor = true;
            this.BtnVerListado.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(12, 41);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(75, 23);
            this.BtnNuevo.TabIndex = 1;
            this.BtnNuevo.Text = "Nuevo registro";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 82);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnVerListado);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnVerListado;
        private System.Windows.Forms.Button BtnNuevo;
    }
}