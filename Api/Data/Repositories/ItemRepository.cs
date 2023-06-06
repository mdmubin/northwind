using Api.Entities;

namespace Api.Data.Repositories;

public class ItemRepository : BaseRepository<Item>
{
    public ItemRepository(NorthwindContext context)
        : base(context)
    {
    }

    public IEnumerable<Item> GetAllItems(bool trackChanges)
    {
        return FindAll(trackChanges)
            .OrderBy(i => i.Name)
            .ToList();
    }

    public Item GetItem(Guid id, bool trackChanges)
    {
        return FindByCondition(i => i.Id == id, trackChanges)
            .SingleOrDefault();
    }
}