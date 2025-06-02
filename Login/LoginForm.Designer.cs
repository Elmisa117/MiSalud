namespace Login
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(50, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(280, 40);
            this.lblTitulo.Text = "Iniciar Sesión";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblUsuario
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Location = new System.Drawing.Point(50, 80);
            this.lblUsuario.Size = new System.Drawing.Size(100, 23);

            // txtUsuario
            this.txtUsuario.Location = new System.Drawing.Point(150, 80);
            this.txtUsuario.Size = new System.Drawing.Size(180, 23);
            this.txtUsuario.Name = "txtUsuario";

            // lblContrasena
            this.lblContrasena.Text = "Contraseña:";
            this.lblContrasena.Location = new System.Drawing.Point(50, 120);
            this.lblContrasena.Size = new System.Drawing.Size(100, 23);

            // txtContrasena
            this.txtContrasena.Location = new System.Drawing.Point(150, 120);
            this.txtContrasena.Size = new System.Drawing.Size(180, 23);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.UseSystemPasswordChar = true;

            // btnLogin
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.Location = new System.Drawing.Point(130, 170);
            this.btnLogin.Size = new System.Drawing.Size(120, 30);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.AcceptButton = this.btnLogin;
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "LoginForm";
            this.Text = "Acceso al Sistema";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
