using Employees.Core.Entites;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repositories
{
    public class CompanyTermsRepository : ICompanyTermsRepository
    {
        private readonly DataContext _data;

        public CompanyTermsRepository(DataContext data)
        {
            _data = data;
        }


        public async Task<CompanyTerms> GetByIdAsync(int id)
        {
            return await _data.CompanyTerms.FindAsync(id);
        }
        public async Task<CompanyTerms> AddCompanyTermsAsync(CompanyTerms companyTerms)
        {
            if (companyTerms == null)
                return null;

            await _data.CompanyTerms.AddAsync(companyTerms);
            await _data.SaveChangesAsync();
            var myTerms = await _data.CompanyTerms.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
            if (myTerms == null)
                return null;
            return myTerms;
        }

        public async Task<CompanyTerms> UpdateCompanyTermsAsync(int id, CompanyTerms companyTerms)
        {
            var myTerms = await _data.CompanyTerms.FindAsync(id);
            if (myTerms == null)
                return null;

            myTerms.DaySalariesCalculation = companyTerms.DaySalariesCalculation;
            myTerms.NightShiftPrecent = companyTerms.NightShiftPrecent;
            myTerms.ShabbatShiftPrecent = companyTerms.ShabbatShiftPrecent;
            myTerms.Clothing = companyTerms.Clothing;
            myTerms.BirthDays = companyTerms.BirthDays;
            myTerms.Meals = companyTerms.Meals;
            myTerms.Gifts = companyTerms.Gifts;
            myTerms.Recovery = companyTerms.Recovery;

           await _data.SaveChangesAsync();

            return myTerms;
        }

        public async Task<CompanyTerms> DeleteCompanyTermsAsync(int termsId)
        {
            var myTerms = await _data.CompanyTerms.FindAsync(termsId);
            if(myTerms == null)
                return null;
            _data.CompanyTerms.Remove(myTerms);
            //await _data.SaveChangesAsync();
            return myTerms;
        }

    }
}
