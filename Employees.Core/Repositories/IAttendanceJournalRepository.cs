using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IAttendanceJournalRepository
    {
        public Task<IEnumerable<AttendanceJournal>> GetAllAttendanceJournalByEmployeeIdAsync(int employeeId);

        public Task<AttendanceJournal> AddAsync(int employeeId, AttendanceJournal attendanceJournal);
    }
}
