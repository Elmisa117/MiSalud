using System;
using System.Windows.Forms;

namespace Roles.Caja
{
    public partial class FormCaja : Form
    {
        private string _usuario;

        public FormCaja(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            this.Text = $"Panel Caja - {_usuario}";
        }
    }
}

