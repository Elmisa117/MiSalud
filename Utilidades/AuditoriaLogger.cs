using System;
using MiSalud.Datos;
using MiSalud.Entidades;

namespace MiSalud.Utilidades
{
    public static class AuditoriaLogger
    {
        public static void Registrar(string usuario, string tabla, string accion, string detalle)
        {
            try
            {
                using var ctx = new ClinicaContext();
                var registro = new Auditoria
                {
                    Usuario = usuario,
                    Tabla = tabla,
                    Accion = accion,
                    Detalle = detalle,
                    Fecha = DateTime.Now
                };
                ctx.Auditoria.Add(registro);
                ctx.SaveChanges();
            }
            catch
            {
                // en escenarios de auditoría, nunca se debe lanzar excepción al usuario
            }
        }
    }
}
