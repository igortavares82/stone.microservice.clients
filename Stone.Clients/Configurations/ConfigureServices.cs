using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Framework.Data.Options;
using System.Configuration;

namespace Stone.Clients.WebApi.Configurations
{
    public static class ConfigureServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.Configure<FirebaseClientOptions>(options => Configuration.GetSection("FirebaseClient").Bind(options));
        }
    }
}
