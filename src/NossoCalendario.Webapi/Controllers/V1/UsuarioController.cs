using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NossoCalendario.Application.Base;
using NossoCalendario.Application.Commands;
using NossoCalendario.Application.Queries;
using NossoCalendario.Application.ViewModels;
using NossoCalendario.Domain.Base;
using NossoCalendario.WebApi.Entensions;


namespace NossoCalendario.WebApi.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IMediator _mediator;
        private readonly IUsuarioQueries _usuarioQueries;
        private readonly IUser _user;
        public UsuarioController(
            IOptions<AppSettings> appSettings, IMediator mediator, IUsuarioQueries usuarioQueries, IUser user)
        {
            _appSettings = appSettings.Value;
            _mediator = mediator;
            _usuarioQueries = usuarioQueries;
            _user = user;
        }


        [HttpPost("entrar")]
        [AllowAnonymous]
        public async Task <ActionResult<UsuarioAutenticadoViewModel>> Login ([FromBody] UsuarioLoginViewModel usuarioLogin) 
        {
            #warning  IMPLEMENTAR CONTROLLER BASE
            UsuarioViewModel usuario = await _usuarioQueries.AutenticarUsuario(usuarioLogin);
            if (usuario != null)
                return await GerarToken(usuario);
            else
                return BadRequest("Usuário e/ou senha inválidos!");
        }   

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> CadastrarUsuario([FromBody] CadastrarUsuarioCommand usuario)
        {
            #warning  IMPLEMENTAR CONTROLLER BASE
            Response response = await _mediator.Send(usuario).ConfigureAwait(false);

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }

        [HttpPut("alterar/{id:guid}")]
        public async Task<ActionResult> AlterarUsuario(Guid id, AlterarUsuarioCommand usuario)
        {
            #warning  IMPLEMENTAR CONTROLLER BASE
            if (id != usuario.Id)
                return BadRequest("O Id do usuário não corresponde ao Id solicitado para alteração");
            if (_user.GetUserEmail() != usuario.Email)
                return BadRequest("O E-mail informado não corresponde ao e-mail logado");
            Response response = await _mediator.Send(usuario).ConfigureAwait(false);

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
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
                Id = user.Id,
                Nome = user.Nome,
                Token = encodedToken,
                ExpiraEm = Expires_in,
                Email = user.Email
            };
            return await Task.FromResult(response);

        }

    }
}