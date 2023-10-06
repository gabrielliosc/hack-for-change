using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("FASES")]
    public class FaseModel
    {
        [Key]
        [Column("ID_FASE")]
        public int IdFase { get; set; }

        [Column("NOME_FASE")]
        public string? NomeFase { get; set;}

        [Column("PERGUNTA_LABEL")]
        public string? LabelPergunta { get; set; }

        [Column("ID_MAPA")]
        public int IdMapa { get; set; }

        public FaseModel()
        {
        }
    }
}
