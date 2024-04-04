using Employees.Core.Entites;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employees.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _data;
        private readonly IEmployeeTermsRepository _termsRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public EmployeeRepository(DataContext data, 
            IEmployeeTermsRepository termsRepository, IBankAccountRepository bankRepository)
        {
            _data = data;
            _termsRepository = termsRepository;
            _bankAccountRepository = bankRepository;
        }


        public IEnumerable<Employee> GetAll(int companyId)
        {
            return _data.Employees.Include(e => e.Positions)
                .Where(e => e.CompanyId == companyId && e.IsActive);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _data.Employees.Include(e => e.Positions)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        //include employeeTerms and position
        public async Task<Employee> AddNewAsync(Employee employee)
        {
            if (employee == null)
                return null;
            employee.IsActive = true;
            var existInThisCompany = await _data.Employees
                .FirstOrDefaultAsync(e => e.Identity == employee.Identity &&
                e.CompanyId == employee.CompanyId);
            if (existInThisCompany != null)
            {
                if (existInThisCompany.IsActive)
                {
                    await _termsRepository.DeleteAsync(employee.TermsId);
                    await _bankAccountRepository.DeleteAsync(employee.BankAccountId);       
                    return null; // this employee already exists in this company
                }

                existInThisCompany.IsActive = true;
                await _data.SaveChangesAsync();
                return existInThisCompany;
            }
            else
            {
                _data.Employees.Add(employee);
                await _data.SaveChangesAsync();
                 return employee;
            }
        }

        public async Task<Employee> UpdateAsync(int id, Employee employee)
        {
            var myEmployee = await _data.Employees.FindAsync(id);
            if (myEmployee == null)
                return null;

            myEmployee.FirstName = employee.FirstName;
            myEmployee.LastName = employee.LastName;
            myEmployee.Address = employee.Address;
            myEmployee.Email = employee.Email;
            myEmployee.Credits = employee.Credits;

            await _data.SaveChangesAsync();
            return myEmployee;
        }

        public async Task<Employee> UpdateStatusAsync(int id)
        {
            var myEmp = await _data.Employees.FindAsync(id);
            if (myEmp == null)
                return null;
            myEmp.IsActive = false;
            await _data.SaveChangesAsync();
            return myEmp;
        }

        public async Task<Employee> UpadtePositionsToEmployeeAsync(int id, List<EmployeePosition> positions)
        {
            var myEmp = await _data.Employees.Include(e => e.Positions)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (myEmp == null)
                return null;

            myEmp.Positions.Clear();
            await _data.SaveChangesAsync();

            await _data.EmployeePosition.AddRangeAsync(positions);

            //foreach (var item in positionsId)
            //{
            //    var positoin = await _data.Positions.FindAsync(item);
            //    if (positoin != null)
            //        myEmp.Positions.Add(positoin);
            //}
            await _data.SaveChangesAsync();
            return myEmp;
        }


        public async Task<Employee> DeleteFromDbAsync(int id)
        {
            var myEmp = await _data.Employees.Include(e => e.AttendanceJournals)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (myEmp == null)
                return null;

            myEmp.AttendanceJournals.Clear();

            var secMyEmp = await _data.Employees.Include(e => e.Positions)
                .FirstOrDefaultAsync(e => e.Id == id);
            secMyEmp.Positions.Clear();

            _data.Employees.Remove(secMyEmp);

            var result = await _termsRepository.DeleteAsync(secMyEmp.TermsId);
            //delete the bank account
            var myBank = await _data.BankAccounts.FindAsync(secMyEmp.BankAccountId);
            if(myBank != null)
                _data.BankAccounts.Remove(myBank);

            //await _data.SaveChangesAsync();
            return secMyEmp;
        }

    }
}
