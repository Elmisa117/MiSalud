using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Configuracion
{
    public partial class FormConfiguracionSistema : Form
    {
        public FormConfiguracionSistema()
        {
            InitializeComponent();
        }

        private void FormConfiguracionSistema_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
        }
    }
}

