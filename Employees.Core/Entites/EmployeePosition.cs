using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Entites
{
    public class EmployeePosition
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int PositionId { get; set; } 

        public Position Position { get; set; }

        public DateTime StartPositionDate { get; set; }
    }
}
