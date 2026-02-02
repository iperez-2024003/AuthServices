using AuthService2024003.Application.Interfaces;
using AuthService2024003.Domain.Interfaces;
using AuthService2024003.Persistence.Data;
using AuthService2024003.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthService2024003.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UserNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvetions());

     services.AddScoped<IUserRepository, UserRepository>();
     services.AddScoped<IRoleRepository, RoleRepository>();

     services.AddHealthChecks();

     return services;
}

    public static IServiceCollection AddApiDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
   

 }