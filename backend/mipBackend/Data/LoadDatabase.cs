﻿using Microsoft.AspNetCore.Identity;
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
                    Email = "s.gonzalez@atomos.cl",
                    UserName = "s.gonzalez@atomos.cl",
                };

                await usuarioManager.CreateAsync(usuario, "Sam20211.2021");

            }

            if (!context.Roles!.Any())
            {
                context.Roles!.AddRange(
                    new Rol
                    {
                        Name = "Administrador full",
                    },
                    new Rol
                    {
                        Name = "Administrador Operacional",
                    },
                    new Rol
                    {
                        Name = "Administrador Clientes",
                    },
                    new Rol
                    {
                        Name = "Operador",
                    },
                    new Rol
                    {
                        Name = "Usuario",
                    },
                    new Rol
                    {
                        Name = "Sag",
                    },
                    new Rol
                    {
                        Name = "Visitante",
                    }
                );
            }

            if (!context.Prf03Plantillas!.Any())
            {
                context.Prf03Plantillas!.AddRange(
                    new Prf03Plantilla
                    {
                        prf03nombre = "Administrador Full",
                        prf03descripcion = "plantilla con todos los permisos habilitados"
                    },
                    new Prf03Plantilla
                    {
                        prf03nombre = "Administrador Operacional",
                        prf03descripcion = "administrador para el manejo de datos asociados a las trampas y monitoreos"
                    },
                    new Prf03Plantilla
                    {
                        prf03nombre = "Administrador Clientes",
                        prf03descripcion = "administrador para el manejo de datos asociados a las trampas y monitoreos"
                    },
                    new Prf03Plantilla
                    {
                        prf03nombre = "Usuario",
                        prf03descripcion = "plantilla para usuarios visualiza la opciones adquiridas"
                    },
                    new Prf03Plantilla
                    {
                        prf03nombre = "Operador",
                        prf03descripcion = "esta plantilla asiga a los operadortes las opciones de vizualizar contenido y bloquea el ingreso, edicion o eliminacion de datos"
                    },
                    new Prf03Plantilla
                    {
                        prf03nombre = "Syngenta",
                        prf03descripcion = "perfil utilizado para usuarios syngenta"
                    },
                    new Prf03Plantilla
                    {
                        prf03nombre = "Invitado",
                        prf03descripcion = "plantilla con opciones para adquirir licencias"
                    }
                );
            }



            if (!context.Wkf02TipoFlujos!.Any())
            {
                context.Wkf02TipoFlujos!.AddRange(
                    new Wkf02TipoFlujo
                    {
                        wkf02nombre = "Flujo Principal",
                        wkf02descripcion = "flujo principal",
                        wkf02activo = 1
                    }
                );
            }

            context.SaveChanges();

            if (!context.Wkf03Niveles!.Any())
            {
                context.Wkf03Niveles!.AddRange(
                    new Wkf03Nivel
                    {
                        wkf02llave = 1,
                        wkf03nombre = "Raiz",
                        wkf03descripcion = "Primer nivel del flujo, es el flujo mas bajo todo parte de aqui",
                        wkf03activo = 1,
                        wkf03nivel1 = 1
                    },
                    new Wkf03Nivel
                    {
                        wkf02llave = 1,
                        wkf03nombre = "Modulo",
                        wkf03descripcion = "despues de la raiz es la unidad mas grande, ejemplo modulo de clientes que agrupa todas las opciones asociaas a clientes",
                        wkf03activo = 1,
                        wkf03nivel1 = 2
                    },
                    new Wkf03Nivel
                    {
                        wkf02llave = 1,
                        wkf03nombre = "Item",
                        wkf03descripcion = "el item es la continuacion del modulo pero mas pequeño, ejemplo informacion general de cliente",
                        wkf03activo = 1,
                        wkf03nivel1 = 3
                    },
                    new Wkf03Nivel
                    {
                        wkf02llave = 1,
                        wkf03nombre = "Pagina Web",
                        wkf03descripcion = "LA pagina web es lo mas pequeño, ejemplo Nueva informacion de cliente, editar, listar",
                        wkf03activo = 1,
                        wkf03nivel1 = 4
                    }
                );
            }

            context.SaveChanges();

            if (!context.Wkf05TipoPermisos!.Any())
            {
                context.Wkf05TipoPermisos!.AddRange(
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "vizualizar",
                        wkf05descripcion = "vizualizar elementos, modulos, items, contenido",
                        wkf05sigla = "V",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "Listar",
                        wkf05descripcion = "habilita las opciones de listar contenido",
                        wkf05sigla = "L",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "Crear",
                        wkf05descripcion = "habilita las opciones de crear contenido",
                        wkf05sigla = "C",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "Modificar",
                        wkf05descripcion = "habilita las opciones de modificar o editar contenido",
                        wkf05sigla = "M",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "Eliminar",
                        wkf05descripcion = "habilita las opciones de Desabilitar o eliminar contenido",
                        wkf05sigla = "D",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "habilitar",
                        wkf05descripcion = "habilita las opciones de importar contenido",
                        wkf05sigla = "A",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "Buscar",
                        wkf05descripcion = "habilita las opciones del buscador",
                        wkf05sigla = "F",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "Exportar",
                        wkf05descripcion = "habilita las opciones del exportar contenido",
                        wkf05sigla = "E",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "Importar",
                        wkf05descripcion = "habilita las opciones de importar contenido",
                        wkf05sigla = "I",
                        wkf05activo = 1,
                    },
                    new Wkf05TipoPermiso
                    {
                        wkf05nombre = "Enviar por e-Mail",
                        wkf05descripcion = "habilita las opciones de enviar contenido por e-mail",
                        wkf05sigla = "S",
                        wkf05activo = 1,
                    }

                );
            }

            context.SaveChanges();

            if (!context.Per08TipoDocumentos!.Any())
            {
                context.Per08TipoDocumentos!.AddRange(
                    new Per08TipoDocumento
                    {
                        per08nombre = "Rut",
                        per08descripcion = "Personas con nacionalidad chilena o residencia permanente",
                        per08activo = 1,
                    },
                    new Per08TipoDocumento
                    {
                        per08nombre = "DNI",
                        per08descripcion = "Personas Con nacionalidad extranjera sin rut",
                        per08activo = 1,
                    },
                    new Per08TipoDocumento
                    {
                        per08nombre = "Numero pasaporte",
                        per08descripcion = "Personas con extranjeras que no tienen DNI",
                        per08activo = 1,
                    }
                );
            }

            context.SaveChanges();

            if (!context.Wkf10TipoParametros!.Any())
            {
                context.Wkf10TipoParametros!.AddRange(
                    new Wkf10TipoParametro
                    {
                        wkf10nombre = "cookie",
                        wkf10descripcion = "acciones sobre cookies",
                        wkf10activo = 1,
                    },
                    new Wkf10TipoParametro
                    {
                        wkf10nombre = "control",
                        wkf10descripcion = "acciones sobre controles de formularios",
                        wkf10activo = 1,
                    },
                    new Wkf10TipoParametro
                    {
                        wkf10nombre = "form",
                        wkf10descripcion = "acciones sobre controles de envios de post o request de formularios",
                        wkf10activo = 1,
                    },
                    new Wkf10TipoParametro
                    {
                        wkf10nombre = "profile",
                        wkf10descripcion = "acciones sobre profiles",
                        wkf10activo = 1,
                    },
                    new Wkf10TipoParametro
                    {
                        wkf10nombre = "querystring",
                        wkf10descripcion = "acciones sobre querystring",
                        wkf10activo = 1,
                    },
                    new Wkf10TipoParametro
                    {
                        wkf10nombre = "sesion",
                        wkf10descripcion = "acciones sobre sesion",
                        wkf10activo = 1,
                    },
                    new Wkf10TipoParametro
                    {
                        wkf10nombre = "routerdata",
                        wkf10descripcion = "acciones sobre routerdata",
                        wkf10activo = 1,
                    }
                );
            }

            context.SaveChanges();

            if (!context.Wkf04NivelPermisos!.Any())
            {
                context.Wkf04NivelPermisos!.AddRange(
                    new Wkf04NivelPermiso   
                    {
                        wkf03llave = 1,
                        wkf05llave= 1,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 2,
                        wkf05llave = 1,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 3,
                        wkf05llave = 1,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 1,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 2,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 3,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 4,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 5,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 6,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 7,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 8,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 9,
                        wkf04activo = 1
                    },
                    new Wkf04NivelPermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 10,
                        wkf04activo = 1
                    }
                );
            }


            context.SaveChanges();
        }
    }
}
