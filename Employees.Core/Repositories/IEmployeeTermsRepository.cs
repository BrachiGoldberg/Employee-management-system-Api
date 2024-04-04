using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IEmployeeTermsRepository
    {
        public Task<EmployeeTerms> GetByIdAsync(int termsId);

        public Task<EmployeeTerms> AddAsync(EmployeeTerms terms);

        public Task<EmployeeTerms> UpdateAsync(int termsId, EmployeeTerms terms);

        public Task<EmployeeTerms> DeleteAsync(int termsId);


    }
}
