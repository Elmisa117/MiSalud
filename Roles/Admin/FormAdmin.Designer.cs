namespace Roles.Admin
{
    partial class FormAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsuario;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUsuario = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblUsuario.Location = new System.Drawing.Point(12, 9);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new System.Drawing.Size(136, 19);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Bienvenido: Admin";
            // 
            // FormAdmin
            // 
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(lblUsuario);
            Name = "FormAdmin";
            Text = "Panel Administrador";
            Load += FormAdmin_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
