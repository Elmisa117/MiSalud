using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;

namespace MiSalud.Roles.Admin.FichasClinicas
{
    public partial class FormVerFichasClinicas : Form
    {
        private DataGridView dgv;

        public FormVerFichasClinicas()
        {
            InitializeComponent();
        }

        private void FormVerFichasClinicas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarFichas();
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

        private void CargarFichas()
        {
            using (var ctx = new ClinicaContext())
            {
                var lista = ctx.FichasClinico
                    .Select(f => new { f.FichaId, f.PacienteId, f.PersonalId, f.FechaApertura, f.Estado })
                    .ToList();
                dgv.DataSource = lista;
            }
        }
    }
}
