using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("MAPAS")]
    public class MapaModel
    {
        [Key]
        [Column("ID_MAPA")]
        public int IdMapa { get; set; }

        [Column("NOME_MAPA")]
        public string NomeMapa { get; set; }

        [Column("NIVEL")]
        public int Nivel {  get; set; }

        [Column("ID_MATERIA")]
        public int IdMateria { get; set; }

        public MapaModel() { }
    }
}
