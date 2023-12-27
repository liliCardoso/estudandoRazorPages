using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
    public class Foto
    {
        [Key]
        public int IdFoto { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório!")]
        [DisplayName("Foto")]
        public string UrlFoto { get; set;}

        [NotMapped]
        public IFormFile FotoImagem { get; set; }
    }
}
