using Api.Entities;

namespace Api.Data.Repositories;

public class ItemRepository : BaseRepository<Item>
{
    public ItemRepository(NorthwindContext context)
        : base(context)
    {
    }
}