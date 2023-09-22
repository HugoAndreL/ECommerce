using AutoMapper;
using ECommerce_API.Datas.DTOs.EnderecoDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile() 
        {
            // POST
            CreateMap<CreateEnderecoDTO, Endereco>();
            // GET
            CreateMap<Endereco, ReadEnderecoDTO>();
        }
    }
}
