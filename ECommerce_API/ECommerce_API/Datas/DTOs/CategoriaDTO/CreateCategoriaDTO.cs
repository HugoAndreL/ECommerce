using System.ComponentModel.DataAnnotations;

namespace ECommerce_API.Datas.DTOs.CategoriaDTO
{
    public class CreateCategoriaDTO
    {
        [Required(ErrorMessage = "*O campo 'Nome da Categoria' se faz necessário!")]
        [StringLength(30, ErrorMessage = "O campo 'Nome da Categoria' só pode conter 30 caractéres.")]
        public required string Name_Cat { get; set; }
        public string? Desc_Cat { get; set; }
    }
}
