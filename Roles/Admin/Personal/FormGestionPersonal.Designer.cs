using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Personal
{
    partial class FormGestionPersonal
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelTitulo;
        private TabControl tabControl;
        private TabPage tabDatosPersonales;
        private TabPage tabAccesoAsignacion;
        private DataGridView dgvPersonal;

        private TextBox txtNombres, txtApellidos, txtDocumento, txtDireccion, txtTelefono, txtEmail;
        private ComboBox cbTipoDocumento, cbGenero;
        private DateTimePicker dtpNacimiento;

        private DateTimePicker dtpIngreso, dtpCreacion;
        private ComboBox cbRol, cbEspecialidad;
        private TextBox txtUsuario, txtContrasena;
        private CheckBox chkEstado;
        private Button btnGuardar, btnEditar, btnEliminar, btnLimpiar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Título
            labelTitulo = new Label();
            labelTitulo.Text = "GESTIÓN DE PERSONAL";
            labelTitulo.Dock = DockStyle.Top;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitulo.ForeColor = Color.FromArgb(30, 60, 114);
            labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
            labelTitulo.Height = 50;

            // TabControl
            tabControl = new TabControl();
            tabControl.Dock = DockStyle.Left;
            tabControl.Width = 450;

            // Tabs
            tabDatosPersonales = new TabPage("Datos Personales");
            tabAccesoAsignacion = new TabPage("Acceso y Asignación");

            tabControl.TabPages.Add(tabDatosPersonales);
            tabControl.TabPages.Add(tabAccesoAsignacion);

            // ==== TAB 1: Datos Personales ====
            int y = 20;
            Label L(string text) => new Label()
            {
                Text = text,
                Location = new Point(20, y),
                Width = 350,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };

            Control C(Control control)
            {
                control.Location = new Point(20, y += 20);
                control.Width = 350;
                y += 40;
                return control;
            }

            cbTipoDocumento = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbTipoDocumento.Items.AddRange(new object[] { "CI", "Pasaporte" });

            cbGenero = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbGenero.Items.AddRange(new object[] { "Masculino", "Femenino" });

            tabDatosPersonales.Controls.AddRange(new Control[]
            {
                L("Nombres:"), C(txtNombres = new TextBox()),
                L("Apellidos:"), C(txtApellidos = new TextBox()),
                L("Tipo de Documento:"), C(cbTipoDocumento),
                L("Número de Documento:"), C(txtDocumento = new TextBox()),
                L("Género:"), C(cbGenero),
                L("Fecha de Nacimiento:"), C(dtpNacimiento = new DateTimePicker { Format = DateTimePickerFormat.Short }),
                L("Dirección:"), C(txtDireccion = new TextBox()),
                L("Teléfono:"), C(txtTelefono = new TextBox()),
                L("Email:"), C(txtEmail = new TextBox())
            });

            // ==== TAB 2: Acceso y Asignación ====
            y = 20;
            cbRol = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            cbRol.Items.AddRange(new object[] { "Administrador", "Doctor", "Enfermera", "Caja" });

            cbEspecialidad = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

            dtpIngreso = new DateTimePicker { Format = DateTimePickerFormat.Short };
            dtpCreacion = new DateTimePicker { Format = DateTimePickerFormat.Short };

            txtUsuario = new TextBox();
            txtContrasena = new TextBox { UseSystemPasswordChar = true };
            chkEstado = new CheckBox { Text = "Activo" };

            btnGuardar = new Button() { Text = "Guardar", Width = 100 };
            btnEditar = new Button() { Text = "Editar", Width = 100 }; // No tiene evento
            btnEliminar = new Button() { Text = "Eliminar", Width = 100 };
            btnLimpiar = new Button() { Text = "Limpiar", Width = 320 };

            // Posicionar botones
            btnGuardar.Location = new Point(20, y += 20);
            btnEditar.Location = new Point(130, y);
            btnEliminar.Location = new Point(240, y);
            y += 40;
            btnLimpiar.Location = new Point(20, y += 20);

            // Asociar eventos (solo los activos)
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            // btnEditar.Click += new EventHandler(btnEditar_Click); ← desactivado
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            btnLimpiar.Click += new EventHandler(btnLimpiar_Click);

            tabAccesoAsignacion.Controls.AddRange(new Control[]
            {
                L("Fecha de Ingreso:"), C(dtpIngreso),
                L("Rol:"), C(cbRol),
                L("Especialidad:"), C(cbEspecialidad),
                L("Usuario:"), C(txtUsuario),
                L("Contraseña:"), C(txtContrasena),
                L("Fecha de Creación:"), C(dtpCreacion),
                L("Estado:"), chkEstado,
                btnGuardar, btnEditar, btnEliminar, btnLimpiar
            });

            // Tabla de personal
            dgvPersonal = new DataGridView();
            dgvPersonal.Dock = DockStyle.Fill;
            dgvPersonal.BackgroundColor = Color.White;
            dgvPersonal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonal.RowHeadersVisible = false;
            dgvPersonal.AutoGenerateColumns = true; // ✅ Permitir que se muestren las columnas automáticamente
            dgvPersonal.CellDoubleClick += new DataGridViewCellEventHandler(dgvPersonal_CellDoubleClick);

            // Agregar controles al formulario
            this.Controls.Add(dgvPersonal);
            this.Controls.Add(tabControl);
            this.Controls.Add(labelTitulo);

            // Propiedades generales del formulario
            this.ClientSize = new Size(1100, 600);
            this.FormBorderStyle = FormBorderStyle.None;
            this.ResumeLayout(false);
        }
    }
}
