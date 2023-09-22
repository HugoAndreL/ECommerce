using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.AvaliacaoDTO
{
    /// <summary>
    ///     Modelo de Adição de Avaliações
    /// </summary>
    public class CreateAvaliacaoDTO
    {
        // ImgRate 1-n
        public string? Title_Rate { get; set; }
        [Required(ErrorMessage = "*O campo 'Avaliação' se faz necessário!")]
        [Range(0, 5, ErrorMessage = "O campo 'Avaliação' deve ter pelo menos 0 à 5.")]
        public required int Star_Rate { get; set; }
        public string? Comment_Rate { get; set; }
        [Required]
        public required int ClienteId { get; set; }
        [Required]
        public required int ProdutoId { get; set; }
    }
}
