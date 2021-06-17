using Domain.Interfaces;
using Domain.Interfaces.Services.Employee;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.API.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmployeeService, EmployeeService>();                        
            serviceCollection.AddTransient<IUtilitiesService, UtilitiesService>();                        
        }

    }
}
