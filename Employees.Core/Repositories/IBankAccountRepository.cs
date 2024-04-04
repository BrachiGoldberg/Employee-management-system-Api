using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Repositories
{
    public interface IBankAccountRepository
    {
        public Task<BankAccount> GetByIdAsync(int id);

        public Task<BankAccount> AddAsync(BankAccount bankAccount);

        public Task<BankAccount> UpdateAsync(int id, BankAccount bankAccount);

        public Task<BankAccount> DeleteAsync(int id);
    }
}
