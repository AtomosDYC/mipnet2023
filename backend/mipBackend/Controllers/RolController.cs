using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Roles;
using mipBackend.Dtos.RolDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        private readonly IRolesRepository _repository;

        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public RolController
            (

                IRolesRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolResponseDto>>> GetRoles()
        {

            var roles = await _repository.GetAllRoles();
            return Ok(_mapper.Map<IEnumerable<RolResponseDto>>(roles));

        }



    }
}
