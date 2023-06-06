using Api.Data.Repositories;
using Api.Models.Dto;
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
            //TODO throw not found error
        }

        var itemResult = _mapper.Map<ItemResultDto>(item);
        return itemResult;
    }
}