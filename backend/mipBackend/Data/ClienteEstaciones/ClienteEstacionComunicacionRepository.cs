using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.ClienteEstacionDtos;

using KendoNET.DynamicLinq;

namespace mipBackend.Data.ClienteEstaciones
{
    public class ClienteEstacionComunicacionRepository : IClienteEstacionComunicacionRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public ClienteEstacionComunicacionRepository(
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

        public async Task<DataSourceResult> GetAllClienteEstacionComunicacionDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {

                int filtro = 0;
                int cnt01 = 0;
                ClienteEstacionComunicacionResponseDto request = new ClienteEstacionComunicacionResponseDto();

                Filter filter = new Filter();
                if (filter != null)
                {
                    IEnumerable<Filter> fil = options.Filter!.Filters;
                    if (fil != null)
                    {
                        foreach (var item in fil)
                        {
                            switch (item.Field)
                            {
                                case "cnt01llave":
                                    cnt01 = Convert.ToInt32(item.Value.ToString());
                                    break;
                                case "cnt06llave":
                                    request.cnt06llave = Convert.ToInt32(item.Value.ToString());
                                    break;
                            }
                        };
                    }

                }

                var query = await (from cm in db.cnt06ComunicacionClientes
                                   join co10 in db.cnt10TipoComunicaciones! on cm.cnt10llave equals co10.cnt10llave
                                   join cnt in db.cnt01CuentaClientes! on cm.cnt01llave equals cnt.cnt01llave
                                   join c2 in db.cnt02TipoCuentas! on cnt.cnt02llave equals c2.cnt02llave
                                   join per in db.per01personas! on cnt.per01llave equals per.per01llave
                                   join gen in db.per02Generos! on per.per02llave equals gen.per02llave
                                   join c3 in db.cnt03TipoClientes! on cnt.cnt03llave equals c3.cnt03llave
                                   join p3 in db.per03Tipopersonas! on per.per03llave equals p3.per03llave
                                   join scom in db.sist03Comunas! on cm.sist03llave equals scom.sist03llave into scomGroup
                                   from scom in scomGroup.DefaultIfEmpty()
                                   join sreg in db.sist04Regiones! on scom.sist04llave equals sreg.sist04llave into sregGroup
                                   from sreg in sregGroup.DefaultIfEmpty()


                                   where (cm.cnt01llave == cnt01)

                                   select new ClienteEstacionComunicacionResponseDto
                                   {
                                       cnt06llave = cm.cnt06llave,
                                       cnt01llave = cnt.cnt01llave,
                                       cnt10llave = co10.cnt10llave,
                                       cnt10nombre = co10.cnt10nombre,
                                       cnt06direccion = cm.cnt06direccion,
                                       sist03llave = scom.sist03llave,
                                       sist03nombre = scom.sist03nombre,
                                       sist04llave = sreg.sist04llave,
                                       sist04nombre = sreg.sist04nombre,
                                       cnt06casilla = cm.cnt06casilla,
                                       cnt06tienecasilla = cm.cnt06tienecasilla,
                                       cnt06codigopostal = cm.cnt06codigopostal,
                                       cnt06email = cm.cnt06email,
                                       cnt06tipomail = cm.cnt06tipomail,
                                       cnt06telefono1 = cm.cnt06telefono1,
                                       cnt06telefono2 = cm.cnt06telefono2,
                                       cnt06celular1 = cm.cnt06celular1,
                                       cnt06celular2 = cm.cnt06celular2,
                                       cnt06fax = cm.cnt06fax,
                                       cnt06sitioweb = cm.cnt06sitioweb,
                                       cnt06activo = cm.cnt06activo
                                   }
                                   
                                   
                                   ).ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);

                

                return query;

            }
        }


        public async Task<ClienteEstacionComunicacionResponseDto> GetAllClienteEstacionComunicacionById(ClienteEstacionComunicacionRequestDto request) 
        {

            using (var db = _contexto)
            {

                var query = await (from cm in db.cnt06ComunicacionClientes
                                   join co10 in db.cnt10TipoComunicaciones! on cm.cnt10llave equals co10.cnt10llave
                                   join cnt in db.cnt01CuentaClientes! on cm.cnt01llave equals cnt.cnt01llave
                                   join c2 in db.cnt02TipoCuentas! on cnt.cnt02llave equals c2.cnt02llave
                                   join per in db.per01personas! on cnt.per01llave equals per.per01llave
                                   join gen in db.per02Generos! on per.per02llave equals gen.per02llave
                                   join c3 in db.cnt03TipoClientes! on cnt.cnt03llave equals c3.cnt03llave
                                   join p3 in db.per03Tipopersonas! on per.per03llave equals p3.per03llave
                                   join scom in db.sist03Comunas! on cm.sist03llave equals scom.sist03llave into scomGroup
                                   from scom in scomGroup.DefaultIfEmpty()
                                   join sreg in db.sist04Regiones! on scom.sist04llave equals sreg.sist04llave into sregGroup
                                   from sreg in sregGroup.DefaultIfEmpty()


                                   where (cm.cnt01llave == request.cnt01llave) &&
                                   (cm.cnt06llave == request.cnt06llave)

                                   select new ClienteEstacionComunicacionResponseDto
                                   {
                                       cnt06llave = cm.cnt06llave,
                                       cnt01llave = cnt.cnt01llave,
                                       cnt10llave = co10.cnt10llave,
                                       cnt10nombre = co10.cnt10nombre,
                                       cnt06direccion = cm.cnt06direccion,
                                       sist03llave = scom.sist03llave,
                                       sist03nombre = scom.sist03nombre,
                                       sist04llave = sreg.sist04llave,
                                       sist04nombre = sreg.sist04nombre,
                                       cnt06casilla = cm.cnt06casilla,
                                       cnt06tienecasilla = cm.cnt06tienecasilla,
                                       cnt06codigopostal = cm.cnt06codigopostal,
                                       cnt06email = cm.cnt06email,
                                       cnt06tipomail = cm.cnt06tipomail,
                                       cnt06telefono1 = cm.cnt06telefono1,
                                       cnt06telefono2 = cm.cnt06telefono2,
                                       cnt06celular1 = cm.cnt06celular1,
                                       cnt06celular2 = cm.cnt06celular2,
                                       cnt06fax = cm.cnt06fax,
                                       cnt06sitioweb = cm.cnt06sitioweb,
                                       cnt06activo = cm.cnt06activo
                                   }


                                   ).FirstAsync();



                return query;

            }

        }

        public async Task<bool> CreateClienteEstacionComunicacion(ClienteEstacionComunicacionRequestDto request)
        {

            bool returned = false;

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            var persona = await _contexto.cnt01CuentaClientes!
               .FirstOrDefaultAsync(x => x.cnt01llave == request.cnt01llave);

            if (persona == null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El cliente ingresado no es valida para hacer esta inserción" }
                    );
            }


            var clientecomunicacion = await _contexto.cnt06ComunicacionClientes!
               .FirstOrDefaultAsync(x => x.cnt01llave == request.cnt01llave
               && x.cnt06llave == request.cnt06llave);

            if (clientecomunicacion == null)
            {

                var newclientecomunicacion = new cnt06ComunicacionCliente();

                newclientecomunicacion.cnt01llave = request.cnt01llave;
                newclientecomunicacion.cnt10llave = request.cnt10llave;
                newclientecomunicacion.sist03llave = request.sist03llave;
                newclientecomunicacion.cnt06direccion = request.cnt06direccion;
                newclientecomunicacion.cnt06casilla = request.cnt06casilla;
                newclientecomunicacion.cnt06tienecasilla = request.cnt06tienecasilla;

                newclientecomunicacion.cnt06codigopostal = request.cnt06codigopostal;
                newclientecomunicacion.cnt06email = request.cnt06email;
                newclientecomunicacion.cnt06tipomail = request.cnt06tipomail;
                newclientecomunicacion.cnt06telefono1 = request.cnt06telefono1;

                newclientecomunicacion.cnt06telefono2 = request.cnt06telefono2;
                newclientecomunicacion.cnt06celular1 = request.cnt06celular1;

                newclientecomunicacion.cnt06celular2 = request.cnt06celular2;
                newclientecomunicacion.cnt06fax = request.cnt06fax;

                newclientecomunicacion.cnt06sitioweb = request.cnt06sitioweb;
                newclientecomunicacion.cnt06activo = 1;

                newclientecomunicacion.createby = usuario.Id;


                var returnvalue  = await _contexto.cnt06ComunicacionClientes!.AddAsync(newclientecomunicacion);

                return returned;

            }
            else
            {

                clientecomunicacion.cnt01llave = request.cnt01llave;
                clientecomunicacion.cnt10llave = request.cnt01llave;
                clientecomunicacion.sist03llave = request.sist03llave;
                clientecomunicacion.cnt06direccion = request.cnt06direccion;
                clientecomunicacion.cnt06casilla = request.cnt06casilla;
                clientecomunicacion.cnt06tienecasilla = request.cnt06tienecasilla;

                clientecomunicacion.cnt06codigopostal = request.cnt06codigopostal;
                clientecomunicacion.cnt06email = request.cnt06email;
                clientecomunicacion.cnt06tipomail = request.cnt06tipomail;
                clientecomunicacion.cnt06telefono1 = request.cnt06telefono1;

                clientecomunicacion.cnt06telefono2 = request.cnt06telefono2;
                clientecomunicacion.cnt06celular1 = request.cnt06celular1;

                clientecomunicacion.cnt06celular2 = request.cnt06celular2;
                clientecomunicacion.cnt06fax = request.cnt06fax;

                clientecomunicacion.cnt06sitioweb = request.cnt06sitioweb;
                clientecomunicacion.cnt06activo = 1;

                clientecomunicacion.createby = usuario.Id;

                _contexto.cnt06ComunicacionClientes.Update(clientecomunicacion);


                return returned;

            }


        }

        public async Task DeleteClienteEstacionComunicacion(ClienteEstacionComunicacionRequestDto request)
        {

            var clientecomunicacion = await _contexto.cnt06ComunicacionClientes!
                .FirstOrDefaultAsync(x => x.cnt01llave == request.cnt01llave
                                        && x.cnt06llave == request.cnt06llave);

            _contexto.cnt06ComunicacionClientes!.Remove(clientecomunicacion!);

        }


    }
}
