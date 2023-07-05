using Api.Data.Repositories;
using Api.Entities;
using Api.Models.Dto;
using Api.Models.ErrorModels;
using Api.Models.Requests;
using AutoMapper;

namespace Api.Services.DataServices;

public sealed class OrderService
{
    private readonly IMapper _mapper;

    private readonly IRepositoryManager _repository;

    public OrderService(IRepositoryManager repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<(IEnumerable<OrderResultDto> orders, MetaData metaData)> GetUserOrdersAsync(Guid userId,
        PageSizeRequest sizeRequest, bool trackChanges = true)
    {
        var orders = await _repository.Orders.GetAllUserOrdersAsync(userId, sizeRequest, trackChanges);
        var ordersResult = _mapper.Map<IEnumerable<OrderResultDto>>(orders);
        return (ordersResult, orders.MetaData);
    }

    public async Task<OrderResultDetailsDto> GetOrderDetailsAsync(Guid orderId, bool trackChanges = true)
    {
        var order = await _repository.Orders.GetOrderAsync(orderId, trackChanges);
        order.OrderedItems = await _repository.OrderEntries.GetOrderEntriesAsync(orderId, trackChanges);
        var orderDetails = _mapper.Map<OrderResultDetailsDto>(order);
        return orderDetails;
    }

    public async Task<OrderResultDetailsDto> CreateOrderAsync(OrderRequestDto request)
    {
        var newOrder = _mapper.Map<Order>(request);

        _repository.Orders.Create(newOrder);
        await _repository.SaveChangesAsync();

        var resOrder = _mapper.Map<OrderResultDetailsDto>(newOrder);

        return resOrder;
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        var orderedItems = await _repository.OrderEntries.GetOrderEntriesAsync(id, true);
        if (orderedItems == null)
        {
            throw new NotFoundError($"Could not find any order entries for order id = {id}");
        }
        
        var order = await _repository.Orders.GetOrderAsync(id, true);
        if (order == null)
        {
            throw new NotFoundError($"Could not find any order with id = {id}");
        }

        _repository.OrderEntries.DeleteAll(orderedItems);
        _repository.Orders.Delete(order);

        await _repository.SaveChangesAsync();
    }
}