using AutoMapper;
using ECommerce_API.Datas.DTOs.CompraDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class CompraProfile : Profile
    {
        public CompraProfile()
        {
            // POST
            CreateMap<CreateCompraDTO, Compra>();
            // GET
            CreateMap<Compra, ReadCompraDTO>()
                .ForMember(buyDto => buyDto.Produtos_Compra,
                    opt => opt.MapFrom(buy => buy.Produtos_Compra)); ;
            // PUT
            CreateMap<UpdateCompraDTO, Compra>();
            // PATCH
            CreateMap<Compra, UpdateCompraDTO>();
        }
    }
}
