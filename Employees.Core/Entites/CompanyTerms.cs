using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Entites
{
    public class CompanyTerms
    {
        public int Id { get; set; }

        public double Meals { get; set; }

        public double NightShiftPrecent { get; set; }

        public double ShabbatShiftPrecent { get; set; }

        public int Gifts { get; set; }

        public int Clothing { get; set; }

        public int Recovery { get; set; }

        public int BirthDays { get; set; }

        public int DaySalariesCalculation { get; set; }
    }
}
