using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    /// <summary>
    ///     Modelo base para as Imagens
    /// </summary>
    public class ImgProd
    {
        [Key]
        [Required]
        public required int Id_Img { get; set; }
        public string? Name_Img { get; set; }
        [Required(ErrorMessage = "*O campo 'Localização da Imagem' se faz necessário!")]
        public required string Src_Img { get; set; }
        [Required]
        public required int ProdutoId { get; set; }
        public virtual Produto? Produto_Img { get; set; }
    }
}
