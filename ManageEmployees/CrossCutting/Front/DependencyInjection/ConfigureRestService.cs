using Domain.Interfaces;
using Domain.Interfaces.Front.Services;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Front;

namespace CrossCutting.Front.DependencyInjection
{
    public class ConfigureRestService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmployeeRestService, EmployeeRestService>();                        
            serviceCollection.AddTransient<IUtilitiesService, UtilitiesService>();                        
            serviceCollection.AddTransient<ILoginRestService, LoginRestService>();                        
        }

    }
}
