using Microsoft.Extensions.DependencyInjection;
using Stone.Clients.Application.Abstractions;
using Stone.Clients.Application.Concretes;
using Stone.Clients.Domain.Abstractions.EntityService;
using Stone.Clients.Domain.Concretes.EntityService;
using Stone.Clients.Infrastructure.Abstractions;
using Stone.Clients.Infrastructure.Concretes;

namespace Stone.Clients.DependencyInjection
{
    public static class DIFactory
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IClientApplication, ClientApplication>();
            services.AddScoped<IClientEntityService, ClientEntityService>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
