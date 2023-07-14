using AutoMapper;
using ProductCRUD.Models;
using ProductCRUD.Models.ViewModels;

namespace ProductCRUD.Mappers
{
    public static class Mappers
    {
        public static MapperConfiguration ProductMapperConfig = new(mapConfig =>
        {
            mapConfig.CreateMap<ProductViewModel, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.ImageLink, opt => opt.MapFrom(src => src.ImageLink));
        });
    }
}
