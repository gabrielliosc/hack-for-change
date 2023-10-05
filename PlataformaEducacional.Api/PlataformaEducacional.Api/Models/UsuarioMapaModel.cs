using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("USUARIO_MAPAS")]
    public class UsuarioMapaModel
    {
        [Key]
        [Column("ID_USUARIO_MAPAS")]
        public int UsuarioMapaId { get; set; }

        [Column("STATUS_MAPA")]
        public string UsuarioMapaStatus { get; set; }

        [Column("PONTUACAO_MAPA")]
        public int? PontuacaoMapa {  get; set; }

        [Column("USUARIO_ID_USUARIO")]
        public int UsuarioId { get; set; }

        public UsuarioModel? Usuario { get; set; }

        [Column("MAPAS_ID_MAPA")]
        public int MapaId { get; set; }

        public MapaModel? Mapa { get; set; }

        public UsuarioMapaModel() { }

    }
}
