using demo.proyect_persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace demo.proyect_persistance;

public static class Dependencie
{
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DemoProjectApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("demoProjectDatabaseConnection")));
    }
}
