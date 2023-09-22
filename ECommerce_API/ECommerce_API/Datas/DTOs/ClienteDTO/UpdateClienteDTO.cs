using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.ClienteDTO
{
    public class UpdateClienteDTO
    {
        [Required(ErrorMessage = "*O campo 'Nome do Cliente' se faz obrigatório!")]
        public required string Name_Client { get; set; }
        [Required(ErrorMessage = "*O campo 'Email do Cliente' se faz obrigatório!")]
        public required string Mail_Client { get; set; }
        [Required(ErrorMessage = "*O campo 'Senha do Cliente' se faz obrigatório!")]
        public required string Password_Client { get; set; }
    }
}
