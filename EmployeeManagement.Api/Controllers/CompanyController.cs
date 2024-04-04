using AutoMapper;
using EmployeeManagement.Api.Models;
using Employees.Core.DTOs;
using Employees.Core.Entites;
using Employees.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<string> Get()
        {
            return "hello world";
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetAsync(int id)
        {
            var comp = await _service.GetAsync(id);
            if(comp == null) 
                return NotFound();
            return Ok(comp);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> Put(int id, CompanyPutModel company)
        {
            var comp = new Company()
            {
                Name = company.Name,
                //Password = company.Password,
                //UserName = company.UserName,
                Address = company.Address,
                Description = company.Description,
                Email = company.Email,
            };

            var result = await _service.UpdateCompanyDetailsAsync(id, comp);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<CompanyDto>(result));
        }


        [HttpPut("{id}/entry-details")]
        public async Task<ActionResult<Company>> PutUserNamePassword(
            int id, [FromBody] LoginDetailsPostModel loginDetails)
        {
            var result = await
                _service.UpdateUserNamePasswordAsync(id, loginDetails.UserName, loginDetails.Password);
            if (result == null)
                return BadRequest();
            return Ok(_mapper.Map<CompanyDto>(result));
        }


        [HttpPut("{id}/manager")]
        public async Task<ActionResult<Company>> PutManagerDetails(int id, int managerId)
        {
            var result = await _service.ChangeManagerAsync(id, managerId);
            if (result == null)
                return BadRequest();
            return Ok(_mapper.Map<CompanyDto>(result));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> Delete(int id)
        {
            var result = await _service.DeleteCompanyAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<CompanyDto>(result));
        }
    }
}
