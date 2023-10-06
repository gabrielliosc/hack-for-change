using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("MATERIAS")]
    public class MateriaModel
    {
        [Key]
        [Column("ID_MATERIA")]
        public int IdMateria { get; set; }

        [Column("NOME_MATERIA")]
        public string NomeMateria { get; set; }

        [Column("DESC_MATERIA")]
        public string DescricaoMateria { get; set; }

        public MateriaModel() { }
    }
}
