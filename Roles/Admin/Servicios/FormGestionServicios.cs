using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Servicios
{
    public partial class FormGestionServicios : Form
    {
        public FormGestionServicios()
        {
            InitializeComponent();
        }

        private void FormGestionServicios_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
        }
    }
}


