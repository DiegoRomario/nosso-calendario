using AutoMapper;
using NossoCalendario.Application.ViewModels;
using NossoCalendario.Domain.Entities;

namespace NossoCalendario.Application.Automapper
{
    public class DomainToViewModelMappingProfile : Profile 
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(v => v.Email, d => d.MapFrom(u => u.Email))
                .ForMember(v => v.Nome, d => d.MapFrom(u => u.Nome))
                .ForMember(v => v.Id, d => d.MapFrom(u => u.Id));
        }
    }
}
