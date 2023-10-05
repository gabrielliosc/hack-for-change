using PlataformaEducacional.Api.Models;
using PlataformaEducacional.Api.Repository.Context;

namespace PlataformaEducacional.Api.Repository
{
    public class MateriaRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public MateriaRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public List<MateriaModel> Listar()
        {
            var lista = dataBaseContext.Materia.ToList();
            return lista;
        }

        public MateriaModel Consultar(int id)
        {
            var materia = dataBaseContext.Materia.Find(id);
            return materia;
        }

        public void Inserir(MateriaModel materia)
        {
            dataBaseContext.Materia.Add(materia);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(MateriaModel materia)
        {
            dataBaseContext.Materia.Update(materia);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(MateriaModel materia)
        {
            dataBaseContext.Materia.Remove(materia);
            dataBaseContext.SaveChanges();
        }
    }
}
