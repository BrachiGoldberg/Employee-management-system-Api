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
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _data;

        public AuthRepository(DataContext data)
        {
            _data = data;
        }


        public async Task<Company> Login(string userName, string password)
        {
            var exists = await _data.Companies
               .FirstOrDefaultAsync(c => c.UserName == userName && c.Password == password);
            if (exists == null)
                return null;
            return exists;
        }

        public async Task<Company> RegisterAsync(Company company)
        {
            if (company == null)
                return null;
            var exist = _data.Companies.Any(c => c.Name == company.Name ||
            c.UserName == company.UserName || c.Password == company.Password);
            if (exist)
                return null;
            _data.Companies.Add(company);
            await _data.SaveChangesAsync();
            var newCompany = _data.Companies.FirstOrDefault(c => c.Name == company.Name);
            return newCompany;
        }

    }
}
