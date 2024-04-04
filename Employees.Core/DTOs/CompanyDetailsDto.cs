using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.DTOs
{
    public class CompanyDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public Manager Manager { get; set; }

        public int TermsId { get; set; }

    }
}
