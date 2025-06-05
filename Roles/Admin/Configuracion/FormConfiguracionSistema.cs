using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace MiSalud.Roles.Admin.Configuracion
{
    public partial class FormConfiguracionSistema : Form
    {
        private Button btnBackup;

        public FormConfiguracionSistema()
        {
            InitializeComponent();
        }

        private void FormConfiguracionSistema_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
            this.Dock = DockStyle.Fill;
            btnBackup = new Button { Text = "Realizar Backup", Top = 60, Left = 20 };
            btnBackup.Click += BtnBackup_Click;
            Controls.Add(btnBackup);
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            using (var ctx = new Datos.ClinicaContext())
            {
                var connection = ctx.Database.GetConnectionString();
                try
                {
                    string file = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "pg_dump",
                        Arguments = $"--file \"{file}\" \"{connection}\"",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false
                    };
                    var process = System.Diagnostics.Process.Start(psi);
                    process.WaitForExit();
                    MessageBox.Show($"Backup generado: {file}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar backup: {ex.Message}");
                }
            }
        }
    }
}
