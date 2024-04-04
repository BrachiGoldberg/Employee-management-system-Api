using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Entites
{
    public class AttendanceJournal
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public TimeOnly BeginningTime { get; set; }

        public TimeOnly EndingTime { get; set; }
    }
}
