using AutoMapper;
using EmployeeManagement.Api.Models;
using Employees.Core.DTOs;
using Employees.Core.Entites;
using Employees.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _service;
        private readonly IMapper _mapper;

        public PositionController(IPositionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PositionDto>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<PositionDto>>(_service.GetPositions()));
        }


        [HttpPost]
        public async Task<ActionResult<PositionDto>> Post([FromBody] PositionPostModel position)
        {
            var myPos = new Position()
            {
                Name = position.Name,
                IsAdministrative = position.IsAdministrative
            };
            var result = await _service.AddNewPositionAsync(myPos);

            if (result == null)
                return BadRequest();
            return Ok(_mapper.Map<PositionDto>(result));
        }
    }
}
