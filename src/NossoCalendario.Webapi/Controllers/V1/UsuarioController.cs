using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NossoCalendario.Data.Repository;
using NossoCalendario.Domain.Entities;
using NossoCalendario.WebApi.Helpers;
using NossoCalendario.WebApi.ViewModels;

namespace NossoCalendario.WebApi.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly AgendaRepository _agendaRepository;

        public UsuarioController(UsuarioRepository usuarioRepository, AgendaRepository agendaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _agendaRepository = agendaRepository;
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> CadastrarUsuario([FromBody] UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Usuario novoUsuario = await _usuarioRepository.Insert(new Usuario(usuario.Nome, usuario.Email, PasswordEncryptorHelper.Hash(usuario.Senha)));
            await _agendaRepository.Insert(new Agenda(novoUsuario));
            await _agendaRepository.SaveChangesAsync();
            return Ok(value: usuario);
        }


    }
}