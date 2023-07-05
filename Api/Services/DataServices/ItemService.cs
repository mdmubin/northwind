using Api.Data.Repositories;
using Api.Entities;
using Api.Models.Dto;
using Api.Models.ErrorModels;
using Api.Models.Requests;
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

    public async Task<(IEnumerable<ItemResultDto> items, MetaData metaData)> GetAllItemsAsync(
        PageSizeRequest sizeRequest, bool trackChanges = true)
    {
        var items = await _repository.Items.GetAllItemsAsync(sizeRequest, trackChanges);
        var itemsResult = _mapper.Map<IEnumerable<ItemResultDto>>(items);
        return (itemsResult, items.MetaData);
    }

    public async Task<ItemResultDto> GetItemAsync(Guid id, bool trackChanges = true)
    {
        var item = await _repository.Items.GetItemAsync(id, trackChanges);
        if (item == null)
        {
            throw new NotFoundError($"Item not found. No item with id = {id}");
        }

        var itemResult = _mapper.Map<ItemResultDto>(item);
        return itemResult;
    }

    public async Task<(IEnumerable<ReviewResultDto> reviews, MetaData metaData)> GetItemReviews(Guid itemId,
        PageSizeRequest sizeRequest,
        bool trackChanges = true)
    {
        var item = await _repository.Items.GetItemAsync(itemId, trackChanges);
        if (item == null)
        {
            throw new NotFoundError($"Item not found. No item with id = {itemId}");
        }

        var reviews = await _repository.Reviews.GetAllItemReviewsAsync(itemId, sizeRequest, trackChanges);
        var reviewResult = _mapper.Map<IEnumerable<ReviewResultDto>>(reviews);

        return (reviewResult, reviews.MetaData);
    }

    public async Task<ReviewResultDto> CreateItemReviewAsync(ReviewRequestDto request)
    {
        var newReview = _mapper.Map<Review>(request);

        _repository.Reviews.Create(newReview);
        await _repository.SaveChangesAsync();

        var resReview = _mapper.Map<ReviewResultDto>(newReview);
        return resReview;
    }

    public async Task<ItemResultDto> CreateItemAsync(ItemRequestDto request)
    {
        var newItem = _mapper.Map<Item>(request);

        _repository.Items.Create(newItem);
        await _repository.SaveChangesAsync();

        var resItem = _mapper.Map<ItemResultDto>(newItem);

        return resItem;
    }

    public async Task<ItemResultDto> UpdateItem(Guid id, ItemUpdateDto update)
    {
        var item = await _repository.Items.GetItemAsync(id, true);
        if (item == null)
        {
            throw new NotFoundError($"Item not found. No item with id = {id}");
        }

        _mapper.Map(update, item);
        _repository.Items.Update(item);
        await _repository.SaveChangesAsync();

        var resItem = _mapper.Map<ItemResultDto>(item);

        return resItem;
    }

    public async Task DeleteItem(Guid id)
    {
        var item = await _repository.Items.GetItemAsync(id, true);
        if (item == null)
        {
            throw new NotFoundError($"Item not found. No item with id = {id}");
        }

        _repository.Items.Delete(item);
        await _repository.SaveChangesAsync();
    }
}