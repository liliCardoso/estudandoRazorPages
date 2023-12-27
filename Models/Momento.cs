using System;
using System.ComponentModel.DataAnnotations;

namespace teste.Models
{
    public class Momento
    {
        [Key]
        public int IdMomento { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório!")]
        [StringLength(1000, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório!")]
        [DataType(DataType.Date, ErrorMessage ="O campo {0} deve ter uma data válida!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Data { get; set; }

    }
}
