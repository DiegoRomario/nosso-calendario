using AutoMapper;
using NossoCalendario.Application.ViewModels;
using NossoCalendario.Domain.Entities;
using NossoCalendario.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NossoCalendario.Application.Queries
{
    public class UsuarioQueries : IUsuarioQueries
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioQueries(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioViewModel> AutenticarUsuario(UsuarioLoginViewModel login)
        {
#warning  IMPLEMENTAR CRIPTOGRAFIA
            Usuario usuario = await _usuarioRepository.GetBy(u => u.Email == login.Email && u.Senha == login.Senha);
            return _mapper.Map<UsuarioViewModel>(usuario);
        }
    }
}
