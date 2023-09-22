namespace ECommerce_API.Datas.DTOs.EnderecoDTO
{
    public class ReadEnderecoDTO
    {
        public required int Id_Endereco { get; set; }
        public required string CEP_Endereco { get; set; }
        public string? Desc_Endereco { get; set; }
    }
}
