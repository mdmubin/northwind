namespace Api.Data.Repositories;

public interface IRepositoryManager
{
    ItemRepository Items { get; }
    OrderRepository Orders { get; }
    OrderEntryRepository OrderEntries { get; }
    ReviewRepository Reviews { get; }

    public Task SaveChangesAsync();
}