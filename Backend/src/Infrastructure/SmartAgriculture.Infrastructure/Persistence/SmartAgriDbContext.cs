using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartAgriculture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Infrastructure.Persistence
{
    internal class SmartAgriDbContext(DbContextOptions<SmartAgriDbContext> options) : 
        IdentityDbContext<User>(options)
    {
        internal DbSet<Farm> Farms { get; set; }
        internal DbSet<Field> Fields { get; set; }
        internal DbSet<SoilData> SoilDatas { get; set; }
        internal DbSet<Recommendation> Recommendations { get; set; }
        internal DbSet<WeatherData> WeatherDatas { get; set; }
        internal DbSet<chatMessage> ChatMessages { get; set; }
    }
}
