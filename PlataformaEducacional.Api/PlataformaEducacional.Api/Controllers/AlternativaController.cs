using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlternativaController : ControllerBase
    {
        private readonly AlternativaRepository alternativaRepository;

        public AlternativaController(DataBaseContext context)
        {
            alternativaRepository = new AlternativaRepository(context);
        }

        [HttpGet]
        public ActionResult<List<AlternativaModel>> Listar()
        {
            try
            {
                var lista = alternativaRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
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
        public ActionResult<AlternativaModel> Consultar(int id)
        {
            try
            {
                var alternativaModel = alternativaRepository.Consultar(id);

                if (alternativaModel != null)
                {
                    return Ok(alternativaModel);
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
        public ActionResult<AlternativaModel> Inserir([FromBody] AlternativaModel alternativaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                alternativaRepository.Inserir(alternativaModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + alternativaModel.IdAlternativa);
                return Created(location, alternativaModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a alternativa. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<AlternativaModel> Excluir(int id)
        {
            try
            {
                var alternativaModel = alternativaRepository.Consultar(id);

                if (alternativaModel != null)
                {
                    alternativaRepository.Excluir(alternativaModel);
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
        public ActionResult<AlternativaModel> Alterar([FromRoute] int id, [FromBody] AlternativaModel alternativaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (alternativaModel.IdAlternativa != id)
            {
                return NotFound();
            }

            try
            {
                alternativaRepository.Alterar(alternativaModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a alternativa. Detalhes: {error.Message}" });
            }
        }
    }
}
