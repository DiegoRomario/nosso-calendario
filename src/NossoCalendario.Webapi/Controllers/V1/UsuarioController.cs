using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NossoCalendario.WebApi.Entensions;
using NossoCalendario.WebApi.ViewModel;

namespace NossoCalendario.WebApi.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        public UsuarioController(
            IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task <ActionResult<UsuarioAutenticadoViewModel>> Login ([FromBody] UsuarioLoginViewModel usuarioLogin) 
        {
            // BUSCAR USUARIO NA BASE DE DADOS
            // VALIDAR
            return await GerarToken(new UsuarioViewModel() { Id = Guid.NewGuid(), Email = "email@email.com.br", Nome = "demo", });
        }


        private async Task<UsuarioAutenticadoViewModel> GerarToken (UsuarioViewModel user)
        {
            Claim[] claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.Nome.ToString()),
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Chave);
            DateTime Expires_in = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = new ClaimsIdentity(claims),
                Expires = Expires_in,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string encodedToken = tokenHandler.WriteToken(token);

            var response = new UsuarioAutenticadoViewModel()
            {
                Nome = user.Nome,
                Token = encodedToken,
                ExpiraEm = Expires_in,
                Email = user.Email
            };
            return await Task.FromResult(response);

        }

    }
}