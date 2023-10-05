using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Repository
{
    public class TipoAlternativaRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public TipoAlternativaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public List<TipoAlternativaModel> Listar()
        {
            var lista = dataBaseContext.TipoAlternativa.ToList();
            return lista;
        }

        public TipoAlternativaModel Consultar(int id)
        {
            var tipoAlternativa = dataBaseContext.TipoAlternativa.Find(id);
            return tipoAlternativa;
        }

        public void Inserir(TipoAlternativaModel tipoAlternativa)
        {
            dataBaseContext.TipoAlternativa.Add(tipoAlternativa);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(TipoAlternativaModel tipoAlternativa)
        {
            dataBaseContext.TipoAlternativa.Update(tipoAlternativa);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(TipoAlternativaModel tipoAlternativa)
        {
            dataBaseContext.TipoAlternativa.Remove(tipoAlternativa);
            dataBaseContext.SaveChanges();
        }
    }
}
