using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IEmployeeTermsService
    {
        public Task<EmployeeTerms> GetByIdAsync(int termsId);
        public Task<EmployeeTerms> AddAsync(EmployeeTerms terms);

        public Task<EmployeeTerms> UpdateAsync(int employeeId, EmployeeTerms terms);
    }
}
