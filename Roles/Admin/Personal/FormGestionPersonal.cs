
using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos;                        // Tu DbContext (ClinicaContext)
using Entidades = MiSalud.Entidades;       // Alias para acceder a tus clases del namespace Entidades

namespace MiSalud.Roles.Admin.Personal
{

    public partial class FormGestionPersonal : Form
    {
        private int? idSeleccionado = null;

        // =======================
        // 🔹 CONSTRUCTOR
        // =======================
        public FormGestionPersonal()
        {
            InitializeComponent();

            // Eventos vinculados a botones
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnLimpiar.Click += new EventHandler(btnLimpiar_Click);
        }

        // =======================
        // 🔹 EVENTOS DE FORMULARIO
        // =======================

        // Este evento se dispara cuando se carga el formulario
        private void FormGestionPersonal_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;          // Ocupar todo el espacio del contenedor
            CargarEspecialidades();              // Llenar el ComboBox de especialidades
            CargarPersonal(); // ← mostrar los registros al abrir el formulario
        }
        private void CargarPersonal()
        {
            using (var context = new ClinicaContext())
            {
                var lista = context.Personal
                    .Select(p => new
                    {
                        p.PersonalId,
                        p.Nombres,
                        p.Apellidos,
                        p.TipoDocumento,
                        p.NumeroDocumento,
                        p.Genero,
                        p.Telefono,
                        p.Email,
                        p.Rol,
                        Especialidad = context.Especialidades
                            .Where(e => e.EspecialidadId == p.EspecialidadId)
                            .Select(e => e.NombreEspecialidad)
                            .FirstOrDefault(),
                        p.Estado
                    })
                    .ToList();

                dgvPersonal.DataSource = lista;
            }
        }
        // Evento del DataGridView al hacer doble clic en una fila
        private void dgvPersonal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPersonal.Rows[e.RowIndex];

                // Almacenar el ID
                idSeleccionado = Convert.ToInt32(fila.Cells["PersonalId"].Value);

                // Cargar datos a los controles
                txtNombres.Text = fila.Cells["Nombres"].Value?.ToString();
                txtApellidos.Text = fila.Cells["Apellidos"].Value?.ToString();
                cbTipoDocumento.Text = fila.Cells["TipoDocumento"].Value?.ToString();
                txtDocumento.Text = fila.Cells["NumeroDocumento"].Value?.ToString();
                cbGenero.Text = fila.Cells["Genero"].Value?.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value?.ToString();
                txtEmail.Text = fila.Cells["Email"].Value?.ToString();
                cbRol.Text = fila.Cells["Rol"].Value?.ToString();
                cbEspecialidad.Text = fila.Cells["Especialidad"].Value?.ToString(); // Asigna por nombre

