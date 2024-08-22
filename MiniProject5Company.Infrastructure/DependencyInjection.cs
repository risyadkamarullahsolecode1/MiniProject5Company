using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniProject5Company.Application.Interfaces;
using MiniProject5Company.Application.Services;
using MiniProject5Company.Domain.Interfaces;
using MiniProject5Company.Infrastructure.Data;
using MiniProject5Company.Infrastructure.Data.Repository;

namespace MiniProject5Company.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CompanyFinancialContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IWorksonRepository, WorksonRepository>();
            services.AddScoped<IDependantRepository, DependantRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
