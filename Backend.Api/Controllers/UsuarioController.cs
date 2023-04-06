using BackendTest.Application.Models.Usuarios;
using BackendTest.Application.Service.Interfaces.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;


        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioResponse))]
        public async Task<IActionResult> Post([FromQuery] UsuarioRequest usuarioRequest)
        {

            var client = await _usuarioService.Create(usuarioRequest);

            return Ok(client);
        }

        /*/// <summary>
        /// Obtém Usuários de acordo com parâmetros passados
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("Filter")]
        public async Task<ActionResult<UsuarioResponse>> GetByFilter([FromQuery] UsuarioRequest request)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsersByFilter(request);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/
    }
}
