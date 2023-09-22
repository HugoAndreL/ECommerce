using ECommerce_API.Datas.DTOs.CompraDTO;
using ECommerce_API.Datas.DTOs.NN_DTO;

namespace ECommerce_API.Datas.DTOs.HistoricoDTO
{
    /// <summary>
    ///     Modelo de Exibição de Historico
    /// </summary>
    public class ReadHistoricoDTO
    {
        public required int Id_Historico { get; set; }
        public virtual ICollection<ReadCompraDTO>? Compras_Historico { get; set; }
        public virtual ICollection<ReadHistoricoProdDTO>? Produtos_Historico { get; set; }
    }
}
