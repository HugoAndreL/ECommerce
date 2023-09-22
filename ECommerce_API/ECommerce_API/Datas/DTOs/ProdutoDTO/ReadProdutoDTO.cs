using ECommerce_API.Datas.DTOs.ImgPDTO;
using System.ComponentModel.DataAnnotations;
using ECommerce_API.Datas.DTOs.NN_DTO;
using ECommerce_API.Datas.DTOs.AvaliacaoDTO;

namespace ECommerce_API.Datas.DTOs.ProdutoDTO
{
    /// <summary>
    ///     Modelo de Exibição de Produtos
    /// </summary>
    public class ReadProdutoDTO
    {
        public required int Id_Prod { get; set; }
        public virtual ICollection<ReadImgPDTO>? Imgs_Prod { get; set; }
        [Required(ErrorMessage = "*O campo 'Código de Barras' se faz obrigatório!")]
        [StringLength(12, ErrorMessage = "O campo 'Código de Barras' deve ter 12 caractéres.")]
        public required string CodeBar_Prod { get; set; }
        [Required(ErrorMessage = "*O campo 'Produto' se faz obrigatório!")]
        public required string Name_Prod { get; set; }
        [Required(ErrorMessage = "*O campo 'Valor' se faz obrigatório!")]
        [Range(0.01, 999999.99, ErrorMessage = "O campo 'Valor' deve ter pelo menos 0.01 à 999999.99.")]
        public required double Val_Prod { get; set; }
        public int EstoqueId { get; set; }
        public int FornecedorId { get; set; }
        public virtual ICollection<ReadAvaliacaoDTO>? Avalicoes_Prod { get; set; }
        public virtual ICollection<ReadHistoricoProdDTO>? Historicos_Prod { get; set; }
        public virtual ICollection<ReadProdCompDTO>? Compras_Prod { get; set; }
    }
}
