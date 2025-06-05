using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;

namespace MiSalud.Roles.Admin.Facturacion
{
    public partial class FormVerFacturas : Form
    {
        private DataGridView dgv;
        private ComboBox cbEstado;
        private Button btnAnular;

        public FormVerFacturas()
        {
            InitializeComponent();
        }

        private void FormVerFacturas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarFacturas();
        }

        private void InicializarControles()
        {
            dgv = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Height = 250,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var lblEstado = new Label { Text = "Estado", Top = 60, Left = 20 };
            cbEstado = new ComboBox { Top = 80, Left = 20, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "Pagado", "Anulado" });
            cbEstado.SelectedIndex = 0;

            btnAnular = new Button { Text = "Anular Seleccionada", Top = 110, Left = 20 };
            btnAnular.Click += BtnAnular_Click;

            Controls.AddRange(new Control[] { lblEstado, cbEstado, btnAnular, dgv });
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
                return;

            int id = Convert.ToInt32(dgv.CurrentRow.Cells["FacturaId"].Value);
            using (var ctx = new ClinicaContext())
            {
                var fac = ctx.Facturas.FirstOrDefault(f => f.FacturaId == id);
                if (fac != null && fac.Estado != "Anulado")
                {
                    fac.Estado = "Anulado";
                    ctx.SaveChanges();
                    CargarFacturas();
                }
            }
        }

        private void CargarFacturas()
        {
            using (var ctx = new ClinicaContext())
            {
                var query = ctx.Facturas.AsQueryable();
                if (cbEstado.SelectedIndex > 0)
                {
                    string estado = cbEstado.SelectedItem.ToString();
                    query = query.Where(f => f.Estado == estado);
                }

                var lista = query
                    .Select(f => new { f.FacturaId, f.NumeroFactura, f.PacienteId, f.Total, f.Estado })
                    .ToList();
                dgv.DataSource = lista;
            }
        }
    }
}
