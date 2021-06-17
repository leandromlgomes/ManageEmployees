using Domain.Interfaces;
using Domain.Interfaces.API.Services.Login;
using Domain.Interfaces.Services.Employee;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.API;

namespace CrossCutting.API.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();                        
            serviceCollection.AddTransient<IUtilitiesService, UtilitiesService>();                        
            serviceCollection.AddTransient<ILoginService, LoginService>();                        
        }

    }
}
