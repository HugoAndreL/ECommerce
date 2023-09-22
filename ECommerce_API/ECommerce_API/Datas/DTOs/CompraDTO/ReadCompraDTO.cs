using ECommerce_API.Datas.DTOs.NN_DTO;

namespace ECommerce_API.Datas.DTOs.CompraDTO
{
    public class ReadCompraDTO
    {
        public int Id_Compra { get; set; }
        public required float QuantProd_Compra { get; set; }
        public required float Total_Compra { get; set; }
        public required int MetPag_Compra { get; set; }
        public required DateTime Data_Compra { get; set; } = DateTime.Now;
        public virtual ICollection<ReadProdCompDTO>? Produtos_Compra { get; set; }
    }
}
