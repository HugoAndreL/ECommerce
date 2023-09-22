namespace ECommerce_API.Datas.DTOs.NN_DTO
{
    /// <summary>
    ///     Modelo para Exibição da Relação N:N Historicos e Produtos
    /// </summary>
    public class ReadHistoricoProdDTO
    {
        public int? HistoricoId { get; set; }
        public int? ProdutoId { get; set; }
    }
    /// <summary>
    ///     Modelo para Exibição da Relação N:N Produtos e Compras
    /// </summary>
    public class ReadProdCompDTO
    {
        public int? ProdutoId { get; set; }
        public int? CompraId { get; set; }
    }
}
