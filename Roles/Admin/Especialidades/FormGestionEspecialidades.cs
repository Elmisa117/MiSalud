using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;
using Entidades = MiSalud.Entidades;

namespace MiSalud.Roles.Admin.Especialidades
{
    public partial class FormGestionEspecialidades : Form
    {
        private DataGridView dgv;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private CheckBox chkEstado;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private int? idSeleccionado = null;

        public FormGestionEspecialidades()
        {
            InitializeComponent();
        }

        private void FormGestionEspecialidades_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarEspecialidades();
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
            chkEstado = new CheckBox { Text = "Activo", Top = 160, Left = 20 };

            btnGuardar = new Button { Text = "Guardar", Top = 190, Left = 20 };
            btnGuardar.Click += BtnGuardar_Click;
            btnEliminar = new Button { Text = "Eliminar", Top = 190, Left = 120 };
            btnEliminar.Click += BtnEliminar_Click;
            btnLimpiar = new Button { Text = "Limpiar", Top = 190, Left = 220 };
            btnLimpiar.Click += BtnLimpiar_Click;

            Controls.AddRange(new Control[]
            {
                lblNombre, txtNombre, lblDescripcion, txtDescripcion, chkEstado,
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
                    var esp = new Entidades.Especialidad
                    {
                        NombreEspecialidad = txtNombre.Text,
                        Descripcion = txtDescripcion.Text,
                        Estado = chkEstado.Checked,
                        FechaCreacion = DateTime.Now
                    };
                    ctx.Especialidades.Add(esp);
                    ctx.SaveChanges();
                }
                else
                {
                    var esp = ctx.Especialidades.FirstOrDefault(e => e.EspecialidadId == idSeleccionado);
                    if (esp != null)
                    {
                        esp.NombreEspecialidad = txtNombre.Text;
                        esp.Descripcion = txtDescripcion.Text;
                        esp.Estado = chkEstado.Checked;
                        ctx.SaveChanges();
                    }
                }
            }

            Limpiar();
            CargarEspecialidades();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Selecciona un registro de la lista");
                return;
            }

            using (var ctx = new ClinicaContext())
            {
                var esp = ctx.Especialidades.FirstOrDefault(e => e.EspecialidadId == idSeleccionado);
                if (esp != null)
                {
                    ctx.Especialidades.Remove(esp);
                    ctx.SaveChanges();
                }
            }

            Limpiar();
            CargarEspecialidades();
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
                idSeleccionado = Convert.ToInt32(fila.Cells["EspecialidadId"].Value);
                txtNombre.Text = fila.Cells["NombreEspecialidad"].Value?.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value?.ToString();
                chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);
                btnGuardar.Text = "Actualizar";
            }
        }

        private void CargarEspecialidades()
        {
            using (var ctx = new ClinicaContext())
            {
                var lista = ctx.Especialidades
                    .Select(e => new { e.EspecialidadId, e.NombreEspecialidad, e.Descripcion, e.Estado })
                    .ToList();
                dgv.DataSource = lista;
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            chkEstado.Checked = false;
            btnGuardar.Text = "Guardar";
            idSeleccionado = null;
        }
    }
}
