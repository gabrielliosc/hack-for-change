using Microsoft.EntityFrameworkCore;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Repository
{
    public class MapaRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public MapaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public List<MapaModel> Listar()
        {
            var lista = dataBaseContext.Mapa
                .Include(mapa => mapa.Fases)
                        .ToList<MapaModel>();
            return lista;
        }

        public MapaModel Consultar(int id)
        {
            var mapa = dataBaseContext.Mapa
                .Include(mapa => mapa.Fases)
                        .Where(mapa => mapa.MapaId == id)
                            .FirstOrDefault();
            return mapa;
        }

        public void Inserir(MapaModel mapa)
        {
            dataBaseContext.Mapa.Add(mapa);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(MapaModel mapa)
        {
            dataBaseContext.Mapa.Update(mapa);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(MapaModel mapa)
        {
            dataBaseContext.Mapa.Remove(mapa);
            dataBaseContext.SaveChanges();
        }
    }
}
