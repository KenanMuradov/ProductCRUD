using AutoMapper;
using ProductCRUD.Models;
using ProductCRUD.Models.ViewModels;

namespace ProductCRUD.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductViewModel, Product>()
                .ForMember(viewModel => viewModel.Name, opt => opt.MapFrom(viewModel => viewModel.Name))
                .ForMember(viewModel => viewModel.Description, opt => opt.MapFrom(viewModel => viewModel.Description))
                .ForMember(viewModel => viewModel.Category, opt => opt.MapFrom(viewModel => viewModel.Category))
                .ForMember(viewModel => viewModel.Price, opt => opt.MapFrom(viewModel => viewModel.Price))
                .ForMember(viewModel => viewModel.Count, opt => opt.MapFrom(viewModel => viewModel.Count))
                .ForMember(viewModel => viewModel.ImageLink, opt => opt.MapFrom(viewModel => viewModel.ImageLink))
                .ReverseMap();
        }
    }
}
