using System;
using System.Windows.Forms;

namespace Roles.Admin
{
    public partial class FormAdmin : Form
    {
        private string _usuario;

        public FormAdmin(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            // Muestra el usuario en el título del formulario
            this.Text = $"Panel Administrador - {_usuario}";
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            // Muestra el nombre del usuario en el Label (si lo tienes en el diseñador)
            lblUsuario.Text = $"Bienvenido: {_usuario}";
        }

        private void FormAdmin_Load_1(object sender, EventArgs e)
        {

        }
    }
}


