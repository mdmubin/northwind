using Api.Entities;
using Api.Models.Dto;
using AutoMapper;

namespace Api.Services.DataServices;

public class DataMapperService : Profile
{
    public DataMapperService()
    {
        CreateItemMap();
    }

    /// <summary>
    /// Create Mappings for Item DTOs and Item Entity Model
    /// </summary>
    private void CreateItemMap()
    {
        CreateMap<Item, ItemResultDto>()
            .ForMember(res => res.SellerId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<ItemRequestDto, Item>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.SellerId));

        CreateMap<ItemUpdateDto, Item>();
    }
}