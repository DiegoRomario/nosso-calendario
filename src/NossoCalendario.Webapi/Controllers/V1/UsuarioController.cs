using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NossoCalendario.Domain.Entities;
using NossoCalendario.Domain.Interfaces;
using NossoCalendario.WebApi.Controllers.Base;
using NossoCalendario.WebApi.Entensions;
using NossoCalendario.WebApi.ViewModels;

namespace NossoCalendario.WebApi.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> CadastrarUsuario([FromBody] CadastrarUsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _usuarioRepository.Insert(new Usuario(usuario.Nome, usuario.Email, usuario.Senha.ToHash()));
            return Ok(value: usuario);
        }


    }
}