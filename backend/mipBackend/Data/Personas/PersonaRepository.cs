using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;

using System.Net;
using AutoMapper;
using mipBackend.Dtos.PersonaDtos;
using KendoNET.DynamicLinq;
using mipBackend.Services.Rut;

namespace mipBackend.Data.Personas
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public PersonaRepository(
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



        public async Task<DataSourceResult> GetAllPersonasDatasource(DataSourceRequest options)
        {
            using (var db = _contexto)
            {
                string filtro = null;
                Filter filter = new Filter();
                if (filter != null)
                {
                    IEnumerable<Filter> fil  = options.Filter!.Filters;
                    if (fil != null) {
                        foreach(var item in fil)
                        {
                            filtro = item.Value.ToString();
                        };
                    }

                }
                
                

                var query = await (from per in db.per01personas
                                   join tip in db.per03Tipopersonas! on per.per03llave equals tip.per03llave
                                   join tdoc in db.per08TipoDocumentos! on per.per08llave equals tdoc.per08llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   where per.per01nombrerazon!.Contains(filtro)
                                   select new PersonaResponseDto
                                   {

                                       per01llave = per.per01llave,

                                       per01rut = per.per01rut,
                                       per03llave = per.per03llave,
                                       per03nombre = tip.per03nombre,
                                       per08llave = per.per08llave,
                                       per08nombre = tdoc.per08nombre,
                                       per02llave = per.per02llave,
                                       per02nombre = sal.per02titulo,
                                       per01nombrerazon = per.per01nombrerazon,
                                       per01nombrefantasia = per.per01nombrefantasia,
                                       per01giro = per.per01giro,
                                       per01cargo = per.per01cargo,
                                       per01fechanacimiento = per.per01fechanacimiento,
                                       per01anioingreso = per.per01anioingreso,
                                       per01activo = per.per01activo


                                   }).ToDataSourceResultAsync(options.Take, options.Skip, options.Sort, filter);

                return query;

            }
        }

        public async Task<IEnumerable<PersonaResponseDto>> GetAllPersonas()
        {
            using (var db = _contexto)
            {
                var query = await (from per in db.per01personas
                                   join tip in db.per03Tipopersonas! on per.per03llave equals tip.per03llave
                                   join tdoc in db.per08TipoDocumentos! on per.per08llave equals tdoc.per08llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   select new PersonaResponseDto
                                   {

                                        per01llave = per.per01llave,

                                       per01rut = per.per01rut,
                                       per03llave = per.per03llave,
                                       per03nombre = tip.per03nombre,
                                       per08llave = per.per08llave,
                                       per08nombre = tdoc.per08nombre,
                                       per02llave = per.per02llave,
                                       per02nombre = sal.per02titulo,
                                       per01nombrerazon = per.per01nombrerazon,
                                       per01nombrefantasia = per.per01nombrefantasia,
                                       per01giro = per.per01giro,
                                       per01cargo = per.per01cargo,
                                       per01fechanacimiento = per.per01fechanacimiento,
                                       per01anioingreso = per.per01anioingreso,
                                       per01activo = per.per01activo

                                   }).ToListAsync();

                return _mapper.Map<IEnumerable<PersonaResponseDto>>(query);

            }
        }


        public async Task<PersonaResponseDto> GetPersonaByRut(PersonaBuscarRutRepositoryDto buscador)
        {
            using (var db = _contexto)
            {
                var query = await (from per in db.per01personas
                                   join tip in db.per03Tipopersonas! on per.per03llave equals tip.per03llave
                                   join tdoc in db.per08TipoDocumentos! on per.per08llave equals tdoc.per08llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   where per.per01rut == buscador.per01rut && per.per08llave == buscador.per08llave
                                   select new PersonaResponseDto
                                   {

                                       per01llave = per.per01llave,
                                       per01rut = per.per01rut,
                                       per03llave = per.per03llave,
                                       per03nombre = tip.per03nombre,
                                       per08llave = per.per08llave,
                                       per08nombre = tdoc.per08nombre,
                                       per02llave = per.per02llave,
                                       per02nombre = sal.per02titulo,
                                       per01nombrerazon = per.per01nombrerazon,
                                       per01nombrefantasia = per.per01nombrefantasia,
                                       per01giro = per.per01giro,
                                       per01cargo = per.per01cargo,
                                       per01fechanacimiento = per.per01fechanacimiento,
                                       per01anioingreso = per.per01anioingreso,
                                       per01activo = per.per01activo

                                   }).FirstOrDefaultAsync();

                return query;

            }
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task<PersonaResponseDto> GetPersonaById(int id)
        {
            using (var db = _contexto)
            {
                var query = await (from per in db.per01personas
                                   join tip in db.per03Tipopersonas! on per.per03llave equals tip.per03llave
                                   join tdoc in db.per08TipoDocumentos! on per.per08llave equals tdoc.per08llave
                                   join sal in db.per02Generos! on per.per02llave equals sal.per02llave
                                   where per.per01llave == (id)
                                   select new PersonaResponseDto
                                   {

                                       per01llave = per.per01llave,

                                       per01rut = per.per01rut,
                                       per03llave = per.per03llave,
                                       per03nombre = tip.per03nombre,
                                       per08llave = per.per08llave,
                                       per08nombre = tdoc.per08nombre,
                                       per02llave = per.per02llave,
                                       per02nombre = sal.per02titulo,
                                       per01nombrerazon = per.per01nombrerazon,
                                       per01nombrefantasia = per.per01nombrefantasia,
                                       per01giro = per.per01giro,
                                       per01cargo = per.per01cargo,
                                       per01fechanacimiento = per.per01fechanacimiento,
                                       per01anioingreso = per.per01anioingreso,
                                       per01activo = per.per01activo


                                   }).FirstAsync();

                return _mapper.Map<PersonaResponseDto>(query);

            }

        }

        public async Task CreatePersonas(per01persona persona)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (persona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            persona.fechaactualizacion = DateTime.Now;
            persona.createby = usuario.Id;
            persona.per01activo = 1;

            await _contexto.per01personas!.AddAsync(persona);


        }

        public async Task UpdatePersonas(per01persona persona)
        {

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (persona is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            var PersonaUpdate = await _contexto.per01personas
                .FirstOrDefaultAsync(x => x.per01llave == persona.per01llave);

            PersonaUpdate.per01rut = persona.per01rut;
            PersonaUpdate.per03llave = persona.per03llave;
            PersonaUpdate.per08llave = persona.per08llave;
            PersonaUpdate.per02llave = persona.per02llave;

            PersonaUpdate.per01nombrerazon = persona.per01nombrerazon;
            PersonaUpdate.per01nombrefantasia = persona.per01nombrefantasia;
            PersonaUpdate.per01giro = persona.per01giro;
            PersonaUpdate.per01cargo = persona.per01cargo;

            PersonaUpdate.per01fechanacimiento = persona.per01fechanacimiento;
            PersonaUpdate.per01anioingreso = persona.per01anioingreso;

            PersonaUpdate.fechaactivacion = DateTime.Now;
            PersonaUpdate.createby = usuario.Id;
            PersonaUpdate.per01activo = 1;

            _contexto.per01personas!.Update(PersonaUpdate);

        }


        public async Task DeletePersonas(int id)
        {

            var persona = await _contexto.per01personas!
                .FirstOrDefaultAsync(x => x.per01llave== id);

            _contexto.per01personas!.Remove(persona!);

        }


    }
}