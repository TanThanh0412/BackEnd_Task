using Application.Abstractions;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfratructureServices(this IServiceCollection services)
        {
            services.AddTransient<ITasksRepository, TasksRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
