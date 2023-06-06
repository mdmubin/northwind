using Api.Entities;
using Api.Models.Dto;
using AutoMapper;

namespace Api.Config;

public class MappingProfileConfiguration : Profile
{
    public MappingProfileConfiguration()
    {
        CreateMap<Item, ItemResultDto>()
            .ForMember(res => res.SellerId, opt => opt.MapFrom(src => src.UserId));

        // CreateMap<ItemCreationDto, Item>()
        //     .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
        //     .ForMember(dest => dest.Seller, opt => opt.MapFrom<ItemResolver>());
    }
}