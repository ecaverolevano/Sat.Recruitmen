using Sat.Recruitment.Application.Common.Interfaces;
using Sat.Recruitment.Infrastructure.Persistence;
using Sat.Recruitment.Infrastructure.Persistence.Interceptors;
using Sat.Recruitment.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Distillery.Infrastructure.Persistence;
using Domain.Ports.Repositories;
using Infraestructure.Persistance.Repositories;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        services.AddScoped<IUserRepository, UserRepository>();

        //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        //{
        //    services.AddDbContext<IApplicationDbContext>(options => options.UseInMemoryDatabase("SatRecruitment"));
        //}
        //else
        //{
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        //}

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<IDateTime, DateTimeService>();
        

        services.AddAuthentication();

        //services.AddAuthorization(options =>
        //    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
