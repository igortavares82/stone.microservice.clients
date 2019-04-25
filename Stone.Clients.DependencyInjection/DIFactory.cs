using Microsoft.Extensions.DependencyInjection;
using Stone.Clients.Infrastructure.Abstractions;
using Stone.Clients.Infrastructure.Concretes;
using Stone.Framework.Data.Options;

namespace Stone.Clients.DependencyInjection
{
    public static class DIFactory
    {
        public static void Configure(IServiceCollection services)
        {
            ConfigureInfrastructure(services);
        }

        private static void ConfigureInfrastructure(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
