using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("FASES")]
    public class FaseModel
    {
        [Key]
        [Column("ID_FASE")]
        public int FaseId { get; set; }

        [Column("NOME_FASE")]
        public string? NomeFase { get; set;}

        [Column("PERGUNTA_LABEL")]
        public string? LabelPergunta { get; set; }

        [Column("MAPAS_ID_MAPA")]
        public int IdMapa { get; set; }

        public MapaModel? Mapa { get; set; }

        public IList<AlternativaModel> Alternativas { get; set; }

        public FaseModel()
        {
        }

        public FaseModel(int faseId, int idMapa)
        {
            FaseId = faseId;
            IdMapa = idMapa;
        }
    }
}
