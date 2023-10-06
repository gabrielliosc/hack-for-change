using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("ALTERNATIVAS")]
    public class AlternativaModel
    {

        [Key]
        [Column("ID_ALTERNATIVA")]
        public int IdAlternativa { get; set; }

        [Column("ALTERNATIVA_TEXTO")]
        public string? AlternativaTexto { get; set; }

        [Column("ALTERNATIVA_IMG")]
        public string? AlternativaImagem { get; set; }

        [Column("ID_FASE")]
        public int IdFase { get; set; }

        [Column("ID_TIPO")]
        public int IdTipo { get; set; }

        public AlternativaModel()
        {
        }
    }
}
