using Application.Services.Refit;
using Domain.Interfaces;
using Domain.Interfaces.Worker;
using Infrastructure.Configuration;
using Infrastructure.Requests.Refit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Refit;

namespace Application.DependencyInjection
{
    public static class AppBootstrapper
    {
        public static IServiceCollection AddAppBootstrapper(this IServiceCollection services, IConfiguration configuration)
        { 
            if(services == null)
                throw new ArgumentNullException(nameof(services));
            services.AddSingleton(typeof(IAppLogger<>), typeof(EventViewerLogger<>));

            //services.AddScoped<> Add Refit Service Scope after


            //If you want connect with database...
            //services.AddScoped<IConnectionFactory>, YourServerConnFactory();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Registering your integration Repositories
            //services.AddScoped<IJsonPlaceholderApiRepository, JsonPlaceholderApiRepository>();

            //Registering your integration Services
            //services.AddScoped<JPlaceholderPostService>();
            //services.AddScoped<ApiPostService>();

            //Registering your Refit service
            //services.AddRefitClient<IJsonPlaceholderApi>()
            //    .RestService.For<IJsonPlaceholderApi>("https://jsonplaceholder.typicode.com");
            return services;
        }
    }
}
