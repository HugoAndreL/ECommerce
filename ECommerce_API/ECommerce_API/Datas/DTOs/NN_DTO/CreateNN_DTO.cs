namespace ECommerce_API.Datas.DTOs.NN_DTO
{
    /// <summary>
    ///     Modelo de Criação da Relação N:N Historicos e Produtos
    /// </summary>
    public class CreateHistoricoProdDTO
    {
        public int? HistoricoId { get; set; }
        public int? ProdutoId { get; set; }
    }

    /// <summary>
    ///     Modelo de Criação da Relação N:N Produtos e Compras
    /// </summary>
    public class CreateProdCompDTO
    {
        public int? ProdutoId { get; set; }
        public int? CompraId { get; set; }
    }
}
