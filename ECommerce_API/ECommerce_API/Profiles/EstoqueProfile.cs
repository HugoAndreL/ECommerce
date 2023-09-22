using AutoMapper;
using ECommerce_API.Datas.DTOs.EstoqueDTO;
using ECommerce_API.Models;

namespace PDV_API.Profiles
{
    public class EstoqueProfile : Profile
    {
        public EstoqueProfile()
        {
            // POST
            CreateMap<CreateEstoqueDTO, Estoque>();
            // GET
            CreateMap<Estoque, ReadEstoqueDTO>()
                .ForMember(stockDto => stockDto.Produtos_Estoque,
                    opt => opt.MapFrom(stock => stock.Produtos_Estoque))
                .ForMember(stockDto => stockDto.Fornecedores_Estoque,
                    opt => opt.MapFrom(stock => stock.Fornecedores_Estoque))
                .ForMember(stockDto => stockDto.Endereço_Estoque,
                    opt => opt.MapFrom(stock => stock.Endereço_Estoque));
            // PUT
            CreateMap<UpdateEstoqueDTO, Estoque>();
            // PATCH
            CreateMap<Estoque, UpdateEstoqueDTO>();
        }
    }
}
