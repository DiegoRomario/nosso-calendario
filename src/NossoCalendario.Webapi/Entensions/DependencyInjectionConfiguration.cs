using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NossoCalendario.Data.Repository;
using NossoCalendario.Domain.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace NossoCalendario.WebApi.Entensions
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}
