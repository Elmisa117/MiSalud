using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;

namespace MiSalud.Roles.Admin.Auditoria
{
    public partial class FormAuditoria : Form
    {
        private DataGridView dgv;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private TextBox txtUsuario;
        private Button btnFiltrar;

        public FormAuditoria()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Load += FormAuditoria_Load;
        }

        private void FormAuditoria_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarAuditoria();
        }

        private void InicializarControles()
        {
            dgv = new DataGridView
            {
                Dock = DockStyle.Bottom,
                Height = 300,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var lblDesde = new Label { Text = "Desde", Top = 60, Left = 20 };
            dtpDesde = new DateTimePicker { Top = 80, Left = 20, Width = 200 };
            var lblHasta = new Label { Text = "Hasta", Top = 110, Left = 20 };
            dtpHasta = new DateTimePicker { Top = 130, Left = 20, Width = 200 };
            var lblUsuario = new Label { Text = "Usuario", Top = 160, Left = 20 };
            txtUsuario = new TextBox { Top = 180, Left = 20, Width = 200 };

            btnFiltrar = new Button { Text = "Filtrar", Top = 210, Left = 20 };
            btnFiltrar.Click += BtnFiltrar_Click;

            Controls.AddRange(new Control[]
            {
                lblDesde, dtpDesde, lblHasta, dtpHasta,
                lblUsuario, txtUsuario, btnFiltrar, dgv
            });
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CargarAuditoria();
        }

        private void CargarAuditoria()
        {
            using var ctx = new ClinicaContext();
            var desde = dtpDesde.Value.Date;
            var hasta = dtpHasta.Value.Date.AddDays(1);
            var query = ctx.Auditoria.AsQueryable();
            query = query.Where(a => a.Fecha >= desde && a.Fecha < hasta);
            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                query = query.Where(a => a.Usuario.Contains(txtUsuario.Text));
            }

            var lista = query
                .OrderByDescending(a => a.Fecha)
                .Select(a => new { a.AuditoriaId, a.Usuario, a.Tabla, a.Accion, a.Detalle, a.Fecha })
                .ToList();

            dgv.DataSource = lista;
        }
    }
}
