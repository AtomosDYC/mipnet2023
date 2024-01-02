using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.Menus;
using mipBackend.Dtos.MenuDtos;

using AutoMapper;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;


namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public MenuController
            (
            IMenuRepository repository,
            IMapper mapper
            )
        {

            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuResponseDto>>> GetMenu
            (
            
            )
        {
            var result = await _repository.GetMenu();
            return Ok(result);

        }
    }
}
