namespace Api.Data.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly NorthwindContext _context;

    private readonly Lazy<ItemRepository> _itemRepository;

    public RepositoryManager(NorthwindContext context)
    {
        _context = context;
        _itemRepository = new Lazy<ItemRepository>(new ItemRepository(context));
    }

    public ItemRepository Items => _itemRepository.Value;

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}