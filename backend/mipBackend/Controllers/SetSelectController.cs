using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mipBackend.Data.SetSelect;
using mipBackend.Dtos.SetSelectDtos;
using mipBackend.Middleware;
using mipBackend.Models;
using System.Net;
using mipBackend.Data;

namespace mipBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetSelectController : ControllerBase
    {

        private readonly ISetSelectRepository _repository;
        private IMapper _mapper;
        private HttpStatusCode httpStatusCode;

        public SetSelectController
            (
                AppDbContext context,
                ISetSelectRepository repository,
                IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<ActionResult<IEnumerable<SetSelectResponseDto>>> GetSelectIdnum(SetSelectRequestDto request)
        {

            var result = await _repository.GetAllSelect(request);
            return Ok(_mapper.Map<IEnumerable<SetSelectResponseDto>>(result));

        }

    }
}
