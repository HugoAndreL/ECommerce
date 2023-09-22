using AutoMapper;
using ECommerce_API.Datas.DTOs.ProdutoDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            // POST
            CreateMap<CreateProdutoDTO, Produto>();
            // GET
            CreateMap<Produto, ReadProdutoDTO>()
                .ForMember(prodDto => prodDto.Imgs_Prod,
                    opt => opt.MapFrom(prod => prod.Imgs_Prod))
                .ForMember(prodDto => prodDto.Historicos_Prod,
                    opt => opt.MapFrom(prod => prod.Historicos_Prod))
                .ForMember(prodDto => prodDto.Compras_Prod,
                    opt => opt.MapFrom(prod => prod.Compras_Prod))
                .ForMember(prodDto => prodDto.Avalicoes_Prod,
                    opt => opt.MapFrom(prod => prod.Avalicoes_Prod));
            // PUT
            CreateMap<UpdateProdutoDTO, Produto>();
            // PATCH
            CreateMap<Produto, UpdateProdutoDTO>();
        }
    }
}
