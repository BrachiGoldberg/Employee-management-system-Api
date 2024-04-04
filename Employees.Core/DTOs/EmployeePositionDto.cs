using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.DTOs
{
    public class EmployeePositionDto
    {
        public int EmployeeId { get; set; }

        public int PositionId { get; set; }

        public DateTime StartPositionDate { get; set; }
    }
}
