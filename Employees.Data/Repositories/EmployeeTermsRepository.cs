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
    public class EmployeeTermsRepository : IEmployeeTermsRepository
    {
        private readonly DataContext _data;

        public EmployeeTermsRepository(DataContext data)
        {
            _data = data;
        }


        public async Task<EmployeeTerms> GetByIdAsync(int termsId)
        {
            return await _data.EmployeeTerms.FindAsync(termsId);
        }


        public async Task<EmployeeTerms> AddAsync(EmployeeTerms terms)
        {
            if (terms == null)
                return null;
            _data.EmployeeTerms.Add(terms);
            await _data.SaveChangesAsync();
            return terms;
        }

        public async Task<EmployeeTerms> UpdateAsync(int termsId, EmployeeTerms terms)
        {
            if (terms == null)
                return null;

            var myTerms = await _data.EmployeeTerms.FindAsync(termsId);
            if (myTerms == null)
                return null;

            myTerms.TravelExpenses = terms.TravelExpenses;
            myTerms.SickDays = terms.SickDays;
            myTerms.HourlyWage = terms.HourlyWage;
            myTerms.OvertimePay = terms.OvertimePay;
            myTerms.MonthlyHoursCount = terms.MonthlyHoursCount;
            myTerms.EducationFund = terms.EducationFund;

            await _data.SaveChangesAsync();
            return myTerms;
        }

        public async Task<EmployeeTerms> DeleteAsync(int termsId)
        {
            var myTerms = await _data.EmployeeTerms.FindAsync(termsId);
            if (myTerms == null)
                return null;
            _data.EmployeeTerms.Remove(myTerms);
            //await _data.SaveChangesAsync();
            return myTerms;
        }

    }
}
