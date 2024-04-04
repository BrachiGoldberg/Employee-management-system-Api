using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Entites
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Identity { get; set; }

        public bool IsMale { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public float Credits { get; set; }

        public DateTime StartJob { get; set; }

        public bool IsActive { get; set; }

        public BankAccount BankAccount { get; set; }

        public int BankAccountId { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public EmployeeTerms Terms { get; set; }

        public int TermsId { get; set; }

        public List<EmployeePosition> Positions { get; set; }

        public List<AttendanceJournal> AttendanceJournals { get; set; }

        //אפשר להוסיף טבלת מצב משפחתי שתחשב את מספר נקודות הזיכוי

        //public List<CompanyEmployee> EmployeesCompanies { get; set; }
    }
}
