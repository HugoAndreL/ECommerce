using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.ImgPDTO
{
    /// <summary>
    ///     Modelo de Adição de Imagens
    /// </summary>
    public class CreateImgPDTO
    {
        public string? Name_Img { get; set; }
        [Required(ErrorMessage = "*O campo 'Localização da Imagem' se faz necessário!")]
        public required string Src_Img { get; set; }
        [Required]
        public required int ProdutoId { get; set; }
    }
}
