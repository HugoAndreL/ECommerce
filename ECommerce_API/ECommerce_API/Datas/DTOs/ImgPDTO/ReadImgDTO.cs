using ECommerce_API.Datas.DTOs.ProdutoDTO;

namespace ECommerce_API.Datas.DTOs.ImgPDTO
{
    /// <summary>
    ///     Modelo de Exibição das Imagens
    /// </summary>
    public class ReadImgPDTO
    {
        public required int Id_Img { get; set; }
        public string? Name_Img { get; set; }
        public required string Src_Img { get; set; }
    }
}
