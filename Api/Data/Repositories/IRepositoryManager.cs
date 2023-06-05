namespace Api.Data.Repositories;

public interface IRepositoryManager
{
    ItemRepository Items { get; }

    // add other repository items here


    public Task SaveChangesAsync();
}