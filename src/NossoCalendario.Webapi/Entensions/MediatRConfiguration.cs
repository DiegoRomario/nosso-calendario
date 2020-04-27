using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NossoCalendario.Application.Base;
using System;
using System.Reflection;


namespace NossoCalendario.WebApi.Entensions
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatRConfigurations(this IServiceCollection services)
        {
            Assembly assembly = AppDomain.CurrentDomain.Load("NossoCalendario.Application");
            AssemblyScanner.FindValidatorsInAssembly(assembly)
                 .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(assembly);
            return services;
        }
    }
}
