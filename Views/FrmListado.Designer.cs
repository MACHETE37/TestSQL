
namespace Test.Views
{
    partial class FrmListado
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
            this.dglistado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstJson = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dglistado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dglistado
            // 
            this.dglistado.AllowUserToAddRows = false;
            this.dglistado.AllowUserToDeleteRows = false;
            this.dglistado.AllowUserToResizeRows = false;
            this.dglistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglistado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dglistado.Location = new System.Drawing.Point(6, 19);
            this.dglistado.Name = "dglistado";
            this.dglistado.Size = new System.Drawing.Size(614, 327);
            this.dglistado.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Registros";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dglistado);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(156, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(626, 352);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // LstJson
            // 
            this.LstJson.Dock = System.Windows.Forms.DockStyle.Left;
            this.LstJson.FormattingEnabled = true;
            this.LstJson.Location = new System.Drawing.Point(6, 6);
            this.LstJson.Name = "LstJson";
            this.LstJson.Size = new System.Drawing.Size(150, 383);
            this.LstJson.TabIndex = 3;
            // 
            // FrmListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 395);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LstJson);
            this.Name = "FrmListado";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmListado";
            this.Load += new System.EventHandler(this.FrmListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dglistado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dglistado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox LstJson;
    }
}