using ArchitectureRecognition.Data;
using ArchitectureRecognition.Models.RecognitionResult;
using ArchitectureRecognition.Services.Data.Abstract;
using ArchitectureRecognition.Services.RecognitionResult;
using ArchitectureRecognition.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArchitectureRecognition.Configuration
{
    public static class DependencyRegistrar
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppDb"));
            });

            services.AddScoped<IRecognitionResultRepository, RecognitionResultRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRecognitionResultService, RecognitionResultService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IRecognitionResultMapper, RecognitionResultMapper>();
        }
    }
}
