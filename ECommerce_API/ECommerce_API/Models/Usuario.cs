using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public required int Id_User { get; set; }
        [Required(ErrorMessage = "*O campo 'Nome do Usuário' se faz obrigatório!")]
        public required string Name_User { get; set; }
        [Required(ErrorMessage = "*O campo 'CPF do Usuário' se faz obrigatório!")]
        [StringLength(11, ErrorMessage = "O campo 'CPF do Usuário' deve conter 11 caractéres.")]
        public required string CPF_User { get; set; }
        [Required(ErrorMessage = "*O campo 'Email do Usuário' se faz obrigatório!")]
        public required string Email_User { get; set; }
        [Required(ErrorMessage = "*O campo 'Senha do Usuário' se faz obrigatório!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "O campo 'Senha do Usuário' permite pelo menos de 5 à 30 caractéres.")]
        public required string Password_User { get; set; }
        public virtual ICollection<Compra>? Compras_User { get; set; }
    }
}
