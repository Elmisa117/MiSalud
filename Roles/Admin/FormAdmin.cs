using Login;
using MiSalud; // o la ruta donde tengas tu LoginForm (ajústalo si está en otra carpeta)
using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin
{
    public partial class FormAdmin : Form
    {
        private string usuario; // Para guardar el nombre de usuario

        // Constructor que recibe el usuario
        public FormAdmin(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.FormClosing += FormAdmin_FormClosing;



            // Mostrar nombre del usuario en el título del formulario
            this.Text = "Administrador - " + usuario;
        }

        // Método para cargar formularios hijos dentro del panelContenido
        private void AbrirFormulario(Form formHijo)
        {
            panelContenido.Controls.Clear(); // Borra lo anterior
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formHijo);
            formHijo.Show();
        }


        // EVENTOS DE LOS BOTONES

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new MiSalud.Roles.Admin.Personal.FormGestionPersonal());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Usuarios.FormGestionUsuarios());
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Especialidades.FormGestionEspecialidades());
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Servicios.FormGestionServicios());
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Consultas.FormVerConsultas());
        }

        private void btnHospitalizaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Hospitalizaciones.FormVerHospitalizaciones());
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Facturacion.FormVerFacturas());
        }

        private void btnPlanesPago_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new PlanesPago.FormPlanesPago());
        }

        private void btnFichasClinicas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FichasClinicas.FormVerFichasClinicas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Reportes.FormReportes());
        }

        private void btnAuditoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Auditoria.FormAuditoria());
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new Configuracion.FormConfiguracionSistema());
        }
        
        //Método para cerrar sesión y volver al LoginForm
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar == DialogResult.Yes)
            {
                this.Hide(); // Oculta el formulario actual
                LoginForm login = new LoginForm(); // Asegúrate que tu LoginForm esté accesible desde aquí
                login.Show();
            }
        }
        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas salir del sistema?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancela el cierre
            }
        }



    }
}

