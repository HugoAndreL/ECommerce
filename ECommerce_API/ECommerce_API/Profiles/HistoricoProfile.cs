using AutoMapper;
using ECommerce_API.Datas.DTOs.HistoricoDTO;
using ECommerce_API.Models;

namespace PDV_API.Profiles
{
    public class HistoricoProfile : Profile
    {
        public HistoricoProfile() 
        {
            // POST
            CreateMap<CreateHistoricoDTO, Historico>();
            // GET
            CreateMap<Historico, ReadHistoricoDTO>()
                .ForMember(hisDto => hisDto.Produtos_Historico,
                    opt => opt.MapFrom(his => his.Produtos_Historico))
                .ForMember(hisDto => hisDto.Compras_Historico,
                    opt => opt.MapFrom(his => his.Compras_Historico));
        }
    }
}
