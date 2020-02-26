using AutoMapper;
using Supermarket.API.Controllers.Forms;
using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(
                    src => src.UnitOfMeasurement,
                    opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString())
                );

            CreateMap<Question, QuestionView>()
                .ForMember(
                    src => src.MimeType, 
                    opt => opt.MapFrom(src => src.MimeType.ToDescriptionString())
                );
        }
    }
}
