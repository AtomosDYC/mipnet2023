﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Token;
using AutoMapper;
using System.Net;

namespace mipBackend.Data.MedidaUmbrales
{
    public class MedidaUmbralRepository : IMedidaUmbralRepository
    {

        private readonly AppDbContext _contexto;
        private readonly IUsuarioSesion _usuarioSesion;
        private readonly UserManager<Usuario> _userManager;
        private IMapper _mapper;

        public MedidaUmbralRepository(
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


        public async Task CreateMedidaUmbral(esp06MedidaUmbral medidaumbral)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (medidaumbral is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            medidaumbral.fechaactivacion = DateTime.Now;
            medidaumbral.createby = usuario.Id;
            medidaumbral.esp06activo = 1;

            await _contexto.esp06MedidaUmbrales!.AddAsync(medidaumbral);

        }

        public async Task DeleteMedidaUmbral(int id)
        {

            var medidaumbral = await _contexto.esp06MedidaUmbrales!
                .FirstOrDefaultAsync(x => x.esp06llave == id);

            _contexto.esp06MedidaUmbrales!.Remove(medidaumbral!);
        }

        public async Task<IEnumerable<esp06MedidaUmbral>> GetAllMedidaUmbrales()
        {
            return await _contexto.esp06MedidaUmbrales!.ToListAsync();
        }

        public async Task<esp06MedidaUmbral> GetMedidaUmbralById(int id)
        {
            return await _contexto.esp06MedidaUmbrales!.FirstOrDefaultAsync(x => x.esp06llave == id)!;
        }

        public async Task<bool> SaveChanges()
        {
            return ((await _contexto.SaveChangesAsync()) >= 0);
        }

        public async Task UpdateMedidaUmbral(esp06MedidaUmbral request)
        {
            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer esta insercion" }
                    );
            }

            if (request is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El usuario no es valido para hacer esta insercion" }
                   );
            }

            var medidaumbral = await _contexto.esp06MedidaUmbrales!
                .FirstOrDefaultAsync(x => x.esp06llave == request.esp06llave);

            medidaumbral.fechaactualizacion = DateTime.Now;
            medidaumbral.approveby = usuario.Id;
            medidaumbral.esp06nombre = request.esp06nombre;
            medidaumbral.esp06descripcion = request.esp06descripcion;

            _contexto.esp06MedidaUmbrales!.Update(medidaumbral!);

        }

        public async Task DisableMedidaUmbral(int id)
        {

            var medidaumbral = await _contexto.esp06MedidaUmbrales!
                .FirstOrDefaultAsync(x => x.esp06llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (medidaumbral is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El tipo de especie no existe en los listados" }
                   );
            }


            medidaumbral.esp06activo = 0;

            _contexto.esp06MedidaUmbrales!.Update(medidaumbral);


        }

        public async Task ActivateMedidaUmbral(int id)
        {

            var medidaumbral = await _contexto.esp06MedidaUmbrales!
                .FirstOrDefaultAsync(x => x.esp06llave == id);

            var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            if (usuario is null)
            {
                throw new MiddlewareException(
                    HttpStatusCode.Unauthorized,
                    new { mensaje = "El usuario no es valido para hacer este camnbio" }
                    );
            }

            if (medidaumbral is null)
            {
                throw new MiddlewareException(
                   HttpStatusCode.BadRequest,
                   new { mensaje = "El tipo de especie no existe en los listados" }
                   );
            }

            medidaumbral.esp06activo = 1;

            _contexto.esp06MedidaUmbrales!.Update(medidaumbral);

        }


    }
}
