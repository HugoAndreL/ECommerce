using ECommerce_API.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.EnderecoDTO
{
    public class CreateEnderecoDTO
    {
        [Required]
        public required int EstoqueId { get; set; }
        [Required(ErrorMessage = "*O campo 'CEP do Endereço' se faz necessário!")]
        [StringLength(20, ErrorMessage = "O campo 'CEP do Endereço' só pode conter 20 caractéres.")]
        public required string CEP_Endereco { get; set; }
        [StringLength(60, ErrorMessage = "O campo 'Descrição do Endereço' só pode conter 60 caractéres.")]
        public string? Desc_Endereco { get; set; }
    }
}
