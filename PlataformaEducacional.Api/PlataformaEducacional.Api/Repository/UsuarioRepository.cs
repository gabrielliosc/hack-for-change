using Microsoft.EntityFrameworkCore;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Repository
{
    public class UsuarioRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public UsuarioRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public List<UsuarioModel> Listar()
        {
            var lista = dataBaseContext.Usuario
                .Include(u => u.MapasUsuario)
                        .ToList<UsuarioModel>();
            return lista;
        }

        public UsuarioModel Consultar(int id)
        {
            var usuario = dataBaseContext.Usuario
                .Include(u => u.MapasUsuario)
                        .Where(u => u.UsuarioId == id)
                            .FirstOrDefault();
            return usuario;
        }

        public void Inserir(UsuarioModel usuario)
        {
            dataBaseContext.Usuario.Add(usuario);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(UsuarioModel usuario)
        {
            dataBaseContext.Usuario.Update(usuario);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(UsuarioModel usuario)
        {
            dataBaseContext.Usuario.Remove(usuario);
            dataBaseContext.SaveChanges();
        }

        public UsuarioModel AutenticarUsuario(string email, string senha)
        {
            var usuario = dataBaseContext.Usuario
                .FirstOrDefault(u => u.UsuarioEmail == email && u.UsuarioSenha == senha);

            return usuario;
        }
    }
}
