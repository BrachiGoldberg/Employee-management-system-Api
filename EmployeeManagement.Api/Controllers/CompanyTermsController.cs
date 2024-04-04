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
    public class CompanyTermsController : ControllerBase
    {
        private readonly ICompanyTermsService _serivce;

        public CompanyTermsController(ICompanyTermsService service)
        {
            _serivce = service;
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CompanyTerms>> GetByIdAsync(int id)
        {
            var terms = await _serivce.GetByIdAsync(id);
            if (terms == null)
                return NotFound();
            return Ok(terms);
        }


        [HttpPost]
        public async Task<ActionResult<CompanyTerms>> Post([FromBody] CompanyTermsPostModel companyTerms)
        {
            var compTerms = new CompanyTerms()
            {
                DaySalariesCalculation = companyTerms.DaySalariesCalculation,
                BirthDays = companyTerms.BirthDays,
                Clothing = companyTerms.Clothing,
                Gifts = companyTerms.Gifts,
                Meals = companyTerms.Meals,
                NightShiftPrecent = companyTerms.NightShiftPrecent,
                ShabbatShiftPrecent = companyTerms.ShabbatShiftPrecent,
                Recovery = companyTerms.Recovery
            };

            var result = await _serivce.AddCompanyTermsAsync(compTerms);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyTerms>> Put(int id, [FromBody] CompanyTermsPostModel companyTerms)
        {
            var compTerms = new CompanyTerms()
            {
                DaySalariesCalculation = companyTerms.DaySalariesCalculation,
                BirthDays = companyTerms.BirthDays,
                Clothing = companyTerms.Clothing,
                Gifts = companyTerms.Gifts,
                Meals = companyTerms.Meals,
                NightShiftPrecent = companyTerms.NightShiftPrecent,
                ShabbatShiftPrecent = companyTerms.ShabbatShiftPrecent,
                Recovery = companyTerms.Recovery
            };
            var result = await _serivce.UpdateCompanyTermsAsync(id, compTerms);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }


        //[HttpDelete("{conpanyId}")]
        //public async Task<ActionResult<CompanyTerms>> Delete(int conpanyId)
        //{
        //    var result = await _serivce.DeleteCompanyTermsAsync(conpanyId);
        //    if (result == null)
        //        return NotFound();
        //    return Ok(result);
        //}
    }
}
