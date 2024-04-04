using Employees.Core.Entites;
using Employees.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Data.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataContext _data;
        public PositionRepository(DataContext data)
        {
            _data = data;
        }

        public IEnumerable<Position> GetPositions()
        {
            return _data.Positions;
        }

        public async Task<Position> AddNewPositionAsync(Position position)
        {
            if (position == null)
                return null;
            var exists = _data.Positions.Any(p => p.Name.ToLower() == position.Name.ToLower());
            if (exists)
                return null;
            _data.Positions.Add(position);
            await _data.SaveChangesAsync();
            return position;
        }


    }
}
