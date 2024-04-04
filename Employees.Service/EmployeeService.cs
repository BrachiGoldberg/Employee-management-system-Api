using Employees.Core.Entites;
using Employees.Core.Repositories;
using Employees.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Service
{
    public class EmployeeService : IEmployeeSerivce
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAll(int companyId)
        {
            return _repository.GetAll(companyId);
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Employee> AddNewAsync(Employee employee)
        {
            return await _repository.AddNewAsync(employee);
        }

        public async Task<Employee> UpdateAsync(int id, Employee employee)
        {
            return await _repository.UpdateAsync(id, employee);
        }

        public async Task<Employee> UpdateStatusAsync(int id)
        {
            return await _repository.UpdateStatusAsync(id);
        }

        //public async Task<Employee> AddPositionAsync(int id, int positionId)
        //{
        //    return await _repository.AddPositionAsync(id, positionId);
        //}

        //public async Task<Employee> RemovePositionAsync(int id, int positinId)
        //{
        //    return await _repository.RemovePositionAsync(id, positinId);
        //}
        public async Task<Employee> UpadtePositionsToEmployeeAsync(int id, List<EmployeePosition> positions)
        {
            return await _repository.UpadtePositionsToEmployeeAsync(id, positions);
        }

        public async Task<Employee> DeleteFromDbAsync(int id)
        {
            return await _repository.DeleteFromDbAsync(id);
        }
    }
}
