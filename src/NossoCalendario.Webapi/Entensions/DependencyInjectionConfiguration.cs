using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NossoCalendario.Application.Base;
using NossoCalendario.Application.Queries;
using NossoCalendario.Data.Repository;
using NossoCalendario.Domain.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NossoCalendario.WebApi.Entensions
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUser, AspNetUser>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddTransient<IUsuarioQueries, UsuarioQueries>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
