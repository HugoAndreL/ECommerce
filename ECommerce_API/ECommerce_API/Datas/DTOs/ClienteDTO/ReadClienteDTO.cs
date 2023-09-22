using ECommerce_API.Datas.DTOs.AvaliacaoDTO;
using ECommerce_API.Datas.DTOs.CompraDTO;

namespace ECommerce_API.Datas.DTOs.ClienteDTO
{
    public class ReadClienteDTO
    {
        public required int Id_Client { get; set; }
        public required string Name_Client { get; set; }
        public required string Mail_Client { get; set; }
        public required string Password_Client { get; set; }
        public virtual ICollection<ReadCompraDTO>? Compras_Client { get; set; }
        public virtual ICollection<ReadAvaliacaoDTO>? Avaliacoes_Client { get; set; }
    }
}
