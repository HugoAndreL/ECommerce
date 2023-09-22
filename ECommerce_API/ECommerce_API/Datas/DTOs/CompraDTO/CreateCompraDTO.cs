using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.CompraDTO
{
    /// <summary>
    ///     Modelo de
    /// </summary>
    public class CreateCompraDTO
    {
        [Required]
        public required int ClienteId { get; set; }
        [Required]
        public required int HistoricoId { get; set; }
        [Required]
        public required int UsuarioId { get; set; }
        [Required(ErrorMessage = "*O campo 'Quantidade de Produto da Compra' se faz obrigatório!")]
        public required float QuantProd_Compra { get; set; }
        [Required(ErrorMessage = "*O campo 'Total da Compra' se faz obrigatório!")]
        public required float Total_Compra { get; set; }
        [Required(ErrorMessage = "*O campo 'Método de Pagamento' se faz obrigatório!")]
        public required int MetPag_Compra { get; set; }
    }
}
