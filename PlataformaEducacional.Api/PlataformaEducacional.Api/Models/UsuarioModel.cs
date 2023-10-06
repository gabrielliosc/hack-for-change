using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaEducacional.Api.Models
{
    [Table("USUARIOS")]
    public class UsuarioModel
    {
        [Key]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("NOME_USUARIO")]
        public string NomeUsuario { get; set; }

        [Column("DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Column("SENHA")]
        public string UsuarioSenha { get; set; }

        [Required]
        [EmailAddress]
        [Column("EMAIL")]
        public string UsuarioEmail { get; set; }

        [Column("PONTUACAO_USUARIO")]
        public double UsuarioPontuacao { get; set;}

        [Column("PASSOS")]
        public char IsPassos {  get; set; }

        [Column("DT_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Column("COINS")]
        public int? Coins { get; set; }

        [Column("IMG_PERFIL")]
        public byte[]? ImagemPerfil { get; set; }

        public UsuarioModel() { }


    }
}
