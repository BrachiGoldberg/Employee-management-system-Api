using Employees.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Core.Services
{
    public interface IPositionService
    {
        public IEnumerable<Position> GetPositions();

        public Task<Position> AddNewPositionAsync(Position position);

    }
}
