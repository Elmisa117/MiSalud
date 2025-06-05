using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Hospitalizaciones
{
    public partial class FormVerHospitalizaciones : Form
    {
        public FormVerHospitalizaciones()
        {
            InitializeComponent();
        }

        private void FormVerHospitalizaciones_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
        }
    }
}

