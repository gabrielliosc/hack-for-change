using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlternativaController : ControllerBase
    {
        private readonly TipoAlternativaRepository tipoAlternativaRepository;

        public TipoAlternativaController(DataBaseContext context)
        {
            tipoAlternativaRepository = new TipoAlternativaRepository(context);
        }

        [HttpGet]
        public ActionResult<List<TipoAlternativaModel>> Listar()
        {
            try
            {
                var tiposAlternativa = tipoAlternativaRepository.Listar();

                if (tiposAlternativa != null)
                {
                    return Ok(tiposAlternativa);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<TipoAlternativaModel> Consultar(int id)
        {
            try
            {
                var tipoAlternativa = tipoAlternativaRepository.Consultar(id);

                if (tipoAlternativa != null)
                {
                    return Ok(tipoAlternativa);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<TipoAlternativaModel> Inserir([FromBody] TipoAlternativaModel tipoAlternativa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                tipoAlternativaRepository.Inserir(tipoAlternativa);
                var location = new Uri(Request.GetEncodedUrl() + "/" + tipoAlternativa.TipoId);
                return Created(location, tipoAlternativa);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o tipo de alternativa. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<TipoAlternativaModel> Excluir(int id)
        {
            try
            {
                var tipoAlternativa = tipoAlternativaRepository.Consultar(id);

                if (tipoAlternativa != null)
                {
                    tipoAlternativaRepository.Excluir(tipoAlternativa);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<TipoAlternativaModel> Alterar(int id, [FromBody] TipoAlternativaModel tipoAlternativa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tipoAlternativa.TipoId != id)
            {
                return NotFound();
            }

            try
            {
                tipoAlternativaRepository.Alterar(tipoAlternativa);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o tipo de alternativa. Detalhes: {error.Message}" });
            }
        }
    }
}
