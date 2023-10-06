using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaseController : ControllerBase
    {
        private readonly FaseRepository faseRepository;

        public FaseController(DataBaseContext context)
        {
            faseRepository = new FaseRepository(context);
        }

        [HttpGet]
        public ActionResult<List<FaseModel>> Listar()
        {
            try
            {
                var fases = faseRepository.Listar();

                if (fases != null)
                {
                    return Ok(fases);
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
        public ActionResult<FaseModel> Consultar(int id)
        {
            try
            {
                var fase = faseRepository.Consultar(id);

                if (fase != null)
                {
                    return Ok(fase);
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
        public ActionResult<FaseModel> Inserir([FromBody] FaseModel fase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                faseRepository.Inserir(fase);
                var location = new Uri(Request.GetEncodedUrl() + "/" + fase.IdFase);
                return Created(location, fase);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a fase. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<FaseModel> Excluir(int id)
        {
            try
            {
                var fase = faseRepository.Consultar(id);

                if (fase != null)
                {
                    faseRepository.Excluir(fase);
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
        public ActionResult<FaseModel> Alterar(int id, [FromBody] FaseModel fase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (fase.IdFase != id)
            {
                return NotFound();
            }

            try
            {
                faseRepository.Alterar(fase);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a fase. Detalhes: {error.Message}" });
            }
        }
    }
}
