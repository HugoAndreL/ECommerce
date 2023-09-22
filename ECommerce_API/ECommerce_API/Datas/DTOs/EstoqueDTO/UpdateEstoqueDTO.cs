using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.EstoqueDTO
{
    /// <summary>
    ///     Modelo para Atualição de Estoque
    /// </summary>
    public class UpdateEstoqueDTO
    {
        [Required(ErrorMessage = "*O campo 'Quantidade do Estoque' se faz necessário!")]
        public required int Quant_Estoque { get; set; }
        // Endereço_Estoque 1-1
        // Fonecedores_Estoque n-1
    }
}
