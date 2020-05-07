using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> CadastrarUsuario([FromBody] UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Usuario novoUsuario = await _usuarioRepository.Insert(new Usuario(usuario.Nome, usuario.Email, PasswordEncryptorHelper.Hash(usuario.Senha)));
            await _usuarioRepository.SaveChangesAsync();
            return Ok(value: usuario);
        }

        [HttpPost("entrar")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromBody] UsuarioLoginViewModel login)
        {
            return await GerarToken(login.Email);
        }

        private async Task<string> GerarToken(string login)
        {
            Claim[] claims = new Claim[] {
                new Claim(ClaimTypes.Email, login),
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes("M1NH4CH4V35UP3R53CR474");
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "NossoCalendario",
                Audience = "https://localhost",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string encodedToken = tokenHandler.WriteToken(token);
            return await Task.FromResult(encodedToken);
        }

    }
}