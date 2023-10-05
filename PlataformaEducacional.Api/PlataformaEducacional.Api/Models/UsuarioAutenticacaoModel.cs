using System.ComponentModel.DataAnnotations;

namespace PlataformaEducacional.Api.Models
{
    public class UsuarioAutenticacaoModel
    {
        [Required]
        [EmailAddress]
        public string UsuarioEmail { get; set; }

        [Required]
        public string UsuarioSenha { get; set; }
    }
}
