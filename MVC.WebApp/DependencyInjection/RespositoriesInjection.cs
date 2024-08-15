using Core.Interfaces;
using DAL.Repositories;

namespace MVC.WebApp.DependencyInjection
{
    public static class RespositoriesInjection
    {
        public static IServiceCollection GetServices(this IServiceCollection services) {
            services.AddScoped<IAnotherRepository, AnotherRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();


            return services;
        }
    }
}
