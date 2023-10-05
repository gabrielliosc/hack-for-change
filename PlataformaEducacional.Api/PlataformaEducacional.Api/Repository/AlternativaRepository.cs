using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Repository
{
    public class AlternativaRepository
    {

        private readonly DataBaseContext dataBaseContext;

        public AlternativaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public List<AlternativaModel> Listar()
        {
            var lista = new List<AlternativaModel>();
            lista = dataBaseContext.Alternativa.ToList<AlternativaModel>();
            return lista;
        }

        public AlternativaModel Consultar(int id)
        {
            var alternativa = dataBaseContext.Alternativa.Find(id);

            return alternativa;
        }

        public void Inserir(AlternativaModel alternativa)
        {
            dataBaseContext.Alternativa.Add(alternativa);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(AlternativaModel alternativa)
        {
            dataBaseContext.Alternativa.Update(alternativa);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(AlternativaModel alerta)
        {
            dataBaseContext.Alternativa.Remove(alerta);
            dataBaseContext.SaveChanges();
        }
    }
}

