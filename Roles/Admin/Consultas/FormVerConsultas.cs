using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;

namespace MiSalud.Roles.Admin.Consultas
{
    public partial class FormVerConsultas : Form
    {
        private DataGridView dgv;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private ComboBox cbMedico;
        private ComboBox cbPaciente;
        private Button btnFiltrar;

        public FormVerConsultas()
        {
            InitializeComponent();
        }

        private void FormVerConsultas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarListas();
            CargarConsultas();
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

            var lblDesde = new Label { Text = "Desde", Top = 60, Left = 20 };
            dtpDesde = new DateTimePicker { Top = 80, Left = 20, Width = 200 };
            var lblHasta = new Label { Text = "Hasta", Top = 110, Left = 20 };
            dtpHasta = new DateTimePicker { Top = 130, Left = 20, Width = 200 };
            var lblMedico = new Label { Text = "Médico", Top = 160, Left = 20 };
            cbMedico = new ComboBox { Top = 180, Left = 20, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            var lblPaciente = new Label { Text = "Paciente", Top = 210, Left = 20 };
            cbPaciente = new ComboBox { Top = 230, Left = 20, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            btnFiltrar = new Button { Text = "Filtrar", Top = 260, Left = 20 };
            btnFiltrar.Click += BtnFiltrar_Click;

            Controls.AddRange(new Control[]
            {
                lblDesde, dtpDesde, lblHasta, dtpHasta,
                lblMedico, cbMedico, lblPaciente, cbPaciente,
                btnFiltrar, dgv
            });
        }

        private void CargarListas()
        {
            using (var ctx = new ClinicaContext())
            {
                var medicos = ctx.Personal
                    .Where(p => p.Rol == "Doctor" && p.Estado)
                    .Select(p => new { p.PersonalId, Nombre = p.Nombres + " " + p.Apellidos })
                    .ToList();
                medicos.Insert(0, new { PersonalId = 0, Nombre = "Todos" });
                cbMedico.DataSource = medicos;
                cbMedico.DisplayMember = "Nombre";
                cbMedico.ValueMember = "PersonalId";

                var pacientes = ctx.Pacientes
                    .Select(p => new { p.PacienteId, Nombre = p.Nombres + " " + p.Apellidos })
                    .ToList();
                pacientes.Insert(0, new { PacienteId = 0, Nombre = "Todos" });
                cbPaciente.DataSource = pacientes;
                cbPaciente.DisplayMember = "Nombre";
                cbPaciente.ValueMember = "PacienteId";
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CargarConsultas();
        }

        private void CargarConsultas()
        {
            using (var ctx = new ClinicaContext())
            {
                var desde = dtpDesde.Value.Date;
                var hasta = dtpHasta.Value.Date.AddDays(1);
                var query = ctx.Consultas.AsQueryable();

                query = query.Where(c => c.FechaConsulta >= desde && c.FechaConsulta < hasta);

                int idMedico = (int)cbMedico.SelectedValue;
                if (idMedico != 0)
                {
                    query = query.Where(c => c.PersonalId == idMedico);
                }

                int idPaciente = (int)cbPaciente.SelectedValue;
                if (idPaciente != 0)
                {
                    query = query.Where(c => c.PacienteId == idPaciente);
                }

                var lista = query
                    .Select(c => new { c.ConsultaId, c.PacienteId, c.PersonalId, c.FechaConsulta, c.Estado })
                    .ToList();

                dgv.DataSource = lista;
            }
        }
    }
}
