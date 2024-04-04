using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Entites
{
    public class EmployeeTerms
    {
        public int Id { get; set; }

        public double HourlyWage { get; set; }

        public double OvertimePay { get; set; }

        public int MonthlyHoursCount { get; set; }

        public double TravelExpenses { get; set; }

        public int SickDays { get; set; }

        public int EducationFund { get; set; }//לבדוק בדיוק איך מחשבים את זה ומה זה


    }
}
