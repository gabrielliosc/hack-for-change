using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioMapaController : ControllerBase
    {
        private readonly UsuarioMapaRepository usuarioMapaRepository;

        public UsuarioMapaController(DataBaseContext context)
        {
            usuarioMapaRepository = new UsuarioMapaRepository(context);
        }

        [HttpGet]
        public ActionResult<List<UsuarioMapaModel>> Listar()
        {
            try
            {
                var usuarioMapas = usuarioMapaRepository.Listar();

                if (usuarioMapas != null)
                {
                    return Ok(usuarioMapas);
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
        public ActionResult<UsuarioMapaModel> Consultar(int id)
        {
            try
            {
                var usuarioMapa = usuarioMapaRepository.Consultar(id);

                if (usuarioMapa != null)
                {
                    return Ok(usuarioMapa);
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
        public ActionResult<UsuarioMapaModel> Inserir([FromBody] UsuarioMapaModel usuarioMapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                usuarioMapaRepository.Inserir(usuarioMapa);
                var location = new Uri(Request.GetEncodedUrl() + "/" + usuarioMapa.UsuarioMapaId);
                return Created(location, usuarioMapa);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o usuário no mapa. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UsuarioMapaModel> Excluir(int id)
        {
            try
            {
                var usuarioMapa = usuarioMapaRepository.Consultar(id);

                if (usuarioMapa != null)
                {
                    usuarioMapaRepository.Excluir(usuarioMapa);
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
        public ActionResult<UsuarioMapaModel> Alterar(int id, [FromBody] UsuarioMapaModel usuarioMapa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (usuarioMapa.UsuarioMapaId != id)
            {
                return NotFound();
            }

            try
            {
                usuarioMapaRepository.Alterar(usuarioMapa);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o usuário no mapa. Detalhes: {error.Message}" });
            }
        }
    }
}
