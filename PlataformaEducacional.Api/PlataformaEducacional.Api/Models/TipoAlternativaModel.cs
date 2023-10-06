using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("TIPO_ALTERNATIVAS")]
    public class TipoAlternativaModel
    {
        [Key]
        [Column("ID_TIPO")]
        public int IdTipo {  get; set; }

        [Column("TIPO")]
        public string TipoName { get; set;}

        public TipoAlternativaModel() { }

    }
}
