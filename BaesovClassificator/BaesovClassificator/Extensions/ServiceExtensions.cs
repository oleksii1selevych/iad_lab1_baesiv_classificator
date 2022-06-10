using BaesovClassificator.Contracts.Logging;
using BaesovClassificator.Contracts.Repository;
using BaesovClassificator.Contracts.Services;
using BaesovClassificator.Data;
using BaesovClassificator.Data.Repository;
using BaesovClassificator.Services;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Reflection;

namespace BaesovClassificator.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public static void ConfigureLoggerManager(this IServiceCollection services, string applicationDirectory)
        {
            LogManager.LoadConfiguration(string.Concat(applicationDirectory, "/nlog.config"));
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default Connection"));
            });
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
