using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;

namespace MiSalud.Roles.Admin.PlanesPago
{
    public partial class FormPlanesPago : Form
    {
        private DataGridView dgv;

        public FormPlanesPago()
        {
            InitializeComponent();
        }

        private void FormPlanesPago_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarPlanes();
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

        private void CargarPlanes()
        {
            using (var ctx = new ClinicaContext())
            {
                var lista = ctx.PlanesPago
                    .Select(p => new { p.PlanPagoId, p.FacturaId, p.MontoTotal = p.MontoTotal, p.Estado })
                    .ToList();
                dgv.DataSource = lista;
            }
        }
    }
}
