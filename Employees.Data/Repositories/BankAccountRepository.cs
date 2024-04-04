using Employees.Core.Entites;
using Employees.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly DataContext _data;

        public BankAccountRepository(DataContext data)
        {
            _data = data;
        }

        public async Task<BankAccount> GetByIdAsync(int id)
        {
            return await _data.BankAccounts.FindAsync(id);
        }

        public async Task<BankAccount> AddAsync(BankAccount bankAccount)
        {
            if (bankAccount == null)
                return null;
            _data.BankAccounts.Add(bankAccount);
            await _data.SaveChangesAsync();
            return bankAccount;
        }

        public async Task<BankAccount> UpdateAsync(int id, BankAccount bankAccount)
        {
            var myBank = await _data.BankAccounts.FindAsync(id);
            if (myBank == null || bankAccount == null)
                return null;
            myBank.BankAccountNumber = bankAccount.BankAccountNumber;
            myBank.BranchNumber = bankAccount.BranchNumber;
            myBank.BankNunber = bankAccount.BankNunber;

            await _data.SaveChangesAsync();
            return myBank;
        }

        public async Task<BankAccount> DeleteAsync(int id)
        {
            var myBank = await _data.BankAccounts.FindAsync(id);
            if (myBank == null)
                return null;
            _data.BankAccounts.Remove(myBank);
            await _data.SaveChangesAsync();
            return myBank;
        }
    }
}
