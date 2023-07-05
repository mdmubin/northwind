namespace Api.Data.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly NorthwindContext _context;

    private readonly Lazy<ItemRepository> _itemRepository;

    private readonly Lazy<OrderRepository> _orderRepository;

    private readonly Lazy<OrderEntryRepository> _orderEntryRepository;

    private readonly Lazy<ReviewRepository> _reviewRepository;

    public RepositoryManager(NorthwindContext context)
    {
        _context = context;
        _itemRepository = new Lazy<ItemRepository>(new ItemRepository(context));
        _orderRepository = new Lazy<OrderRepository>(new OrderRepository(context));
        _orderEntryRepository = new Lazy<OrderEntryRepository>(new OrderEntryRepository(context));
        _reviewRepository = new Lazy<ReviewRepository>(new ReviewRepository(context));
    }

    public ItemRepository Items => _itemRepository.Value;
    public OrderRepository Orders => _orderRepository.Value;
    public OrderEntryRepository OrderEntries => _orderEntryRepository.Value;
    public ReviewRepository Reviews => _reviewRepository.Value;

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}