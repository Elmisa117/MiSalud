using System;
using System.Windows.Forms;

namespace Roles.Enfermeria
{
    public partial class FormEnfermeria : Form
    {
        private string _usuario;

        public FormEnfermeria(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.Text = $"Panel Enfermería - {_usuario}";
        }
    }
}

