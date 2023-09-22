using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    /// <summary>
    ///     Modelo base para os Históricos
    /// </summary>
    public class Historico
    {
        [Key]
        [Required]
        public required int Id_Historico { get; set; }
        public virtual ICollection<Compra>? Compras_Historico { get; set; }
        public virtual ICollection<HistoricoProd>? Produtos_Historico { get; set; }
    }
}
