using AutoMapper;
using ECommerce_API.Datas.DTOs.NN_DTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class HistoricoProdProfile : Profile
    {
        public HistoricoProdProfile()
        {
            // POST
            CreateMap<CreateHistoricoProdDTO, HistoricoProd>();
            // GET
            CreateMap<HistoricoProd, ReadHistoricoProdDTO>();
        }
    }

    public class ProdCompProfile : Profile
    {
        public ProdCompProfile()
        {
            // POST
            CreateMap<CreateProdCompDTO, ProdComp>();
            // GET
            CreateMap<ProdComp, ReadProdCompDTO>();
        }
    }
}
