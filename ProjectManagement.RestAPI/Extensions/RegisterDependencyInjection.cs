using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.RestAPI.Contracts.Persistence;
using ProjectManagement.RestAPI.DataContext;
using ProjectManagement.RestAPI.Repositories;
using ProjectManagement.RestAPI.Service.Interface;
using ProjectManagement.RestAPI.Services;
using ProjectManagement.RestAPI.Services.Interfaces;
using ProjectManagement.RestAPI.Validation.UserValidation;
using System.Reflection;

namespace ProjectManagement.RestAPI.Extensions;

public static class RegisterDependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddDbContext<ApplicationDBContext>(options => {
            options.UseNpgsql(configuration.GetConnectionString("ApplicationDatabaseConnectionString"));
        });

        services.AddValidatorsFromAssemblyContaining<UserCreateValidation>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IWorkTaskService,WorkTaskService>();
        services.AddScoped<ITeamService,TeamService>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IWorkTaskRepository, WorkTaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        return services;
    }
}
