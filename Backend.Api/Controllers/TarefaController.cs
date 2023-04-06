using BackendTest.Application.Models.Tarefas;
using BackendTest.Application.Models.Usuarios;
using BackendTest.Application.Service.Interfaces.Tarefas;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;


        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        #region Metodos Principais
        /// <summary>
        /// Cria Tarefa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaResponse))]
        public async Task<IActionResult> Post([FromQuery] TarefaRequest request)
        {

            var tarefa = await _tarefaService.Create(request);

            return Ok(tarefa);
        }

        /// <summary>
        /// Cria Tarefa
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("File")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaResponse))]
        public async Task<IActionResult> PostFile([FromQuery] int id, IFormFile arquivo)
        {

            await _tarefaService.AnexarArquivo(id, arquivo);

            return Ok();
        }

        /// <summary>
        /// Obtém Tarefa de acordo com o Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Filter")]
        public async Task<ActionResult<TarefaResponse>> GetByFilter(int id)
        {
            try
            {
                var tarefa = await _tarefaService.Find(id);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Obtém tempo de andamento de Tarefa de acordo com o Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Progress")]
        public async Task<ActionResult<TimeSpan>> GetByProgressTime(int id)
        {
            try
            {
                var tarefa = await _tarefaService.FindProgress(id);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Edita Tarefa de acordo com o Id atualizando os parâmetros passados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tarefaRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromQuery] TarefaRequest tarefaRequest)
        {

            var tarefa = await _tarefaService.Edit(id, tarefaRequest);

            return Ok(tarefa);
        }
        #endregion

        #region Metodos Desafio

        /// <summary>
        /// Cria Tarefa associada ao João Silva agendada para o dia 31/12/2023
        /// </summary>
        /// <returns></returns>
        [HttpPost("PersonalizadoJoao")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaResponse))]
        public async Task<IActionResult> PostTaskJoao()
        {

            var tarefa = await _tarefaService.CreateJoaoSilva();

            return Ok(tarefa);
        }

        /// <summary>
        /// Cria Tarefa associada a Ana Silva agendada para o dia de hoje
        /// </summary>
        /// <returns></returns>
        [HttpPost("PersonalizadoAna")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaResponse))]
        public async Task<IActionResult> PostTaskAna()
        {

            var tarefa = await _tarefaService.CreateAnaSilva();

            return Ok(tarefa);
        }

        /// <summary>
        /// Edita Tarefa de ana para Em Andamento
        /// </summary>
        /// <returns></returns>
        [HttpPut("PersonalizadoAna")]
        public async Task<IActionResult> PutTaskAna()
        {

            var tarefa = await _tarefaService.EditAna();

            return Ok(tarefa);
        }

        #endregion
    }
}
