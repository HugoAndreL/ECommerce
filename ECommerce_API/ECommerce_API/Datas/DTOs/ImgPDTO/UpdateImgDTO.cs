using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.ImgPDTO
{
    /// <summary>
    ///     Schema de Atualização de Imagem
    /// </summary>
    public class UpdateImgPDTO
    {
        public string? Name_Img { get; set; }
        [Required(ErrorMessage = "*O campo 'Localização da Imagem' se faz necessário!")]
        public required string Src_Img { get; set; }
    }
}
