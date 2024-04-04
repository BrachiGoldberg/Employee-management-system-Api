using Employees.Core.Entites;
using Employees.Core.Repositories;
using Employees.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service
{
    public class EmployeeTermsService : IEmployeeTermsService
    {
        private readonly IEmployeeTermsRepository _repository;

        public EmployeeTermsService(IEmployeeTermsRepository repository)
        {
            _repository = repository;
        }


        public async Task<EmployeeTerms> GetByIdAsync(int termsId)
        {
            return await _repository.GetByIdAsync(termsId);
        }


        public async Task<EmployeeTerms> AddAsync(EmployeeTerms terms)
        {
            return await _repository.AddAsync(terms);
        }

        public async Task<EmployeeTerms> UpdateAsync(int employeeId, EmployeeTerms terms)
        {
            return await _repository.UpdateAsync(employeeId, terms);
        }
    }
}
