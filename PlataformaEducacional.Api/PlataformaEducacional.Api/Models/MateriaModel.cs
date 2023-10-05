using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("MATERIAS")]
    public class MateriaModel
    {
        [Key]
        [Column("ID_MATERIA")]
        public int MateriaId { get; set; }

        [Column("NOME_MATERIA")]
        public string NomeMateria { get; set; }

        [Column("DESC_MATERIA")]
        public string DescricaoMateria { get; set; }

        public MateriaModel() { }

        public MateriaModel(int idMateria, string nomeMateria, string descricaoMateria)
        {
            MateriaId = idMateria;
            NomeMateria = nomeMateria;
            DescricaoMateria = descricaoMateria;
        }
    }
}
