using System;
using System.Windows.Forms;

namespace MiSalud.Roles.Admin.FichasClinicas
{
    public partial class FormVerFichasClinicas : Form
    {
        public FormVerFichasClinicas()
        {
            InitializeComponent();
        }

        private void FormVerFichasClinicas_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
        }
    }
}

