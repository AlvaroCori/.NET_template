using Microsoft.AspNetCore.Mvc;
using template_dotnet.DTO;
using template_dotnet.Models;
using template_dotnet.Models.Responses;
using template_dotnet.Services;
using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace template_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SSRExampleController : ControllerBase
    {
        private readonly ISSRExampleService _service;
        private readonly ILogger<SSRExampleController> _logger;

        public SSRExampleController(
            ISSRExampleService service,
            ILogger<SSRExampleController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<SSRExampleModel>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.GetSSRExamples();
                return Ok(new ApiResponse<IEnumerable<SSRExampleModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener SSRExamples");
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ApiResponse<string>("Ocurrió un error al procesar la solicitud"));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<SSRExampleModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var result = await _service.GetSSRExample(id);

                if (result == null)
                {
                    return NotFound(new ApiResponse<string>($"Registro con ID {id} no encontrado"));
                }

                return Ok(new ApiResponse<SSRExampleModel>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener SSRExample con ID {id}");
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ApiResponse<string>("Ocurrió un error al procesar la solicitud"));
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<SSRExampleModel>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] SSRExampleDTO example)
        {
            try
            {
                /*
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<ModelStateDictionary>(ModelState));
                }
                */

                var result = await _service.PostSSRExamples(example);
                return CreatedAtAction(
                    nameof(GetOne),
                    new { id = result.Id },
                    new ApiResponse<SSRExampleModel>(result));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear SSRExample");
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ApiResponse<string>("Ocurrió un error al crear el registro"));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<SSRExampleModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, [FromBody] SSRExampleDTO example)
        {
            try
            {
                /*
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<ModelStateDictionary>(ModelState));
                }
                */

                var result = await _service.UpdateSSRExample(id, example);
                return Ok(new ApiResponse<SSRExampleModel>(result));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(ex.Message));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<string>(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar SSRExample con ID {id}");
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ApiResponse<string>("Ocurrió un error al actualizar el registro"));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteSSRExample(id);
                return Ok("Registro eliminado");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ApiResponse<string>(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar SSRExample con ID {id}");
                return StatusCode(
                    (int)HttpStatusCode.InternalServerError,
                    new ApiResponse<string>("Ocurrió un error al eliminar el registro"));
            }
        }
    }
}