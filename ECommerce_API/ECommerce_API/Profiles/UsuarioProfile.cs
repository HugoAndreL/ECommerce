using AutoMapper;
using ECommerce_API.Datas.DTOs.UsuarioDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            // POST
            CreateMap<CreateUsuarioDTO, Usuario>();
            // GET
            CreateMap<Usuario, ReadUsuarioDTO>()
                .ForMember(userDto => userDto.Compras_User,
                    opt => opt.MapFrom(user => user.Compras_User));
            // PUT
            CreateMap<UpdateUsuarioDTO, Usuario>();
            // PATCH
            CreateMap<Usuario, UpdateUsuarioDTO>();
        }
    }
}
