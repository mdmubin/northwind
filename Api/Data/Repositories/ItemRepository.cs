using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;

public class ItemRepository : BaseRepository<Item>
{
    public ItemRepository(NorthwindContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(i => i.Name)
            .ToListAsync();
    }

    public async Task<Item> GetItemAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(i => i.Id == id, trackChanges)
            .SingleOrDefaultAsync();
    }
}