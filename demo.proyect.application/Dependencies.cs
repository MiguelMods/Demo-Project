using demo.proyect.application.Services.Contract;
using demo.proyect.application.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace demo.proyect.application;

public static class Dependencies
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProjectInitativeService, ProjectInitativeService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPositionService, PositionService>();
    }
}
