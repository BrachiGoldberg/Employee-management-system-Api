using EmployeeManagement.Api.Models;
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
    public class EmployeeTermsController : ControllerBase
    {
        private readonly IEmployeeTermsService _servcie;
        public EmployeeTermsController(IEmployeeTermsService service)
        {
            _servcie = service;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTerms>> GetById(int id)
        {
            var terms = await this._servcie.GetByIdAsync(id);
            if(terms == null) 
                return NotFound();
            return Ok(terms);
        }


        [HttpPost]
        public async Task<ActionResult<EmployeeTerms>> Post([FromBody] EmployeeTermsPostModel employeeTerms)
        {
            var empTerms = new EmployeeTerms()
            {
                HourlyWage = employeeTerms.HourlyWage,
                MonthlyHoursCount = employeeTerms.MonthlyHoursCount,
                OvertimePay = employeeTerms.OvertimePay,
                SickDays = employeeTerms.SickDays,
                TravelExpenses = employeeTerms.TravelExpenses,
                EducationFund = employeeTerms.EducationFund,
            };
            var result = await _servcie.AddAsync(empTerms);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("emp-id/{empId}")]
        public async Task<ActionResult<EmployeeTerms>> Put(int empId, [FromBody] EmployeeTermsPostModel employeeTerms)
        {
            var empTerms = new EmployeeTerms()
            {
                HourlyWage = employeeTerms.HourlyWage,
                MonthlyHoursCount = employeeTerms.MonthlyHoursCount,
                OvertimePay = employeeTerms.OvertimePay,
                SickDays = employeeTerms.SickDays,
                TravelExpenses = employeeTerms.TravelExpenses,
                EducationFund = employeeTerms.EducationFund
            };
            var result = await _servcie.UpdateAsync(empId, empTerms);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
