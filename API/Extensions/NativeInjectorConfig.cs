using Entities.Context;
using Infrastructure.Implementations;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection")!;

            services.AddDbContext<Context>(options => options.UseSqlServer(connection).EnableSensitiveDataLogging());

            services.AddScoped<IHabitDAO, HabitDAO>();
            services.AddScoped<IUserDAO, UserDAO>();
        }
    }
}