using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Models
{
    public class Compra
    {
        [Key]
        [Required]
        public int Id_Compra { get; set; }
        [Required]
        public required int ClienteId { get; set; }
        public virtual Cliente? Cliente_Compra { get; set; }
        [Required]
        public required int HistoricoId { get; set; }
        public virtual Historico? Historico_Compra { get; set; }
        [Required]
        public required int UsuarioId { get; set; }
        public virtual Usuario? Usuario_Compra { get; set; }
        public virtual ICollection<ProdComp>? Produtos_Compra { get; set; }
        [Required(ErrorMessage = "*O campo 'Quantidade de Produto da Compra' se faz obrigatório!")]
        public required float QuantProd_Compra { get; set; }
        [Required(ErrorMessage = "*O campo 'Total da Compra' se faz obrigatório!")]
        public required float Total_Compra { get; set; }
        [Required(ErrorMessage = "*O campo 'Método de Pagamento' se faz obrigatório!")]
        public required int MetPag_Compra { get; set; }
        [Required(ErrorMessage = "*O campo 'Data da Compra' se faz obrigatório!")]
        public required DateTime Data_Compra { get; set; } = DateTime.Now;
    }
}
