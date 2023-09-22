using ECommerce_API.Datas.DTOs.ProdutoDTO;

namespace ECommerce_API.Datas.DTOs.CategoriaDTO
{
    public class ReadCategoriaDTO
    {
        public required int Id_Cat { get; set; }
        public required string Name_Cat { get; set; }
        public string? Desc_Cat { get; set; }
        public virtual ICollection<ReadProdutoDTO>? Produtos_Cat { get; set; }
    }
}
