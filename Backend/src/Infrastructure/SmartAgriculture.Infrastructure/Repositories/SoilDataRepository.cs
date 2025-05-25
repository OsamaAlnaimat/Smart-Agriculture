using Microsoft.EntityFrameworkCore;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Repositories;
using SmartAgriculture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Infrastructure.Repositories
{
    internal class SoilDataRepository(SmartAgriDbContext dbContext) : ISoilDataRepository
    {
        public async Task<int> Create(SoilData entity)
        {
            dbContext.SoilDatas.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity.Id;
        }
    }
}
