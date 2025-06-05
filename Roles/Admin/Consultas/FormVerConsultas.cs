using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Consultas
{
    public partial class FormVerConsultas : Form
    {
        public FormVerConsultas()
        {
            InitializeComponent();
        }

        private void FormVerConsultas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
        }
    }
}

