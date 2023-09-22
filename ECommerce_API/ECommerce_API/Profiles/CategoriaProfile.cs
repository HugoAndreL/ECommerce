using AutoMapper;
using ECommerce_API.Datas.DTOs.CategoriaDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            // POST
            CreateMap<CreateCategoriaDTO, Categoria>();
            // GET
            CreateMap<Categoria, ReadCategoriaDTO>()
                .ForMember(catDto => catDto.Produtos_Cat,
                    opt => opt.MapFrom(cat =>  cat.Produtos_Cat));
            // PUT
            CreateMap<UpdateCategoriaDTO, Categoria>();
            // PATCH
            CreateMap<Categoria, UpdateCategoriaDTO>();
        }
    }
}
