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

            if (!context.prf03Plantillas!.Any())
            {
                context.prf03Plantillas!.AddRange(
                    new prf03Plantilla
                    {
                        prf03nombre = "Administrador Full",
                        prf03descripcion = "plantilla con todos los permisos habilitados"
                    },
                    new prf03Plantilla
                    {
                        prf03nombre = "Administrador Operacional",
                        prf03descripcion = "administrador para el manejo de datos asociados a las trampas y monitoreos"
                    },
                    new prf03Plantilla
                    {
                        prf03nombre = "Administrador Clientes",
                        prf03descripcion = "administrador para el manejo de datos asociados a las trampas y monitoreos"
                    },
                    new prf03Plantilla
                    {
                        prf03nombre = "Usuario",
                        prf03descripcion = "plantilla para usuarios visualiza la opciones adquiridas"
                    },
                    new prf03Plantilla
                    {
                        prf03nombre = "Operador",
                        prf03descripcion = "esta plantilla asiga a los operadortes las opciones de vizualizar contenido y bloquea el ingreso, edicion o eliminacion de datos"
                    },
                    new prf03Plantilla
                    {
                        prf03nombre = "Syngenta",
                        prf03descripcion = "perfil utilizado para usuarios syngenta"
                    },
                    new prf03Plantilla
                    {
                        prf03nombre = "Invitado",
                        prf03descripcion = "plantilla con opciones para adquirir licencias"
                    }
                );
            }



            if (!context.wkf02TipoFlujos!.Any())
            {
                context.wkf02TipoFlujos!.AddRange(
                    new wkf02TipoFlujo
                    {
                        wkf02nombre = "Flujo Principal",
                        wkf02descripcion = "flujo principal",
                        wkf02activo = 1
                    }
                );
            }

            context.SaveChanges();

            if (!context.wkf03Niveles!.Any())
            {
                context.wkf03Niveles!.AddRange(
                    new wkf03Nivel
                    {
                        wkf02llave = 1,
                        wkf03nombre = "Raiz",
                        wkf03descripcion = "Primer nivel del flujo, es el flujo mas bajo todo parte de aqui",
                        wkf03activo = 1,
                        wkf03nivel1 = 1
                    },
                    new wkf03Nivel
                    {
                        wkf02llave = 1,
                        wkf03nombre = "Modulo",
                        wkf03descripcion = "despues de la raiz es la unidad mas grande, ejemplo modulo de clientes que agrupa todas las opciones asociaas a clientes",
                        wkf03activo = 1,
                        wkf03nivel1 = 2
                    },
                    new wkf03Nivel
                    {
                        wkf02llave = 1,
                        wkf03nombre = "Item",
                        wkf03descripcion = "el item es la continuacion del modulo pero mas pequeño, ejemplo informacion general de cliente",
                        wkf03activo = 1,
                        wkf03nivel1 = 3
                    },
                    new wkf03Nivel
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

            if (!context.wkf05Tipopermisos!.Any())
            {
                context.wkf05Tipopermisos!.AddRange(
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "vizualizar",
                        wkf05descripcion = "vizualizar elementos, modulos, items, contenido",
                        wkf05sigla = "V",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "Listar",
                        wkf05descripcion = "habilita las opciones de listar contenido",
                        wkf05sigla = "L",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "Crear",
                        wkf05descripcion = "habilita las opciones de crear contenido",
                        wkf05sigla = "C",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "Modificar",
                        wkf05descripcion = "habilita las opciones de modificar o editar contenido",
                        wkf05sigla = "M",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "Eliminar",
                        wkf05descripcion = "habilita las opciones de Desabilitar o eliminar contenido",
                        wkf05sigla = "D",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "habilitar",
                        wkf05descripcion = "habilita las opciones de importar contenido",
                        wkf05sigla = "A",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "Buscar",
                        wkf05descripcion = "habilita las opciones del buscador",
                        wkf05sigla = "F",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "Exportar",
                        wkf05descripcion = "habilita las opciones del exportar contenido",
                        wkf05sigla = "E",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "Importar",
                        wkf05descripcion = "habilita las opciones de importar contenido",
                        wkf05sigla = "I",
                        wkf05activo = 1,
                    },
                    new wkf05Tipopermiso
                    {
                        wkf05nombre = "Enviar por e-Mail",
                        wkf05descripcion = "habilita las opciones de enviar contenido por e-mail",
                        wkf05sigla = "S",
                        wkf05activo = 1,
                    }

                );
            }

            context.SaveChanges();

            if (!context.per08TipoDocumentos!.Any())
            {
                context.per08TipoDocumentos!.AddRange(
                    new per08TipoDocumento
                    {
                        per08nombre = "Rut",
                        per08descripcion = "personas con nacionalidad chilena o residencia permanente",
                        per08activo = 1,
                    },
                    new per08TipoDocumento
                    {
                        per08nombre = "DNI",
                        per08descripcion = "personas Con nacionalidad extranjera sin rut",
                        per08activo = 1,
                    },
                    new per08TipoDocumento
                    {
                        per08nombre = "Numero pasaporte",
                        per08descripcion = "personas con extranjeras que no tienen DNI",
                        per08activo = 1,
                    }
                );
            }

            context.SaveChanges();

            if (!context.wkf10TipoParametros!.Any())
            {
                context.wkf10TipoParametros!.AddRange(
                    new wkf10TipoParametro
                    {
                        wkf10nombre = "cookie",
                        wkf10descripcion = "acciones sobre cookies",
                        wkf10activo = 1,
                    },
                    new wkf10TipoParametro
                    {
                        wkf10nombre = "control",
                        wkf10descripcion = "acciones sobre controles de formularios",
                        wkf10activo = 1,
                    },
                    new wkf10TipoParametro
                    {
                        wkf10nombre = "form",
                        wkf10descripcion = "acciones sobre controles de envios de post o request de formularios",
                        wkf10activo = 1,
                    },
                    new wkf10TipoParametro
                    {
                        wkf10nombre = "profile",
                        wkf10descripcion = "acciones sobre profiles",
                        wkf10activo = 1,
                    },
                    new wkf10TipoParametro
                    {
                        wkf10nombre = "querystring",
                        wkf10descripcion = "acciones sobre querystring",
                        wkf10activo = 1,
                    },
                    new wkf10TipoParametro
                    {
                        wkf10nombre = "sesion",
                        wkf10descripcion = "acciones sobre sesion",
                        wkf10activo = 1,
                    },
                    new wkf10TipoParametro
                    {
                        wkf10nombre = "routerdata",
                        wkf10descripcion = "acciones sobre routerdata",
                        wkf10activo = 1,
                    }
                );
            }

            context.SaveChanges();

            if (!context.wkf04Nivelpermisos!.Any())
            {
                context.wkf04Nivelpermisos!.AddRange(
                    new wkf04Nivelpermiso   
                    {
                        wkf03llave = 1,
                        wkf05llave= 1,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 2,
                        wkf05llave = 1,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 3,
                        wkf05llave = 1,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 1,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 2,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 3,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 4,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 5,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 6,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 7,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 8,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
                    {
                        wkf03llave = 4,
                        wkf05llave = 9,
                        wkf04activo = 1
                    },
                    new wkf04Nivelpermiso
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
