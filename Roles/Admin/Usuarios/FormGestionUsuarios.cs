using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;
using MiSalud.Utilidades;

namespace MiSalud.Roles.Admin.Usuarios
{
    public partial class FormGestionUsuarios : Form
    {
        private DataGridView dgv;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private ComboBox cbRol;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private int? idSeleccionado = null;

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            InicializarControles();
            CargarUsuarios();
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

            var lblUsuario = new Label { Text = "Usuario", Top = 60, Left = 20 };
            txtUsuario = new TextBox { Top = 80, Left = 20, Width = 200, ReadOnly = true };
            var lblContrasena = new Label { Text = "Nueva contraseña", Top = 110, Left = 20 };
            txtContrasena = new TextBox { Top = 130, Left = 20, Width = 200 };
            var lblRol = new Label { Text = "Rol", Top = 160, Left = 20 };
            cbRol = new ComboBox { Top = 180, Left = 20, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbRol.Items.AddRange(new object[] { "Administrador", "Doctor", "Enfermería", "Caja" });
            chkActivo = new CheckBox { Text = "Activo", Top = 210, Left = 20 };

            btnGuardar = new Button { Text = "Guardar", Top = 240, Left = 20 };
            btnGuardar.Click += BtnGuardar_Click;

            Controls.AddRange(new Control[]
            {
                lblUsuario, txtUsuario, lblContrasena, txtContrasena,
                lblRol, cbRol, chkActivo, btnGuardar, dgv
            });
        }

        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgv.Rows[e.RowIndex];
                idSeleccionado = Convert.ToInt32(fila.Cells["PersonalId"].Value);
                txtUsuario.Text = fila.Cells["Usuario"].Value.ToString();
                cbRol.SelectedItem = fila.Cells["Rol"].Value.ToString();
                chkActivo.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);
                txtContrasena.Text = string.Empty;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Selecciona un usuario de la lista");
                return;
            }

            using (var ctx = new ClinicaContext())
            {
                var usuario = ctx.Personal.FirstOrDefault(p => p.PersonalId == idSeleccionado);
                if (usuario != null)
                {
                    if (!string.IsNullOrWhiteSpace(txtContrasena.Text))
                    {
                        usuario.Contrasena = Seguridad.HashPassword(txtContrasena.Text);
                    }
                    if (cbRol.SelectedItem != null)
                        usuario.Rol = cbRol.SelectedItem.ToString();
                    usuario.Estado = chkActivo.Checked;
                    ctx.SaveChanges();
                }
            }

            txtContrasena.Text = string.Empty;
            idSeleccionado = null;
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            using (var ctx = new ClinicaContext())
            {
                var lista = ctx.Personal
                    .Select(p => new { p.PersonalId, p.Usuario, p.Rol, p.Estado })
                    .ToList();
                dgv.DataSource = lista;
            }
        }
    }
}
