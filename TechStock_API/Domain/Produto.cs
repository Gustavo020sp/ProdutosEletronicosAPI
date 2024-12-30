using System.ComponentModel.DataAnnotations;

namespace TechStock_API.Domain
{
    public class Produto
    {
        [Key] // > Reconhecimento do EF como PK
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome do produto é obrigatório.")]
        public string? Nome {  get; set; }
        public int Quantidade { get; set; }

        [DisplayFormat(DataFormatString = "{0:F3}")]
        public decimal ValorUnitario { get; set; }
    }
}
