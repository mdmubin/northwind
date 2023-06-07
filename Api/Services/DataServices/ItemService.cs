using Api.Data.Repositories;
using Api.Entities;
using Api.Models.Dto;
using Api.Models.ErrorModels;
using Api.Services.Logging;
using AutoMapper;

namespace Api.Services.DataServices;

public sealed class ItemService
{
    private readonly ILogService _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public ItemService(IRepositoryManager repository, IMapper mapper, ILogService logger)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<ItemResultDto> GetAllItems(bool trackChanges = true)
    {
        var items = _repository.Items.GetAllItems(trackChanges);
        var itemsResult = _mapper.Map<IEnumerable<ItemResultDto>>(items);
        return itemsResult;
    }

    public ItemResultDto GetItem(Guid id, bool trackChanges = true)
    {
        var item = _repository.Items.GetItem(id, trackChanges);
        if (item == null)
        {
            throw new NotFoundError($"Item not found. No item with id = {id}");
        }

        var itemResult = _mapper.Map<ItemResultDto>(item);
        return itemResult;
    }

    public ItemResultDto CreateItem(ItemRequestDto request)
    {
        var newItem = _mapper.Map<Item>(request);
        
        _repository.Items.Create(newItem);
        _repository.SaveChangesAsync();

        var resItem = _mapper.Map<ItemResultDto>(newItem);

        return resItem;
    }

    public ItemResultDto UpdateItem(Guid id, ItemUpdateDto update)
    {
        var item = _repository.Items.GetItem(id, true);
        if (item == null)
        {
            throw new NotFoundError($"Item not found. No item with id = {id}");
        }

        _mapper.Map(update, item);
        _repository.Items.Update(item);
        _repository.SaveChangesAsync();

        var resItem = _mapper.Map<ItemResultDto>(item);

        return resItem;
    }

    public void DeleteItem(Guid id)
    {
        var item = _repository.Items.GetItem(id, true);
        if (item == null)
        {
            throw new NotFoundError($"Item not found. No item with id = {id}");
        }

        _repository.Items.Delete(item);
        _repository.SaveChangesAsync();
    }
}