using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Domain.Repositories
{
    public interface IFarmRepository
    {
        Task<IEnumerable<Farm>> GetAllAsync();
        Task<Farm?> GetByIdAsync(int id);
        Task<int> Create(Farm entity);
        Task Delete(Farm entity);
        Task SaveChanges();
    }
}
