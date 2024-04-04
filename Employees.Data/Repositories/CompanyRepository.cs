using Employees.Core.Entites;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _data;
        private readonly ICompanyTermsRepository _termsRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public CompanyRepository(DataContext data, ICompanyTermsRepository termsRepository,
            IEmployeeRepository employeeRepository)
        {
            _data = data;
            _termsRepository = termsRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<Company> GetAsync(int id)
        {
            return await _data.Companies.FindAsync(id);
        }
        public async Task<Company> LoginCompanyAsync(string userName, string password)
        {
            var exists = await _data.Companies
                .FirstOrDefaultAsync(c => c.UserName == userName && c.Password == password);
            if (exists == null)
                return null;
            return exists;
        }

        //include managerId and companyTerms
        public async Task<Company> AddNewCompanyAsync(Company company)
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


        public async Task<Company> UpdateCompanyDetailsAsync(int id, Company company)
        {
            var myCompany = await _data.Companies.FindAsync(id);
            if (myCompany == null || company == null)
                return null;

            bool existDemoName = false;// existDemoUserName = false, existDemoPassword = false;
            if (company.Name != myCompany.Name)
                existDemoName = _data.Companies.Any(c => c.Name == company.Name);
            //if (company.UserName != myCompany.UserName)
            //    existDemoUserName = _data.Companies.Any(c => c.UserName == company.UserName); ;
            //if (company.Password != myCompany.Password)
            //    existDemoPassword = _data.Companies.Any(c => c.Password == company.Password);

            if (existDemoName)
                return null;

            myCompany.Name = company.Name;
            myCompany.Description = company.Description;
            //myCompany.UserName = company.UserName;
            //myCompany.Password = company.Password;
            myCompany.Address = company.Address;
            myCompany.Email = company.Email;

            await _data.SaveChangesAsync();
            return myCompany;
        }

        public async Task<Company> UpdateUserNamePasswordAsync(int id, string userName, string password)
        {
            if (userName == null || password == null)
                return null;

            var myCompany = await _data.Companies.FindAsync(id);
            if (myCompany == null)
                return null;

            bool existDemoUserName = false, existDemoPassword =false;

            if (userName != myCompany.UserName)
                existDemoUserName = _data.Companies.Any(c => c.UserName == userName); ;
            if (password != myCompany.Password)
                existDemoPassword = _data.Companies.Any(c => c.Password == password);

            if (existDemoUserName || existDemoPassword)
                return null;

            myCompany.Password = password;
            myCompany.UserName = userName;
            await _data.SaveChangesAsync();
            return myCompany;
        }

        public async Task<Company> ChangeManagerAsync(int id, int managerId)
        {
            //var myCompany = await _data.Companies.FirstOrDefaultAsync(c => c.Id == id);
            var myCompany = await _data.Companies.Include(c => c.Manager)
                .FirstOrDefaultAsync(c => c.Id == id);
            var myManager = await _data.Employees
                .FirstOrDefaultAsync(e => e.Id == managerId && e.CompanyId == id);
            if (myCompany == null || myManager == null)
                return null;
            var newManager = new Manager()
            {
                CompanyId = id,
                Identity = myManager.Identity
            };
            var oldManager = await _data.Managers.FindAsync(id);
            _data.Managers.Remove(oldManager);
            myCompany.Manager = newManager;
            await _data.SaveChangesAsync();
            return myCompany;
        }

        //include delete all employees from the system, and company terms
        public async Task<Company> DeleteCompanyAsync(int id)
        {
            var myCopany = await _data.Companies.Include(c => c.Employees)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (myCopany == null)
                return null;


            myCopany.Employees.ForEach(async c =>
                await _employeeRepository.DeleteFromDbAsync(c.Id));
            myCopany.Employees.Clear();
            

            _data.Companies.Remove(myCopany);
            //await _data.SaveChangesAsync();

            var result = await _termsRepository.DeleteCompanyTermsAsync(myCopany.TermsId);
            if (result == null)
                return null;

            await _data.SaveChangesAsync();
            return myCopany;
        }


    }
}
