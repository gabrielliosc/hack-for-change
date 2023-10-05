using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("ALTERNATIVAS")]
    public class AlternativaModel
    {

        [Key]
        [Column("ID_ALTERNATIVA")]
        public int AlternativaId { get; set; }

        [Column("ALTERNATIVA_TEXTO")]
        public string? AlternativaTexto { get; set; }

        [Column("ALTERNATIVA_IMG")]
        public string? AlternativaImagem { get; set; }

        [Column("FASES_ID_FASE")]
        public int IdFase { get; set; }

        public FaseModel? Fase { get; set; }

        [Column("TIPO_ALTERNATIVAS_ID_TIPO")]
        public int TipoAlternativa { get; set; }

        public TipoAlternativaModel? Tipo { get; set; }

        public AlternativaModel()
        {
        }

        public AlternativaModel(int alternativaId, int idFase, int tipoAlternativa)
        {
            AlternativaId = alternativaId;
            IdFase = idFase;
            TipoAlternativa = tipoAlternativa;
        }
    }
}
