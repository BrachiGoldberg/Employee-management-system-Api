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
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _service;

        public BankAccountController(IBankAccountService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetByIdAsync(int id)
        {
            var bank = await _service.GetByIdAsync(id);
            if (bank == null)
                return NotFound();
            return Ok(bank);
        }


        [HttpPost]
        public async Task<ActionResult<BankAccount>> PostAsync([FromBody] BankAccountPostModel bank)
        {
            var newBank = new BankAccount()
            {
                BankAccountNumber = bank.BankAccountNumber,
                BankNunber = bank.BankNunber,
                BranchNumber = bank.BranchNumber,
            };
            var result = await _service.AddAsync(newBank);
            if(result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BankAccount>> PutAsync(int id, [FromBody] BankAccountPostModel bank)
        {
            var newBank = new BankAccount()
            {
                BankAccountNumber = bank.BankAccountNumber,
                BankNunber = bank.BankNunber,
                BranchNumber = bank.BranchNumber,
            };
            var result = await _service.UpdateAsync(id, newBank);
            if(result == null)
                return BadRequest();
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<BankAccount>> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

    }
}
