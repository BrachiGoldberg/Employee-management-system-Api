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
    public class AttendanceJournalController : ControllerBase
    {
        private IAttendanceJournalService _service;

        public AttendanceJournalController(IAttendanceJournalService service)
        {
            _service = service;
        }

        [HttpGet("emp-id/{id}")]
        public async Task<ActionResult<IEnumerable<AttendanceJournal>>> GetAll(int id)
        {
            var res = await _service.GetAllAttendanceJournalByEmployeeIdAsync(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost("emp-id/{id}")]
        public async Task<ActionResult<AttendanceJournal>> PostAsync(int id, [FromBody] AttendanceJournalPostModel aj)
        {
            var myAj = new AttendanceJournal()
            {
                Date = aj.Date,
                BeginningTime = new TimeOnly(aj.BeginHour, aj.BeginMinutes),
                EndingTime = new TimeOnly(aj.EndHour, aj.EndMinutes)
            };
            var result = await _service.AddAsync(id, myAj);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceJournal>> PostListAsync([FromBody] List<AttendanceJournalPostModel> attendances)
        {
            var listResult = new List<AttendanceJournal>();
            foreach (var attendance in attendances)
            {
                var myAj = new AttendanceJournal()
                {
                    Date = attendance.Date,
                    BeginningTime = new TimeOnly(attendance.BeginHour, attendance.BeginMinutes),
                    EndingTime = new TimeOnly(attendance.EndHour, attendance.EndMinutes)
                };
                var result = await _service.AddAsync(attendance.EmployeeId, myAj);
                if (result == null)
                    return NotFound();
                listResult.Add(result);
            }
            return Ok(listResult);
        }

    }
}
