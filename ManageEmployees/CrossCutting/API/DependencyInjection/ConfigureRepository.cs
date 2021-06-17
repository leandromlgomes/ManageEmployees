
using Data.Repository;
using Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.API.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

        }
    }
}
