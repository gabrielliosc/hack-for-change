using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapaController : ControllerBase
    {
        private readonly MapaRepository mapaRepository;

        public MapaController(DataBaseContext context)
        {
            mapaRepository = new MapaRepository(context);
        }

        [HttpGet]
        public ActionResult<List<MapaModel>> Listar()
        {
            try
            {
                var mapas = mapaRepository.Listar();

                if (mapas != null)
                {
                    return Ok(mapas);
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
        public ActionResult<MapaModel> Consultar(int id)
        {
            try
            {
                var mapa = mapaRepository.Consultar(id);

                if (mapa != null)
                {
                    return Ok(mapa);
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
        public ActionResult<MapaModel> Inserir([FromBody] MapaModel mapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                mapaRepository.Inserir(mapa);
                var location = new Uri(Request.GetEncodedUrl() + "/" + mapa.IdMapa);
                return Created(location, mapa);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o mapa. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<MapaModel> Excluir(int id)
        {
            try
            {
                var mapa = mapaRepository.Consultar(id);

                if (mapa != null)
                {
                    mapaRepository.Excluir(mapa);
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
        public ActionResult<MapaModel> Alterar(int id, [FromBody] MapaModel mapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mapa.IdMapa != id)
            {
                return NotFound();
            }

            try
            {
                mapaRepository.Alterar(mapa);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o mapa. Detalhes: {error.Message}" });
            }
        }
    }
}
