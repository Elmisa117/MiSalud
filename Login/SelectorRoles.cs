using System;
using System.Windows.Forms;
using MiSalud.Roles.Admin;
using Roles.Caja;
using Roles.Doctor;
using Roles.Enfermeria;

namespace Login
{
    public class SelectorRoles
    {
        public static string UsuarioActual { get; private set; }

        // Método estático que abre el formulario correspondiente según el rol
        public static void AbrirMenuPorRol(string rol, string usuario)
        {
            UsuarioActual = usuario;
            Form formRol = null;

            switch (rol)
            {
                case "Administrador":
                    formRol = new FormAdmin(usuario);
                    break;
                case "Doctor":
                    formRol = new FormDoctor(usuario);
                    break;
                case "Enfermera":
                    formRol = new FormEnfermeria(usuario);
                    break;
                case "Caja":
                    formRol = new FormCaja(usuario);
                    break;
                default:
                    MessageBox.Show("Rol no reconocido: " + rol);
                    return;
            }

            formRol.Show(); // Mostrar el formulario del rol
        }
    }
}

