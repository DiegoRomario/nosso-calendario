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

        public UsuarioHandler(IUsuarioRepository usuarioRepository, IUser user)
        {
            _usuarioRepository = usuarioRepository;
            _user = user;
        }

        public async Task<Response> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            _usuarioRepository.Insert(new Usuario(request.Nome, request.Email, request.Senha));
            await _usuarioRepository.UnitOfWork.Commit();
            return new Response("Usuário cadastrado com sucesso!");
        }

        public async Task<Response> Handle(AlterarUsuarioCommand request, CancellationToken cancellationToken)
        {
            _usuarioRepository.Update(new Usuario(request.Nome, _user.GetUserEmail(), request.Senha));
            await _usuarioRepository.UnitOfWork.Commit();
            return new Response("Usuário alterado com sucesso!");
        }
    }
}
