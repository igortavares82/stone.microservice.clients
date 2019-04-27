﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Framework.Data.Options;

namespace Stone.Clients.WebApi.Configurations
{
    public static class ConfigureServices
    {
        internal static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FirebaseClientOptions>(options => 
            {
                configuration.GetSection("FirebaseClientOptions").Bind(options);
                options.SetAuthToken();
            });
        }
    }
}
