using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.CompraDTO
{
    public class UpdateCompraDTO
    {
        [Required(ErrorMessage = "*O campo 'Quantidade de Produto da Compra' se faz obrigatório!")]
        public required float QuantProd_Compra { get; set; }
        [Required(ErrorMessage = "*O campo 'Total da Compra' se faz obrigatório!")]
        public required float Total_Compra { get; set; }
        [Required(ErrorMessage = "*O campo 'Método de Pagamento' se faz obrigatório!")]
        public required int MetPag_Compra { get; set; }
    }
}
