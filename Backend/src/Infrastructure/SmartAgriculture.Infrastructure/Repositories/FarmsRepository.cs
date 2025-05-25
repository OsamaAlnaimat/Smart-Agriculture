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
    internal class FarmsRepository(SmartAgriDbContext dbContext) : IFarmRepository
    {
        public async Task<IEnumerable<Farm>> GetAllAsync(string userId)
        {
            var farms = await dbContext.Farms
                .Where(f => f.FarmerId == userId)
                .Include(r =>r.Fields!)
                  .ThenInclude(field => field.soilData)
                .Include(f => f.WeatherReadings!)
                .ToListAsync();
            return farms;  
        } 
        
        public async Task<Farm?> GetByIdAsync(int id,string userId)
        {
            var farm = await dbContext.Farms
                .Where(f => f.FarmerId == userId)
                .Include(r => r.Fields!)
                    .ThenInclude(field => field.soilData)
                .Include(f => f.WeatherReadings!)
                .FirstOrDefaultAsync(x => x.Id == id);
            return farm;
        }
        
        public async Task<int> Create(Farm entity)
        {
            dbContext.Farms.Add(entity);    
            await dbContext.SaveChangesAsync();
            return entity.Id;
        } 
        
        public async Task Delete(Farm entity)
        {
            dbContext.Farms.Remove(entity);    
            await dbContext.SaveChangesAsync();
        }

        public Task SaveChanges()
         => dbContext.SaveChangesAsync();
        
    }
}
