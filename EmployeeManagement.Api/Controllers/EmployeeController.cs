using AutoMapper;
using EmployeeManagement.Api.Models;
using Employees.Core.DTOs;
using Employees.Core.Entites;
using Employees.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Text;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeSerivce _serivce;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeSerivce serivce, IMapper mapper, ICompanyService companyService)
        {
            _serivce = serivce;
            _mapper = mapper;
            _companyService = companyService;
        }


        [HttpGet("{companyId}/download")]
        public ActionResult GetCsvData(int companyId)
        {
            var employees = _serivce.GetAll(companyId);
            if (employees == null)
                return BadRequest();
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            StringBuilder csvContent = new StringBuilder();
            string title = "Id,FirstName,.LastName,.Identity,.IsMale,.BirthDate,.Address,.Email,.Credits,.StartJob,.IsActive";

            csvContent.AppendLine(string.Join(",", title));
            foreach (var employee in employeesDto)
            {
                string csvRow = $"{employee.Id},{employee.FirstName},{employee.LastName},{employee.Identity},{employee.IsMale},{employee.BirthDate.ToString()},{employee.Address},{employee.Email},{employee.Credits},{employee.StartJob.ToString()},{employee.IsActive}";

                csvContent.AppendLine(string.Join(",", csvRow));
            }

            var res = csvContent.ToString();
            return Ok(res);

        }


        [HttpGet("{companyId}")]
        public ActionResult<IEnumerable<EmployeeDto>> GetAll(int companyId)
        {
            var employees = _serivce.GetAll(companyId);
            if (employees == null)
                return BadRequest();
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeesDto);
        }


        [HttpGet("emp-id/{id}")]
        public async Task<ActionResult<EmployeeDto>> GetByIdAsync(int id)
        {
            var emp = await _serivce.GetByIdAsync(id);
            if (emp == null)
                return NotFound();
            return Ok(_mapper.Map<EmployeeDto>(emp));
        }


        [HttpPost("{companyId}")]
        public async Task<ActionResult<EmployeeDto>> PostAsync(int companyId, 
            [FromBody] EmployeePostModel employee, int termsId, int bankAccountId)
        {
            var emp = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                BirthDate = employee.BirthDate,
                Credits = employee.Credits,
                Email = employee.Email,
                IsMale = employee.IsMale,
                Identity = employee.Identity,
                TermsId = termsId,
                BankAccountId = bankAccountId,
                CompanyId = companyId
            };//לבדוק איך להוסיף את מזהה החברה מתוך אוביקט ההתחברות
            var result = await _serivce.AddNewAsync(emp);
            if (result == null)
                return NotFound();
            if(employee.Positions.Count > 0)
            {
                var listPositions = new List<EmployeePosition>();
                foreach (var position in employee.Positions)
                {
                    var pos = new EmployeePosition()
                    {
                        EmployeeId = result.Id,
                        PositionId = position.PositionId,
                        StartPositionDate = position.StartPosition
                    };
                    listPositions.Add(pos);
                }
                await _serivce.UpadtePositionsToEmployeeAsync(result.Id, listPositions);
            }
            return Ok(_mapper.Map<EmployeeDto>(result));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> PutAsync(int id, [FromBody] EmployeePutModel employee)
        {
            var emp = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                Email = employee.Email,
                Credits= employee.Credits,
            };

            var result = await _serivce.UpdateAsync(id, emp);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<EmployeeDto>(result));
        }

        [HttpPut("{id}/positions")]
        public async Task<ActionResult<Employee>> UpadtePositionsList(int id, [FromBody] List<PositionEmployeePostModel> positions)
        {
            var listPositions = new List<EmployeePosition>();
            foreach (var position in positions)
            {
                var pos = new EmployeePosition()
                {
                    EmployeeId = id,
                    PositionId = position.PositionId,
                    StartPositionDate = position.StartPosition
                };
                listPositions.Add(pos);
            }
            var result = await _serivce.UpadtePositionsToEmployeeAsync(id, listPositions);
            if(result == null)
                return NotFound();
            return Ok(result);
        }


        [HttpPut("delete/emp-id/{id}")]
        public async Task<ActionResult<EmployeeDto>> Delete(int id)
        {
            var result = await _serivce.UpdateStatusAsync(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<EmployeeDto>(result));
        }
    }
}
