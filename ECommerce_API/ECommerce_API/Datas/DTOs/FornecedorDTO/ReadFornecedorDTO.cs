using ECommerce_API.Datas.DTOs.ProdutoDTO;

namespace ECommerce_API.Datas.DTOs.FonecedorDTO
{
    /// <summary>
    ///     Modelo de Exibição de Fornecedores
    /// </summary>
    public class ReadFornecedorDTO
    {
        public int? Id_Fornecedor { get; set; }
        // Img_Fornecedor 1-1
        public string? Nome_Fornecedor { get; set; }
        public string? Desc_Fornecedor { get; set; }
        public string? Contato_Fornecedor { get; set; }
        public string? Social_Fornecedor { get; set; }
        public virtual ICollection<ReadProdutoDTO>? Produtos_Fornecedor { get; set; }
        // Categoria_Fornecedor 1-n
        // Avaliações_Fornecedor 1-n
    }
}
