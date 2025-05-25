using Serilog;
using SmartAgriculture.Application.Extensions;
using SmartAgriculture.Domain.Entities;
using SmartAgriculture.Infrastructure.Extensions;
using SmartAgriculture.Infrastructure.Seeders;
using SmartAgricultureAPI.Extensions;
using SmartAgricultureAPI.Middlewares;
using Microsoft.Extensions.AI;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    });


    var app = builder.Build();
    app.UseCors("AllowAll");

    var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<ISmartAgricultureSeeder>();

    await seeder.Seed();

    app.UseSerilogRequestLogging();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestTimeLoggingMiddleware>();

    app.UseHttpsRedirection();

    app.MapGroup("api/identity")
        .WithTags("Identity")
        .MapIdentityApi<User>();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}catch(Exception ex)
{
    Log.Fatal(ex, "Application startup Faild");

}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }