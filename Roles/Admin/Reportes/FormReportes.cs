using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Reportes
{
    public partial class FormReportes : Form
    {
        private Label lblInfo;
        private DataGridView dgvResumen;

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            lblInfo = new Label { Text = "Atenciones por mes", AutoSize = true, Top = 60, Left = 20 };
            dgvResumen = new DataGridView
            {
                Top = 90,
                Left = 20,
                Width = 400,
                Height = 250,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(lblInfo);
            Controls.Add(dgvResumen);

            CargarResumen();
        }

        private void CargarResumen()
        {
            using (var ctx = new Datos.ClinicaContext())
            {
                var resumen = ctx.Consultas
                    .GroupBy(c => new { c.FechaConsulta.Year, c.FechaConsulta.Month })
                    .Select(g => new
                    {
                        Anio = g.Key.Year,
                        Mes = g.Key.Month,
                        Total = g.Count()
                    })
                    .OrderBy(r => r.Anio).ThenBy(r => r.Mes)
                    .ToList();

                dgvResumen.DataSource = resumen;
            }
        }
    }
}
