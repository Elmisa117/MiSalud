using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Especialidades
{
    public partial class FormGestionEspecialidades : Form
    {
        public FormGestionEspecialidades()
        {
            InitializeComponent();
        }

        private void FormGestionEspecialidades_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
        }
    }
}

