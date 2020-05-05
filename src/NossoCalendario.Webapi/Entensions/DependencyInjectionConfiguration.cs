using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NossoCalendario.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace NossoCalendario.WebApi.Entensions
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddTransient<UsuarioRepository>();
            services.AddTransient<AgendaRepository>();
            return services;
        }
    }
}
