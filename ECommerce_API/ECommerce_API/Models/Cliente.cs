using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public required int Id_Client { get; set; }
        [Required(ErrorMessage = "*O campo 'Nome do Cliente' se faz obrigatório!")]
        public required string Name_Client { get; set; }
        [Required(ErrorMessage = "*O campo 'Email do Cliente' se faz obrigatório!")]
        public required string Mail_Client { get; set; }
        [Required(ErrorMessage = "*O campo 'Senha do Cliente' se faz obrigatório!")]
        public required string Password_Client { get; set; }
        public virtual ICollection<Compra>? Compras_Client { get; set; }
        public virtual ICollection<Avaliacao>? Avaliacoes_Client { get; set; }
    }
}
