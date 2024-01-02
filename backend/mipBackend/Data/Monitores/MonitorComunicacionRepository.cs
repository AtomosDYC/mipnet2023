using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.MonitorDtos;


using KendoNET.DynamicLinq;

namespace mipBackend.Data.Monitores
{
    public class MonitorComunicacionRepository : IMonitorComunicacionRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MonitorComunicacionRepository(
            AppDbContext context,
            IUsuarioSesion sesion,
            UserManager<Usuario> userManager,
             IMapper mapper)
        {
            _contexto = context;
            _usuarioSesion = sesion;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task<DataSourceResult> GetAllMonitorComunicacionDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {
                int filtro = 0;
                Filter filter = new Filter();
                if (filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            filtro = Convert.ToInt32(item.Value.ToString());
                        };
                    }

                }


                var query = await (from mnt in db.Mnt01Monitores
                                   join com in db.per05Comunicaciones! on mnt.per01llave equals com.per01llave
                                   join tcom in db.per04TipoComunicaciones! on com.per04llave equals tcom.per04llave
                                   join tper in db.per03Tipopersonas! on com.per03llave equals tper.per03llave
                                   join per in db.per01personas! on com.per01llave equals per.per01llave
                                   join scom in db.sist03Comunas! on com.sist03llave equals scom.sist03llave into scomGroup
                                   from scom in scomGroup.DefaultIfEmpty()
                                   join sreg in db.sist04Regiones! on scom.sist04llave equals sreg.sist04llave into sregGroup
                                   from sreg in sregGroup.DefaultIfEmpty()
                                   where mnt.mnt01llave == filtro
                                   select new MonitorComunicacionResponseDto


                                   {

                                       per01llave = per.per01llave,
                                       per04llave = com.per04llave,
                                       per04nombre = tcom.per04nombre,
                                       per03llave = com.per03llave,
                                       per03nombre = tper.per03nombre,
                                       per05Direccion = com.per05direccion,
                                       sist03llave = com.sist03llave,
                                       sist03nombre = scom.sist03nombre,
                                       sist04llave = scom.sist04llave,
                                       sist04nombre = sreg.sist04nombre,
                                       per0Casilla = com.per05casilla,
                                       per05TieneCasilla = com.per05tienecasilla,
                                       per05CodigoPostal = com.per05codigopostal,
                                       per05Email = com.per05email,
                                       per05Telefono1 = com.per05telefono1,
                                       per05Telefono2 = com.per05telefono2,
                                       per05Celular1 = com.per05celular1,
                                       per05Celular2 = com.per05celular2,
                                       per05Fax = com.per05fax,
                                       per05SitioWeb = com.per05sitioWeb



                                   }).ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);

                return query;

            }
        }


        public async Task<MonitorComunicacionResponseDto> GetMonitorComunicacionById(MonitorComunicacionbyidRequestDto request)
        {

            var persona = await _contexto.per01personas!
              .FirstOrDefaultAsync(x => x.per01llave == request.per01llave);

            if (persona == null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "La perosna ingresada no es valida para hacer esta eliminación" }
                    );
            }


            using (var db = _contexto)
            {
                var query = await (from com in db.per05Comunicaciones
                                   join tcom in db.per04TipoComunicaciones! on com.per04llave equals tcom.per04llave
                                   join tper in db.per03Tipopersonas! on com.per03llave equals tper.per03llave
                                   join per in db.per01personas! on com.per01llave equals per.per01llave
                                   join scom in db.sist03Comunas! on com.sist03llave equals scom.sist03llave into scomGroup
                                   from scom in scomGroup.DefaultIfEmpty()
                                   join sreg in db.sist04Regiones! on scom.sist04llave equals sreg.sist04llave into sregGroup
                                   from sreg in sregGroup.DefaultIfEmpty()
                                   where per.per01llave == request.per01llave &&
                                   com.per03llave == persona.per03llave &&
                                   com.per04llave == request.per04llave
                                   select new MonitorComunicacionResponseDto


                                   {

                                       per01llave = per.per01llave,
                                       per04llave = com.per04llave,
                                       per04nombre = tcom.per04nombre,
                                       per03llave = com.per03llave,
                                       per03nombre = tper.per03nombre,
                                       per05Direccion = com.per05direccion,
                                       sist03llave = com.sist03llave,
                                       sist03nombre = scom.sist03nombre,
                                       sist04llave = scom.sist04llave,
                                       sist04nombre = sreg.sist04nombre,
                                       per0Casilla = com.per05casilla,
                                       per05TieneCasilla = com.per05tienecasilla,
                                       per05CodigoPostal = com.per05codigopostal,
                                       per05Email = com.per05email,
                                       per05Telefono1 = com.per05telefono1,
                                       per05Telefono2 = com.per05telefono2,
                                       per05Celular1 = com.per05celular1,
                                       per05Celular2 = com.per05celular2,
                                       per05Fax = com.per05fax,
                                       per05SitioWeb = com.per05sitioWeb



                                   }).FirstAsync();

                return _mapper.Map<MonitorComunicacionResponseDto>(query);

            }

        }

        public async Task CreateMonitorComunicacion(MonitorComunicacionRequestDto monitorcomunicacion)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            var persona = await _contexto.per01personas!
               .FirstOrDefaultAsync(x => x.per01llave == monitorcomunicacion.per01llave);

            if (persona == null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "La perosna ingresada no es valida para hacer esta eliminación" }
                    );
            }


            var personacomunicacion = await _contexto.per05Comunicaciones!
               .FirstOrDefaultAsync(x => x.per01llave == monitorcomunicacion.per01llave 
               && x.per03llave == persona.per03llave
               && x.per04llave == monitorcomunicacion.per04llave);

            if (personacomunicacion == null)
            {

                var newpersonacomunicacion = new per05Comunicacion();
                newpersonacomunicacion.per01llave = monitorcomunicacion.per01llave;
                newpersonacomunicacion.per04llave = monitorcomunicacion.per04llave;
                newpersonacomunicacion.per03llave = persona.per03llave;
                newpersonacomunicacion.per05direccion = monitorcomunicacion.per05direccion;
                newpersonacomunicacion.sist03llave = monitorcomunicacion.sist03llave;
                newpersonacomunicacion.per05casilla = monitorcomunicacion.per05casilla;
                newpersonacomunicacion.per05tienecasilla = monitorcomunicacion.per05tienecasilla;

                newpersonacomunicacion.per05codigopostal = monitorcomunicacion.per05codigopostal;
                newpersonacomunicacion.per05email = monitorcomunicacion.per05email;
                newpersonacomunicacion.per05telefono1 = monitorcomunicacion.per05telefono1;
                newpersonacomunicacion.per05telefono2 = monitorcomunicacion.per05telefono2;

                newpersonacomunicacion.per05celular1 = monitorcomunicacion.per05celular1;
                newpersonacomunicacion.per05celular2 = monitorcomunicacion.per05celular2;

                newpersonacomunicacion.per05fax = monitorcomunicacion.per05fax;
                newpersonacomunicacion.per05sitioWeb = monitorcomunicacion.per05SitioWeb;

                newpersonacomunicacion.fechaactualizacion = DateTime.Now;
                newpersonacomunicacion.createby = usuario.Id;

                await _contexto.per05Comunicaciones!.AddAsync(newpersonacomunicacion);

            } 
            else 
            {

                personacomunicacion.per05direccion = monitorcomunicacion.per05direccion;
                personacomunicacion.sist03llave = monitorcomunicacion.sist03llave;
                personacomunicacion.per05casilla = monitorcomunicacion.per05casilla;
                personacomunicacion.per05tienecasilla = monitorcomunicacion.per05tienecasilla;

                personacomunicacion.per05codigopostal = monitorcomunicacion.per05codigopostal;
                personacomunicacion.per05email = monitorcomunicacion.per05email;
                personacomunicacion.per05telefono1 = monitorcomunicacion.per05telefono1;
                personacomunicacion.per05telefono2 = monitorcomunicacion.per05telefono2;

                personacomunicacion.per05celular1 = monitorcomunicacion.per05celular1;
                personacomunicacion.per05celular2 = monitorcomunicacion.per05celular2;

                personacomunicacion.per05fax = monitorcomunicacion.per05fax;
                personacomunicacion.per05sitioWeb = monitorcomunicacion.per05SitioWeb;

                personacomunicacion.fechaactualizacion = DateTime.Now;
                personacomunicacion.approveby = usuario.Id;

                _contexto.per05Comunicaciones.Update(personacomunicacion);


            } 
            

        }

        public async Task UpdateMonitorComunicacion(per05Comunicacion personacomunicacion)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (personacomunicacion is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            var PersonaUpdate = await _contexto.per05Comunicaciones!
                .FirstOrDefaultAsync(x => x.per01llave == personacomunicacion.per01llave
                                        && x.per04llave == personacomunicacion.per04llave
                                        && x.per03llave == personacomunicacion.per03llave);

            PersonaUpdate.per05direccion = personacomunicacion.per05direccion;
            PersonaUpdate.sist03llave = personacomunicacion.sist03llave;
            PersonaUpdate.per05casilla = personacomunicacion.per05casilla;
            PersonaUpdate.per05tienecasilla = personacomunicacion.per05tienecasilla;

            PersonaUpdate.per05codigopostal = personacomunicacion.per05codigopostal;
            PersonaUpdate.per05email = personacomunicacion.per05email;
            PersonaUpdate.per05telefono1 = personacomunicacion.per05telefono1;
            PersonaUpdate.per05telefono2 = personacomunicacion.per05telefono2;

            PersonaUpdate.per05celular1 = personacomunicacion.per05celular1;
            PersonaUpdate.per05celular2 = personacomunicacion.per05celular2;

            PersonaUpdate.per05fax = personacomunicacion.per05fax;
            PersonaUpdate.per05sitioWeb = personacomunicacion.per05sitioWeb;

            PersonaUpdate.fechaactualizacion = DateTime.Now;
            PersonaUpdate.approveby = usuario.Id;

            _contexto.per05Comunicaciones.Update(PersonaUpdate);

        }

        public async Task DeleteMonitorComunicacion(MonitorComunicacionbyidRequestDto request)
        {

            var personacomunicacion = await _contexto.per05Comunicaciones!
                .FirstOrDefaultAsync(x => x.per01llave == request.per01llave
                                        && x.per04llave == request.per04llave
                                        && x.per03llave == request.per03llave);

            _contexto.per05Comunicaciones!.Remove(personacomunicacion!);

        }
    }
}
