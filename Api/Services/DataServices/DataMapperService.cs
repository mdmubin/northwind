using Api.Entities;
using Api.Models.Dto;
using AutoMapper;

namespace Api.Services.DataServices;

public class DataMapperService : Profile
{
    public DataMapperService()
    {
        CreateItemMap();
        CreateOrderMaps();
        CreateReviewMaps();
    }

    /// <summary>
    /// Create Mappings for Item DTOs and Item Entity Model
    /// </summary>
    private void CreateItemMap()
    {
        CreateMap<Item, ItemResultDto>()
            .ForMember(res => res.SellerId, opt => opt.MapFrom(src => src.UserId));

        CreateMap<ItemRequestDto, Item>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.SellerId));

        CreateMap<ItemUpdateDto, Item>();
    }

    /// <summary>
    /// Create mappings for models and DTOs related to Orders and Ordered Items
    /// </summary>
    private void CreateOrderMaps()
    {
        CreateMap<OrderEntry, OrderedItemDto>();

        CreateMap<Order, OrderResultDto>();

        CreateMap<Order, OrderResultDetailsDto>();

        CreateMap<OrderRequestDto, Order>()
            .ForMember(res => res.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));
    }
    
    /// <summary>
    /// Create mappings for models and DTOs related to Reviews
    /// </summary>
    private void CreateReviewMaps()
    {
        CreateMap<ReviewRequestDto, Review>()
            .ForMember(res => res.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(res => res.DateTimeReviewed, opt => opt.MapFrom(_ => DateTime.Now));

        CreateMap<Review, ReviewResultDto>();
    }
}