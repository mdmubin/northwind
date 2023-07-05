using Api.Entities;
using Api.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;

public class OrderRepository : BaseRepository<Order>
{
    public OrderRepository(NorthwindContext context) : base(context)
    {
    }

    public async Task<PagedList<Order>> GetAllUserOrdersAsync(Guid userId, PageSizeRequest sizeRequest,
        bool trackChanges)
    {
        var orders = FindByCondition(o => o.UserId == userId, trackChanges)
            .OrderBy(o => o.DateTimeOrdered);

        return await PagedList<Order>.ToPagedList(orders, sizeRequest.PageNumber, sizeRequest.PageSize);
    }

    public async Task<Order> GetOrderAsync(Guid orderId, bool trackChanges)
    {
        return await FindByCondition(o => o.Id == orderId, trackChanges)
            .SingleOrDefaultAsync();
    }
}