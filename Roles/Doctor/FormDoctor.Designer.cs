﻿namespace Roles.Doctor
{
    partial class FormDoctor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsuario;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(12, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(127, 19);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Bienvenido: Doc";
            // 
            // FormDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUsuario);
            this.Name = "FormDoctor";
            this.Text = "Panel Doctor";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
