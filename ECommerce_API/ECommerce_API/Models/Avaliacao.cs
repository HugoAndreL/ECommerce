using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    /// <summary>
    ///     Modelo base para as Avaliações
    /// </summary>
    public class Avaliacao
    {
        [Key]
        [Required]
        public required int Id_Rate { get; set; }
        // ImgRate 1-n
        public string? Title_Rate { get; set; }
        [Required(ErrorMessage = "*O campo 'Avaliação' se faz necessário!")]
        [Range(0, 5, ErrorMessage = "O campo 'Avaliação' permite pelo menos 0 à 5.")]
        public required int Star_Rate { get; set; }
        public string? Comment_Rate { get; set; }
        [Required]
        public required int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        [Required]
        public required int ProdutoId { get; set; }
        public virtual Produto? Produto { get; set; }

    }
}
