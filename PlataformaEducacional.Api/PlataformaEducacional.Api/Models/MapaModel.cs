using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("MAPAS")]
    public class MapaModel
    {
        [Key]
        [Column("ID_MAPA")]
        public int MapaId { get; set; }

        [Column("NOME_MAPA")]
        public string NomeMapa { get; set; }

        [Column("NIVEL")]
        public int Nivel {  get; set; }

        [Column("MATERIAS_ID_MATERIA")]
        public int IdMateria { get; set; }

        public MateriaModel? Materia { get; set; }

        public IList<FaseModel> Fases { get; set; }

        public MapaModel() { }

        public MapaModel(int mapaId, string nomeMapa, int nivel, int idMateria)
        {
            MapaId = mapaId;
            NomeMapa = nomeMapa;
            Nivel = nivel;
            IdMateria = idMateria;
        }
    }
}
