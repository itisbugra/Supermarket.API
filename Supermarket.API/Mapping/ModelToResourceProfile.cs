using AutoMapper;
using Supermarket.API.Attributes;
using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using Supermarket.API.Extensions;

namespace Supermarket.API.Mapping
{
    [Injected]
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserView>();

            CreateMap<Context, ContextView>();

            CreateMap<Category, CategoryView>();

            CreateMap<Question, QuestionView>()
                .ForMember(
                    src => src.MimeType, 
                    opt => opt.MapFrom(src => src.MimeType.ToDescriptionString())
                );

            CreateMap<Option, OptionView>()
                .ForMember(
                    src => src.MimeType,
                    opt => opt.MapFrom(src => src.MimeType.ToDescriptionString())
                );

            CreateMap<PoolPickHandle, PoolPickHandleView>();
        }
    }
}
