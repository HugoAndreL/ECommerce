using ECommerce_API.Datas.DTOs.EnderecoDTO;
using ECommerce_API.Datas.DTOs.FonecedorDTO;
using ECommerce_API.Datas.DTOs.ProdutoDTO;

namespace ECommerce_API.Datas.DTOs.EstoqueDTO
{
    /// <summary>
    ///     Modelo para Exibição de Estoque
    /// </summary>
    public class ReadEstoqueDTO
    {
        public required int Id_Estoque { get; set; }
        public virtual ICollection<ReadProdutoDTO>? Produtos_Estoque { get; set; }
        public required int Quant_Estoque { get; set; }
        public virtual ReadEnderecoDTO? Endereço_Estoque { get; set; }
        public virtual ICollection<ReadFornecedorDTO>? Fornecedores_Estoque { get; set; }
    }
}
