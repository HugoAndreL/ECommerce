using AutoMapper;
using ECommerce_API.Datas.DTOs.FonecedorDTO;
using ECommerce_API.Models;

namespace PDV_API.Profiles
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            // POST
            CreateMap<CreateFornecedorDTO, Fornecedor>();
            // GET
            CreateMap<Fornecedor, ReadFornecedorDTO>()
                .ForMember(fornDto => fornDto.Produtos_Fornecedor,
                    opt => opt.MapFrom(forn => forn.Produtos_Fornecedor));
            // PUT
            CreateMap<UpdateFornecedorDTO, Fornecedor>();
            // PATCH
            CreateMap<Fornecedor, UpdateFornecedorDTO>();
        }
    }
}
