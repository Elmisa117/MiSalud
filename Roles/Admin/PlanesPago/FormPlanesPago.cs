using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.PlanesPago
{
    public partial class FormPlanesPago : Form
    {
        public FormPlanesPago()
        {
            InitializeComponent();
        }

        private void FormPlanesPago_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
        }
    }
}

