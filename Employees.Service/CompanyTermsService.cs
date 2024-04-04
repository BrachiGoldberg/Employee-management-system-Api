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
    public class CompanyTermsService : ICompanyTermsService
    {
        private readonly ICompanyTermsRepository _repository;

        public CompanyTermsService(ICompanyTermsRepository repository)
        {
            _repository = repository;
        }

        public async Task<CompanyTerms> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<CompanyTerms> AddCompanyTermsAsync(CompanyTerms companyTerms)
        {
            if (companyTerms != null &&
                companyTerms.DaySalariesCalculation > 0 && companyTerms.DaySalariesCalculation <= 30)
                return await _repository.AddCompanyTermsAsync(companyTerms);
            return null;
        }

        public async Task<CompanyTerms> UpdateCompanyTermsAsync(int id, CompanyTerms companyTerms)
        {
            if (companyTerms != null &&
                companyTerms.DaySalariesCalculation > 0 && companyTerms.DaySalariesCalculation <= 30)
                return await _repository.UpdateCompanyTermsAsync(id, companyTerms);
            return null;
        }

        public async Task<CompanyTerms> DeleteCompanyTermsAsync(int companyId)
        {
            return await _repository.DeleteCompanyTermsAsync(companyId);
        }

    }
}
