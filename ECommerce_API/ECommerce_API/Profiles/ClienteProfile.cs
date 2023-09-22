using AutoMapper;
using ECommerce_API.Datas.DTOs.ClienteDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            // POST
            CreateMap<CreateClienteDTO, Cliente>();
            // GET
            CreateMap<Cliente, ReadClienteDTO>()
                .ForMember(clientDto => clientDto.Compras_Client,
                    opt => opt.MapFrom(client => client.Compras_Client))
                .ForMember(clientDto => clientDto.Avaliacoes_Client,
                    opt => opt.MapFrom(client => client.Avaliacoes_Client));
            // PUT
            CreateMap<UpdateClienteDTO, Cliente>();
            // PATCH
            CreateMap<Cliente, UpdateClienteDTO>();
        }
    }
}
