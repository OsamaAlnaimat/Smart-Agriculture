using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartAgriculture.Domain.Constants;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Infrastructure.Seeders
{
    internal class SmartAgricultureSeeder(SmartAgriDbContext dbContext) : ISmartAgricultureSeeder
    {
        public async Task Seed()
        {
            if( dbContext.Database.GetPendingMigrations().Any())
            {
                await dbContext.Database.MigrateAsync();
            }

            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Farms.Any())
                {
                    var farms = GetFarms();
                    dbContext.AddRange(farms);
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }
            }  
        }

        private IEnumerable<IdentityRole> GetRoles() 
        {
            List<IdentityRole> roles =
                [
                    new(UserRoles.Farmer)
                    {
                        NormalizedName = UserRoles.Farmer.ToUpper()
                    },
                    new(UserRoles.Admin)
                    {
                        NormalizedName = UserRoles.Admin.ToUpper()
                    },                  
                ];

            return roles;
        }

        private IEnumerable<Farm> GetFarms()
        {
            User owner = new User()
            {
                Email = "seed-user@test.com"
            };

            List<Farm> farms = new List<Farm>
            {
                new Farm
                {
                    Farmer = owner,
                    FarmName = "Green Valley",
                    FarmSize = 100.5,
                    FramLocation = "Irbid",
                    Fields = new List<Field>
                    {
                        new Field
                        {

                            FieldName = "Tomato Field",
                            FieldSize = 25,
                            CropType = "Tomatoes",
                            soilData =
                                new SoilData
                                {

                                    SoilPH = 6.5,
                                    Nitrogen = 10,
                                    Phosphorus = 15,
                                    Potassium = 20,
                                    SoilTexture = "Loamy",
                                    SoilMoisture = 30.2,
                                    SoilOrganicMatter = 2.3,
                                    CollectedAt = DateTime.Now
                                },
                            recommendation = []

                        },
                        new Field
                        {

                            FieldName = "Wheat Field",
                            FieldSize = 30,
                            CropType = "Wheat",
                            soilData =
                                new SoilData
                                {

                                    SoilPH = 7.2,
                                    Nitrogen = 18,
                                    Phosphorus = 8,
                                    Potassium = 12,
                                    SoilTexture = "Sandy Loam",
                                    SoilMoisture = 22.1,
                                    SoilOrganicMatter = 1.8,
                                    CollectedAt = DateTime.Now
                                }
                            ,
                            recommendation = []
                            
                        }
                    },
                    WeatherReadings = new List<WeatherData>
                    {
                        new WeatherData
                        {
                            Temperature = 27,
                            Precipition = 12,
                            Humidity = 65,
                            WindSpeed = 10,
                            CollectedAt = DateTime.Now
                        }
                    }

                },
                new Farm
                {
                    Farmer = owner,
                    FarmName = "Desert Bloom",
                    FarmSize = 80,
                    FramLocation = "Mafraq",
                    Fields = new List<Field>
                    {

                    },
                    WeatherReadings = new List<WeatherData>
                    {
                        new WeatherData
                        {

                            Temperature = 31,
                            Precipition = 4,
                            Humidity = 40,
                            WindSpeed = 20,
                            CollectedAt = DateTime.Now
                        }
                    }
                }
            };
            return farms;
        }
    }
}
