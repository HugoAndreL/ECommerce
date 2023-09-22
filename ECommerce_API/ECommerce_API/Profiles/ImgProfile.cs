using AutoMapper;
using ECommerce_API.Datas.DTOs.ImgPDTO;
using ECommerce_API.Models;

namespace ECommerce_API.Profiles
{
    public class ImgProfile : Profile
    {
        public ImgProfile() 
        {
            // POST
            CreateMap<CreateImgPDTO, ImgProd>();
            // GET
            CreateMap<ImgProd, ReadImgPDTO>();
            // PUT
            CreateMap<UpdateImgPDTO, ImgProd>();
            // PATCH
            CreateMap<ImgProd, UpdateImgPDTO>();
        }
    }
}
