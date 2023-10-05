using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("TIPO_ALTERNATIVAS")]
    public class TipoAlternativaModel
    {
        [Key]
        [Column("ID_TIPO")]
        public int TipoId {  get; set; }

        [Column("TIPO")]
        public string TipoName { get; set;}

        public TipoAlternativaModel() { }

        public TipoAlternativaModel(int tipoId, string tipoName)
        {
            TipoId = tipoId;
            TipoName = tipoName;
        }
    }
}
