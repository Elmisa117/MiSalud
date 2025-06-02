using System;
using System.Linq;
using System.Windows.Forms;
using MiSalud.Datos; // Asegúrate de que este namespace exista y tenga ClinicaContext
using Login;         // Aquí está SelectorRoles

namespace Login
{
    public partial class LoginForm : Form
    {
        private readonly ClinicaContext _context;

        // Constructor: instancia el contexto
        public LoginForm()
        {
            InitializeComponent();

            // Inicializa el contexto de base de datos (sin opciones avanzadas)
            _context = new ClinicaContext();
        }

        // Evento que se ejecuta al cargar el formulario
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus(); // Enfoca el campo usuario al abrir
        }

        // Evento al hacer clic en el botón de iniciar sesión
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string pass = txtContrasena.Text.Trim();

            // Consulta LINQ para validar credenciales
            var login = _context.Personal
                .FirstOrDefault(p => p.Usuario == user && p.Contrasena == pass && p.Estado == true);

            if (login != null)
            {
                // Abrir menú según rol
                SelectorRoles.AbrirMenuPorRol(login.Rol, login.Nombres);
                this.Hide(); // Ocultar login
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos o cuenta inactiva.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

