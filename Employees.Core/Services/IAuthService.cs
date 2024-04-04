using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IAuthService
    {
        public Task<Company> Login(string userName, string password);

        public Task<Company> RegisterAsync(Company company);

    }
}
