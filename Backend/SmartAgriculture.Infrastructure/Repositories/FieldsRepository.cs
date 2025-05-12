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
    internal class FieldsRepository(SmartAgriDbContext dbContext) : IFieldsRepository
    {
        public async Task<int> Create(Field entity)
        {
            dbContext.Fields.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(Field entity)
        {
            dbContext.Fields.Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
