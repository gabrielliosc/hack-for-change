using PlataformaEducacional.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace PlataformaEducacional.Api.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<AlternativaModel> Alternativa { get; set; }

        public DbSet<FaseModel> Fase { get; set; }

        public DbSet<MapaModel> Mapa { get; set; }

        public DbSet<MateriaModel> Materia { get; set; }

        public DbSet<TipoAlternativaModel> TipoAlternativa { get; set; }

        public DbSet<UsuarioMapaModel> UsuarioMapa { get; set; }

        public DbSet<UsuarioModel> Usuario { get; set; }


        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {
        }

    }
}