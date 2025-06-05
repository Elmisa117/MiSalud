using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.Facturacion
{
    public partial class FormVerFacturas : Form
    {
        public FormVerFacturas()
        {
            InitializeComponent();
        }

        private void FormVerFacturas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
        }
    }
}

