using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;

namespace MiSalud.Roles.Admin.Hospitalizaciones
{
    public partial class FormVerHospitalizaciones : Form
    {
        private DataGridView dgv;

        public FormVerHospitalizaciones()
        {
            InitializeComponent();
        }

        private void FormVerHospitalizaciones_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarHospitalizaciones();
        }

        private void InicializarControles()
        {
            dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgv);
        }

        private void CargarHospitalizaciones()
        {
            using (var ctx = new ClinicaContext())
            {
                var lista = ctx.Hospitalizaciones
                    .Select(h => new { h.HospitalizacionId, h.PacienteId, h.HabitacionId, h.FechaIngreso, h.FechaAlta, h.Estado })
                    .ToList();
                dgv.DataSource = lista;
            }
        }
    }
}
