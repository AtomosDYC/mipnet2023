using Microsoft.AspNetCore.Identity;
using mipBackend.Models;

namespace mipBackend.Data
{
    public class LoadDatabase
    {
        public static async Task InsertarDatos(AppDbContext context, UserManager<Usuario> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new Usuario
                {

                    Nombre = "administrador",
                    apellido = " mipnet ",
                    Email = "s.gonzalez@atomos.cl",
                    UserName = "s.gonzalez@atomos.cl",
                    Telefono = "987247981"
                };

                await usuarioManager.CreateAsync(usuario, "Sam20211.2021");

            }

            if (!context.Inmuebles!.Any())
            {
                context.Inmuebles!.AddRange(
                    new Inmueble
                    {
                        Nombre = "casa de playa",
                        Direccion = " sin informacion ",
                        Precio = 400M,
                        FechaCreacion = DateTime.Now
                    },
                    new Inmueble
                    {
                        Nombre = "casa de invierno",
                        Direccion = " sin informacion ",
                        Precio = 5500M,
                        FechaCreacion = DateTime.Now
                    }
                );
            };

            context.SaveChanges();
        }
    }
}
