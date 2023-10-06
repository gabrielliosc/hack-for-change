using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("USUARIO_MAPAS")]
    public class UsuarioMapaModel
    {
        [Key]
        [Column("ID_USUARIO_MAPAS")]
        public int IdUsuarioMapa { get; set; }

        [Column("STATUS_MAPA")]
        public string UsuarioMapaStatus { get; set; }

        [Column("PONTUACAO_MAPA")]
        public int? PontuacaoMapa {  get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("ID_MAPA")]
        public int IdMapa { get; set; }

        public UsuarioMapaModel() { }

    }
}
