using Employees.Core.Entites;

namespace EmployeeManagement.Api.Models
{
    public class CompanyPostModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Manager Manager { get; set; }

    }
}
