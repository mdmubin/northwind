using Api.Entities;
using Api.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;

public class ItemRepository : BaseRepository<Item>
{
    public ItemRepository(NorthwindContext context)
        : base(context)
    {
    }

    public async Task<PagedList<Item>> GetAllItemsAsync(PageSizeRequest sizeRequest, bool trackChanges)
    {
        var items = FindAll(trackChanges)
            .OrderBy(i => i.Name);

        return await PagedList<Item>.ToPagedList(items, sizeRequest.PageNumber, sizeRequest.PageSize);
    }

    public async Task<Item> GetItemAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(i => i.Id == id, trackChanges)
            .SingleOrDefaultAsync();
    }
}