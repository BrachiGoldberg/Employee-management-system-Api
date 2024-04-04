using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface ICompanyTermsService
    {
        public Task<CompanyTerms> GetByIdAsync(int id);

        public Task<CompanyTerms> AddCompanyTermsAsync(CompanyTerms companyTerms);

        public Task<CompanyTerms> UpdateCompanyTermsAsync(int id, CompanyTerms companyTerms);

        public Task<CompanyTerms> DeleteCompanyTermsAsync(int companyId);
    }
}
