using Employees.Core.Entites;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employees.Data.Repositories
{
    public class AttendanceJournalRepository : IAttendanceJournalRepository
    {
        private readonly DataContext _data;

        public AttendanceJournalRepository(DataContext data)
        {
            _data = data;
        }


        public async Task<IEnumerable<AttendanceJournal>> GetAllAttendanceJournalByEmployeeIdAsync(int employeeId)
        {
            var myEmp = await _data.Employees.Include(e => e.AttendanceJournals)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            if (myEmp == null)
                return null;
            return myEmp.AttendanceJournals;
        }

        public async Task<AttendanceJournal> AddAsync(int employeeId, AttendanceJournal attendanceJournal)
        {
            var myEmp = await _data.Employees.Include(e => e.AttendanceJournals)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            if (myEmp == null)
                return null;
            myEmp.AttendanceJournals.Add(attendanceJournal);
            await _data.SaveChangesAsync();
            return attendanceJournal;
        }


    }
}
