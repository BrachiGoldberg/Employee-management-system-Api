﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Entites
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description{ get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Manager Manager { get; set; }

        //public int ManagerId { get; set; }
        //public Employee Manager { get; set; }

        //public int ManagerId { get; set; }

        public CompanyTerms Terms { get; set; }

        public int TermsId { get; set; }

        public List<Employee> Employees { get; set;}

    }
}
