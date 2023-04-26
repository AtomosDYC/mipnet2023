using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.DefaultUsers;
using mipBackend.Dtos.DefaultUserDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultUserController : ControllerBase
    {

        private readonly IDefaultUserRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public DefaultUserController
            (

                IDefaultUserRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<DefaultUserResponseDto>> GetDefaultUser()
        {

            var DefaultUser = await _repository.GetAllDefaultUsers();
            if (DefaultUser == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la DefaultUser" }
                    );
            }
            return Ok(_mapper.Map<DefaultUserResponseDto>(DefaultUser));

        }

        [HttpGet("~/api/DefaultUser/GetDefaultUserById/{id}")]
        [ActionName(nameof(GetDefaultUserById))]
        public async Task<ActionResult<DefaultUserResponseDto>> GetDefaultUserById(int id)
        {


            var DefaultUser = await _repository.GetDefaultUserById(id);

            if (DefaultUser == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la DefaultUser por este id {id}" }
                    );
            }

            return Ok(_mapper.Map<DefaultUserResponseDto>(DefaultUser));

        }

        [HttpPost]
        public async Task<ActionResult<DefaultUserResponseDto>> CreateDefaultUser
            (
               [FromBody] DefaultUserRequestDto DefaultUser
            )
        {

            var DefaultUserModel = _mapper.Map<Per09DefaultUser>(DefaultUser);

            await _repository.CreateDefaultUser(DefaultUserModel);
            await _repository.SaveChanges();

            var DefaultUserResponse = _mapper.Map<DefaultUserResponseDto>(DefaultUserModel);

            var DefaultUserdto = await _repository.GetDefaultUserById(DefaultUserResponse.per09llave);

            if (DefaultUserdto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la DefaultUser por este id {DefaultUserResponse.per09llave}" }
                    );
            }

            return Ok(_mapper.Map<DefaultUserResponseDto>(DefaultUserdto));



        }

        [HttpPut]
        public async Task<ActionResult<DefaultUserResponseDto>> UpdateDefaultUser
            (
                [FromBody] DefaultUserResponseDto DefaultUser
            )
        {

            var DefaultUserModel = _mapper.Map<Per09DefaultUser>(DefaultUser);

            await _repository.UpdateDefaultUser(DefaultUserModel);
            await _repository.SaveChanges();

            var DefaultUserResponse = _mapper.Map<DefaultUserResponseDto>(DefaultUserModel);

            var DefaultUserdto = await _repository.GetDefaultUserById(DefaultUserResponse.per09llave);

            if (DefaultUserdto == null)
            {
                throw new MiddlewareException
                    (
                        HttpStatusCode.NotFound,
                        new { mensaje = $"No se encontro la DefaultUser por este id {DefaultUserResponse.per09llave}" }
                    );
            }

            return Ok(_mapper.Map<DefaultUserResponseDto>(DefaultUserdto));

        }

        

    }
}