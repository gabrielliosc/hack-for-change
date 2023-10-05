using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioController(DataBaseContext context)
        {
            usuarioRepository = new UsuarioRepository(context);
        }

        [HttpGet]
        public ActionResult<List<UsuarioModel>> Listar()
        {
            try
            {
                var usuarios = usuarioRepository.Listar();

                if (usuarios != null)
                {
                    return Ok(usuarios);
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
        public ActionResult<UsuarioModel> Consultar(int id)
        {
            try
            {
                var usuario = usuarioRepository.Consultar(id);

                if (usuario != null)
                {
                    return Ok(usuario);
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
        public ActionResult<UsuarioModel> Inserir([FromBody] UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                usuarioRepository.Inserir(usuario);
                var location = new Uri(Request.GetEncodedUrl() + "/" + usuario.UsuarioId);
                return Created(location, usuario);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o usuário. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UsuarioModel> Excluir(int id)
        {
            try
            {
                var usuario = usuarioRepository.Consultar(id);

                if (usuario != null)
                {
                    usuarioRepository.Excluir(usuario);
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
        public ActionResult<UsuarioModel> Alterar(int id, [FromBody] UsuarioModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (usuario.UsuarioId != id)
            {
                return NotFound();
            }

            try
            {
                usuarioRepository.Alterar(usuario);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível alterar o usuário. Detalhes: {error.Message}" });
            }
        }

        [HttpPost("autenticar")]
        public ActionResult<UsuarioModel> AutenticarUsuario([FromBody] UsuarioAutenticacaoModel usuarioAutenticacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioAutenticado = usuarioRepository.AutenticarUsuario(usuarioAutenticacao.UsuarioEmail, usuarioAutenticacao.UsuarioSenha);

            if (usuarioAutenticado == null)
            {
                return Unauthorized("Falha na autenticação");
            }

            return Ok(usuarioAutenticado);
        }

    }
}
