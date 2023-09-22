using ECommerce_API.Datas.DTOs.CompraDTO;

namespace ECommerce_API.Datas.DTOs.UsuarioDTO
{
    public class ReadUsuarioDTO
    {
        public required int Id_User { get; set; }
        public required string Name_User { get; set; }
        public required string CPF_User { get; set; }
        public required string Email_User { get; set; }
        public required string Password_User { get; set; }
        public virtual ICollection<ReadCompraDTO>? Compras_User { get; set; }
    }
}
