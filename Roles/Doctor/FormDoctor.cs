using System;
using System.Windows.Forms;

namespace Roles.Doctor
{
    public partial class FormDoctor : Form
    {
        private string _usuario;

        public FormDoctor(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.Text = $"Panel Doctor - {_usuario}";
        }
    }
}

