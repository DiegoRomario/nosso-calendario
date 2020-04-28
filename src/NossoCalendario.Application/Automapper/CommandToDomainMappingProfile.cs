using AutoMapper;
using NossoCalendario.Application.Commands;
using NossoCalendario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoCalendario.Application.Automapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<AlterarUsuarioCommand, Usuario>();

        }
    }
}
