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
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _repository;

        public BankAccountService(IBankAccountRepository repository)
        {
            _repository = repository;
        }



        public Task<BankAccount> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<BankAccount> AddAsync(BankAccount bankAccount)
        {
            return _repository.AddAsync(bankAccount);
        }

        public Task<BankAccount> UpdateAsync(int id, BankAccount bankAccount)
        {
            return _repository.UpdateAsync(id, bankAccount);
        }

        public Task<BankAccount> DeleteAsync(int id)
        {
           return _repository.DeleteAsync(id);
        }

    }
}
