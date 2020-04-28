using AutoMapper;
using MediatR;
using NossoCalendario.Application.Base;
using NossoCalendario.Application.Commands;
using NossoCalendario.Domain.Base;
using NossoCalendario.Domain.Entities;
using NossoCalendario.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NossoCalendario.Application.Handlers
{
    public class UsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, Response>, IRequestHandler<AlterarUsuarioCommand, Response>

    {
        private readonly IUsuarioRepository _usuarioRepository;
        public readonly IUser _user;
        public readonly IMapper _mappper;
        public UsuarioHandler(IUsuarioRepository usuarioRepository, IUser user, IMapper mappper)
        {
            _usuarioRepository = usuarioRepository;
            _user = user;
            _mappper = mappper;
        }

        public async Task<Response> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            _usuarioRepository.InserirUsuario(new Usuario(request.Nome, request.Email, request.Senha));
            await _usuarioRepository.UnitOfWork.Commit();
            return new Response("Usuário cadastrado com sucesso!");
        }

        public async Task<Response> Handle(AlterarUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = _mappper.Map<Usuario>(request);
            _usuarioRepository.AlterarUsuario(usuario);
            await _usuarioRepository.UnitOfWork.Commit();
            return new Response("Usuário alterado com sucesso!");
        }
    }
}
