using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NossoCalendario.Application.Commands;
using NossoCalendario.Domain.Base;


namespace NossoCalendario.WebApi.Controllers.V1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult> CadastrarUsuario([FromBody] CadastrarUsuarioCommand usuario)
        {
            Response response = await _mediator.Send(usuario).ConfigureAwait(false);

            if (response.Errors.Any())
                return BadRequest(response.Errors);

            return Ok(response.Result);
        }


    }
}