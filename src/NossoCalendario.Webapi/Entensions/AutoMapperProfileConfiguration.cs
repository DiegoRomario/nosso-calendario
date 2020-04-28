using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NossoCalendario.Application.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NossoCalendario.WebApi.Entensions
{
    public static class AutoMapperProfileConfiguration
    {
        public static IServiceCollection AddAutoMapperProfileConfiguration (this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
            return services;
        }
    }
}
