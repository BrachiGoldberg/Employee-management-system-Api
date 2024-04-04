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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly ICompanyTermsRepository _termsRepository;

        public CompanyService(ICompanyRepository repository, ICompanyTermsRepository termsRepository)
        {
            _repository = repository;
            _termsRepository = termsRepository;
        }
        public async Task<Company> GetAsync(int id)
        {
            return await _repository.GetAsync(id);          
        }
        public async Task<Company> LoginCompanyAsync(string userName, string password)
        {
            return await _repository.LoginCompanyAsync(userName, password);
        }

        public async Task<Company> AddNewCompanyAsync(Company company)
        {
            return await _repository.AddNewCompanyAsync(company);
        }

        public async Task<Company> UpdateCompanyDetailsAsync(int id, Company company)
        {
            return await _repository.UpdateCompanyDetailsAsync(id, company);
        }

        public async Task<Company> UpdateUserNamePasswordAsync(int id, string userName, string password)
        {
            return await _repository.UpdateUserNamePasswordAsync(id, userName, password);
        }

        public async Task<Company> ChangeManagerAsync(int id, int managerId)
        {
            return await _repository.ChangeManagerAsync(id, managerId);
        }

        public async Task<Company> DeleteCompanyAsync(int id)
        {
            return await _repository.DeleteCompanyAsync(id);
        }

    }
}
