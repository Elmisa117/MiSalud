using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;
using Entidades = MiSalud.Entidades;

namespace MiSalud.Roles.Admin.Servicios
{
    public partial class FormGestionServicios : Form
    {
        private DataGridView dgv;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private NumericUpDown numCosto;
        private CheckBox chkRequiere;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private int? idSeleccionado = null;

        public FormGestionServicios()
        {
            InitializeComponent();
        }

        private void FormGestionServicios_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarServicios();
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
            dgv.CellDoubleClick += Dgv_CellDoubleClick;

            var lblNombre = new Label { Text = "Nombre", Top = 60, Left = 20 };
            txtNombre = new TextBox { Top = 80, Left = 20, Width = 200 };
            var lblDescripcion = new Label { Text = "Descripción", Top = 110, Left = 20 };
            txtDescripcion = new TextBox { Top = 130, Left = 20, Width = 300 };
            var lblCosto = new Label { Text = "Costo", Top = 160, Left = 20 };
            numCosto = new NumericUpDown { Top = 180, Left = 20, Width = 100, DecimalPlaces = 2, Maximum = 10000 };
            chkRequiere = new CheckBox { Text = "Requiere prescripción", Top = 210, Left = 20 };

            btnGuardar = new Button { Text = "Guardar", Top = 240, Left = 20 };
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar = new Button { Text = "Eliminar", Top = 240, Left = 120 };
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar = new Button { Text = "Limpiar", Top = 240, Left = 220 };
            btnLimpiar.Click += BtnLimpiar_Click;

            Controls.AddRange(new Control[]
            {
                lblNombre, txtNombre, lblDescripcion, txtDescripcion,
                lblCosto, numCosto, chkRequiere,
                btnGuardar, btnEliminar, btnLimpiar, dgv
            });
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                return;
            }

            using (var ctx = new ClinicaContext())
            {
                if (idSeleccionado == null)
                {
                    var s = new Entidades.Servicio
                    {
                        Nombre = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        Costo = numCosto.Value,
                        RequierePrescripcion = chkRequiere.Checked,
                        FechaCreacion = DateTime.Now,
                        Estado = true
                    };
                    ctx.Servicios.Add(s);
                    ctx.SaveChanges();
                }
                else
                {
                    var serv = ctx.Servicios.FirstOrDefault(x => x.ServicioId == idSeleccionado);
                    if (serv != null)
                    {
                        serv.Nombre = txtNombre.Text;
                        serv.Descripcion = txtDescripcion.Text;
                        serv.Costo = numCosto.Value;
                        serv.RequierePrescripcion = chkRequiere.Checked;
                        ctx.SaveChanges();
                    }
                }
            }

            Limpiar();
            CargarServicios();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Selecciona un registro");
                return;
            }

            using (var ctx = new ClinicaContext())
            {
                var serv = ctx.Servicios.FirstOrDefault(x => x.ServicioId == idSeleccionado);
                if (serv != null)
                {
                    ctx.Servicios.Remove(serv);
                    ctx.SaveChanges();
                }
            }

            Limpiar();
            CargarServicios();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgv.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["ServicioId"].Value);
                txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
                numCosto.Value = Convert.ToDecimal(fila.Cells["Costo"].Value);
                chkRequiere.Checked = Convert.ToBoolean(fila.Cells["RequierePrescripcion"].Value);
                btnGuardar.Text = "Actualizar";
            }
        }

        private void CargarServicios()
        {
            using (var ctx = new ClinicaContext())
            {
                var lista = ctx.Servicios
                    .Select(s => new { s.ServicioId, s.Nombre, s.Descripcion, s.Costo, s.RequierePrescripcion })
                    .ToList();
                dgv.DataSource = lista;
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            numCosto.Value = 0;
            chkRequiere.Checked = false;
            btnGuardar.Text = "Guardar";
            idSeleccionado = null;
        }
    }
}
