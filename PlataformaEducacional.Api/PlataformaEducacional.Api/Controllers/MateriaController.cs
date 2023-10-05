using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly MateriaRepository materiaRepository;

        public MateriaController(DataBaseContext context)
        {
            materiaRepository = new MateriaRepository(context);
        }

        [HttpGet]
        public ActionResult<List<MateriaModel>> Listar()
        {
            try
            {
                var materias = materiaRepository.Listar();

                if (materias != null)
                {
                    return Ok(materias);
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
        public ActionResult<MateriaModel> Consultar(int id)
        {
            try
            {
                var materia = materiaRepository.Consultar(id);

                if (materia != null)
                {
                    return Ok(materia);
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
        public ActionResult<MateriaModel> Inserir([FromBody] MateriaModel materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                materiaRepository.Inserir(materia);
                var location = new Uri(Request.GetEncodedUrl() + "/" + materia.MateriaId);
                return Created(location, materia);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir a matéria. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<MateriaModel> Excluir(int id)
        {
            try
            {
                var materia = materiaRepository.Consultar(id);

                if (materia != null)
                {
                    materiaRepository.Excluir(materia);
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
        public ActionResult<MateriaModel> Alterar(int id, [FromBody] MateriaModel materia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (materia.MateriaId != id)
            {
                return NotFound();
            }

            try
            {
                materiaRepository.Alterar(materia);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar a matéria. Detalhes: {error.Message}" });
            }
        }
    }
}
