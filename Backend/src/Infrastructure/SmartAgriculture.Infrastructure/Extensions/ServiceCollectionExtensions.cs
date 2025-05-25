using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Domain.Repositories;
using SmartAgriculture.Infrastructure.Persistence;
using SmartAgriculture.Infrastructure.Repositories;
using SmartAgriculture.Infrastructure.Seeders;

namespace SmartAgriculture.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration )
    {
        var connectionString = configuration.GetConnectionString("SmartAgriDb");
        services.AddDbContext<SmartAgriDbContext>(options => 
            options.UseSqlServer(connectionString)
                 .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SmartAgriDbContext>();

        services.AddScoped<ISmartAgricultureSeeder, SmartAgricultureSeeder>();
        services.AddScoped<IFarmRepository, FarmsRepository>();
        services.AddScoped<IFieldsRepository,FieldsRepository >();
        services.AddScoped<ISoilDataRepository,SoilDataRepository >();
        services.AddScoped<IWeatherRepository, WeatherRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IRecommendationRepository,RecommendationRepository>();

        services.AddHttpClient();
    }
}
