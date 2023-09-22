using AutoMapper;
using ECommerce_API.Datas.DTOs.AvaliacaoDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            // POST
            CreateMap<CreateAvaliacaoDTO, Avaliacao>();
            // GET
            CreateMap<Avaliacao, ReadAvaliacaoDTO>();
        }
    }
}
