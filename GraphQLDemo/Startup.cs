using GraphQLDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPersonRepository, PersonRepository>();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<GraphQlMiddleware>();
        }
    }
}
