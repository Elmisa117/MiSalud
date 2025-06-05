using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Especialidades
{
    partial class FormGestionEspecialidades
    {
        private Label labelTitulo;
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelTitulo = new Label();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Dock = DockStyle.Top;
            this.labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.labelTitulo.ForeColor = Color.FromArgb(30, 60, 114);
            this.labelTitulo.Location = new Point(0, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new Size(800, 50);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "GESTIÓN DE ESPECIALIDADES";
            this.labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormGestionEspecialidades
            // 
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(800, 500);
            this.Controls.Add(this.labelTitulo);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "FormGestionEspecialidades";
            this.Load += new EventHandler(this.FormGestionEspecialidades_Load);
            this.ResumeLayout(false);
        }
    }
}
