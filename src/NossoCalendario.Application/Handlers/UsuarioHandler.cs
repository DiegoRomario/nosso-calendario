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
    public class UsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, Response>

    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Response> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            _usuarioRepository.InserirUsuario(new Usuario(request.Nome, request.Email, request.Senha));
            await _usuarioRepository.UnitOfWork.Commit();
            return new Response("Usuário cadastrado com sucesso!");
        }

    }
}
