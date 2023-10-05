using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Repository
{
    public class UsuarioMapaRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public UsuarioMapaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public List<UsuarioMapaModel> Listar()
        {
            var lista = dataBaseContext.UsuarioMapa.ToList();
            return lista;
        }

        public UsuarioMapaModel Consultar(int id)
        {
            var usuarioMapa = dataBaseContext.UsuarioMapa.Find(id);
            return usuarioMapa;
        }

        public void Inserir(UsuarioMapaModel usuarioMapa)
        {
            dataBaseContext.UsuarioMapa.Add(usuarioMapa);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(UsuarioMapaModel usuarioMapa)
        {
            dataBaseContext.UsuarioMapa.Update(usuarioMapa);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(UsuarioMapaModel usuarioMapa)
        {
            dataBaseContext.UsuarioMapa.Remove(usuarioMapa);
            dataBaseContext.SaveChanges();
        }
    }
}
