using Microsoft.EntityFrameworkCore;
using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Repository
{
    public class FaseRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public FaseRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public List<FaseModel> Listar()
        {
            var lista = dataBaseContext.Fase
                .Include(fase => fase.Alternativas) 
                    .ToList<FaseModel>();
            return lista;
        }

        public FaseModel Consultar(int id)
        {
            var fase = dataBaseContext.Fase
                .Include(fase => fase.Alternativas)
                        .Where(fase => fase.FaseId == id)
                            .FirstOrDefault();
            return fase;
        }

        public void Inserir(FaseModel fase)
        {
            dataBaseContext.Fase.Add(fase);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(FaseModel fase)
        {
            dataBaseContext.Fase.Update(fase);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(FaseModel fase)
        {
            dataBaseContext.Fase.Remove(fase);
            dataBaseContext.SaveChanges();
        }
    }
}
