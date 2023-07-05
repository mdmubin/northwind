using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;

public class OrderEntryRepository : BaseRepository<OrderEntry>
{
    public OrderEntryRepository(NorthwindContext context) : base(context)
    {
    }

    public async Task<ICollection<OrderEntry>> GetOrderEntriesAsync(Guid orderId, bool trackChanges)
    {
        var entries = await FindByCondition(e => e.OrderId == orderId, trackChanges)
            .OrderBy(e => e.AmountOrdered)
            .ToListAsync();

        return entries;
    }
}