                // Cambia el texto del botón
                btnGuardar.Text = "Actualizar";
            }
        }


        // Evento del botón LIMPIAR
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // Evento del botón GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // =======================
            // 🔸 VALIDACIONES
            // =======================
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Por favor, ingresa los nombres.");
                txtNombres.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Por favor, ingresa los apellidos.");
                txtApellidos.Focus();
                return;
            }

            if (cbTipoDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el tipo de documento.");
                cbTipoDocumento.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("Ingresa el número de documento.");
                txtDocumento.Focus();
                return;
            }

            if (cbGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el género.");
                cbGenero.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El campo 'Usuario' es obligatorio.");
                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("El campo 'Contraseña' es obligatorio.");
                txtContrasena.Focus();
                return;
            }

            if (cbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el rol.");
                cbRol.Focus();
                return;
            }

            if (cbEspecialidad.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona la especialidad.");
                cbEspecialidad.Focus();
                return;
            }

            // =======================
            // 🔸 GUARDADO EN BASE DE DATOS
            // =======================
            try
            {
                using (var context = new ClinicaContext())
                {
                    // Si es NUEVO registro
                    if (idSeleccionado == null)
                    {
                        var nuevo = new Entidades.Personal
                        {
                            Nombres = txtNombres.Text,
                            Apellidos = txtApellidos.Text,
                            TipoDocumento = cbTipoDocumento.Text,
                            NumeroDocumento = txtDocumento.Text,
                            Genero = cbGenero.Text,
                            FechaNacimiento = dtpNacimiento.Value,
                            Direccion = txtDireccion.Text,
                            Telefono = txtTelefono.Text,
                            Email = txtEmail.Text,
                            FechaIngreso = dtpIngreso.Value,
                            Rol = cbRol.Text,
                            EspecialidadId = Convert.ToInt32(cbEspecialidad.SelectedValue),
                            Usuario = txtUsuario.Text,
                            Contrasena = txtContrasena.Text,
                            FechaCreacion = dtpCreacion.Value,
                            Estado = chkEstado.Checked
                        };

                        context.Personal.Add(nuevo);
                        context.SaveChanges();
                        MessageBox.Show("✅ Registro guardado correctamente.");
                    }
                    else
                    {
                        // Si es ACTUALIZACIÓN de un registro existente
                        var personal = context.Personal.FirstOrDefault(p => p.PersonalId == idSeleccionado);

                        if (personal != null)
                        {
                            personal.Nombres = txtNombres.Text;
                            personal.Apellidos = txtApellidos.Text;
                            personal.TipoDocumento = cbTipoDocumento.Text;
                            personal.NumeroDocumento = txtDocumento.Text;
                            personal.Genero = cbGenero.Text;
                            personal.FechaNacimiento = dtpNacimiento.Value;
                            personal.Direccion = txtDireccion.Text;
                            personal.Telefono = txtTelefono.Text;
                            personal.Email = txtEmail.Text;
                            personal.FechaIngreso = dtpIngreso.Value;
                            personal.Rol = cbRol.Text;
                            personal.EspecialidadId = Convert.ToInt32(cbEspecialidad.SelectedValue);
                            personal.Usuario = txtUsuario.Text;
                            personal.Contrasena = txtContrasena.Text;
                            personal.FechaCreacion = dtpCreacion.Value;
                            personal.Estado = chkEstado.Checked;

                            context.SaveChanges();
                            MessageBox.Show("✅ Registro actualizado correctamente.");
                        }
                    }

                    // Común a ambas acciones (nuevo o editar)
                    LimpiarFormulario();
                    CargarPersonal();
                    btnGuardar.Text = "Guardar";
                    idSeleccionado = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al guardar: " + ex.Message);
            }

        }
        // Evento del botón EDITAR (actualizar registro seleccionado)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == null)
            {
                MessageBox.Show("Selecciona un registro del listado para eliminar (doble clic).");
                return;
            }

            var confirmar = MessageBox.Show("¿Estás seguro de que deseas eliminar este registro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    using (var context = new ClinicaContext())
                    {
                        var persona = context.Personal.FirstOrDefault(p => p.PersonalId == idSeleccionado);
                        if (persona != null)
                        {
                            context.Personal.Remove(persona);
                            context.SaveChanges();
                            MessageBox.Show("✅ Registro eliminado correctamente.");
                        }
                    }

                    LimpiarFormulario();
                    CargarPersonal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error al eliminar: " + ex.Message);
                }
            }
        }


        // =======================
        // 🔹 MÉTODOS AUXILIARES
        // =======================

        // Este método limpia todos los campos del formulario
        private void LimpiarFormulario()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            cbTipoDocumento.SelectedIndex = -1;
            txtDocumento.Text = "";
            cbGenero.SelectedIndex = -1;
            dtpNacimiento.Value = DateTime.Today;
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            dtpIngreso.Value = DateTime.Today;
            cbRol.SelectedIndex = -1;
            cbEspecialidad.SelectedIndex = -1;
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            dtpCreacion.Value = DateTime.Today;
            chkEstado.Checked = false;
            btnGuardar.Text = "Guardar";
            idSeleccionado = null;

        }

        // Este método carga todas las especialidades activas en el ComboBox
        private void CargarEspecialidades()
        {
            using (var context = new ClinicaContext())
            {
                var lista = context.Especialidades
                    .Where(e => e.Estado) // solo los que están activos
                    .Select(e => new
                    {
                        e.EspecialidadId,
                        Nombre = e.NombreEspecialidad
                    })
                    .ToList();

                cbEspecialidad.DataSource = lista;
                cbEspecialidad.DisplayMember = "Nombre";
                cbEspecialidad.ValueMember = "EspecialidadId";
            }
        }
    }
}
