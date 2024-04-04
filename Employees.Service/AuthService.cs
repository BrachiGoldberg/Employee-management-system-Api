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
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }


        public async Task<Company> Login(string userName, string password)
        {
            return await _repository.Login(userName, password);
        }

        public async Task<Company> RegisterAsync(Company company)
        {
            return await _repository.RegisterAsync(company);
        }
    }
}
