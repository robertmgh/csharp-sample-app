using csharp_sample_app.Application.Services;
using csharp_sample_app.Core.Repositories;
using csharp_sample_app.Infrastructure.Mongo.Repositories;
using csharp_sample_app.Infrastructure.Mongo.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace csharp_sample_app.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UsersDatabaseSettings>(configuration.GetSection(nameof(UsersDatabaseSettings)));

            services.AddSingleton<IUsersDatabaseSettings>(sp =>
                sp.GetRequiredService<Microsoft.Extensions.Options.IOptions<UsersDatabaseSettings>>().Value);

            services.AddScoped<IUsersRepository, UsersMongoRepository>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
