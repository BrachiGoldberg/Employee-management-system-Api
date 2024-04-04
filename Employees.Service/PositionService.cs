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
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repository;
        public PositionService(IPositionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Position> GetPositions()
        {
            return _repository.GetPositions();
        }

        public Task<Position> AddNewPositionAsync(Position position)
        {
            return _repository.AddNewPositionAsync(position);
        }
    }
}
