namespace ECommerce_API.Models
{
    /// <summary>
    ///     Modelo base para a entidade N:N de Histórico e Produtos
    /// </summary>
    public class HistoricoProd
    {
        public int? HistoricoId { get; set; }
        public virtual Historico? Historico { get; set; }
        public int? ProdutoId { get; set; }
        public virtual Produto? Produto { get; set; }
    }

    /// <summary>
    ///     Modelo base para a entidade N:N de Produto e Compra
    /// </summary>
    public class ProdComp
    {
        public int? ProdutoId { get; set; }
        public virtual Produto? Produto { get; set; }
        public int? CompraId { get; set; }
        public virtual Compra? Compra { get;}
    }
}
