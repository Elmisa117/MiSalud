using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin
{
    partial class FormAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenido;

        private System.Windows.Forms.Button btnPersonal;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnConsultas;
        private System.Windows.Forms.Button btnHospitalizaciones;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnPlanesPago;
        private System.Windows.Forms.Button btnFichasClinicas;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();

            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(30, 60, 114); // Azul clínico oscuro
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Width = 200;

            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;

            // 
            // Botones con estilo clínico moderno
            // 
            string[] nombres = {
                "btnPersonal", "btnEspecialidades", "btnServicios", "btnConsultas", "btnHospitalizaciones",
                "btnFacturacion", "btnPlanesPago", "btnFichasClinicas", "btnReportes", "btnConfiguracion", "btnCerrarSesion"
            };

            string[] textos = {
                "Gestión Personal", "Especialidades", "Servicios", "Consultas", "Hospitalizaciones",
                "Facturación", "Planes de Pago", "Fichas Clínicas", "Reportes", "Configuración", "Cerrar Sesión"
            };

            EventHandler[] eventos = {
                btnPersonal_Click, btnEspecialidades_Click, btnServicios_Click, btnConsultas_Click, btnHospitalizaciones_Click,
                btnFacturacion_Click, btnPlanesPago_Click, btnFichasClinicas_Click, btnReportes_Click, btnConfiguracion_Click, btnCerrarSesion_Click
            };

            System.Windows.Forms.Button[] referencias = new System.Windows.Forms.Button[nombres.Length];

            for (int i = 0; i < nombres.Length; i++)
            {
                referencias[i] = new System.Windows.Forms.Button();
                referencias[i].Name = nombres[i];
                referencias[i].Text = textos[i];
                referencias[i].Dock = System.Windows.Forms.DockStyle.Top;
                referencias[i].Height = 45;
                referencias[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                referencias[i].FlatAppearance.BorderSize = 0;
                referencias[i].Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                referencias[i].ForeColor = System.Drawing.Color.White;
                referencias[i].BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
                referencias[i].TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                referencias[i].Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

                referencias[i].Click += eventos[i]; // ← Vincula el evento

                this.panelMenu.Controls.Add(referencias[i]);
                this.panelMenu.Controls.SetChildIndex(referencias[i], 0);
            }

            // 
            // FormAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador - Clínica MiSalud";

            this.ResumeLayout(false);
        }
    }
}

