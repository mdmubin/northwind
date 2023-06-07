using System.Text.Json;
using Api.Models.Dto;
using Api.Models.ErrorModels;
using Api.Models.Requests;
using Api.Services.DataServices;
using Api.Services.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/items/")]
public class ItemController : ControllerBase
{
    private readonly ILogService _logger;

    private readonly IDataServiceManager _dataService;

    public ItemController(IDataServiceManager dataService, ILogService logger)
    {
        _dataService = dataService;
        _logger = logger;
    }


    [HttpGet]
    [ProducesResponseType(typeof(List<ItemResultDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetItems([FromQuery] PageSizeRequest sizeRequest)
    {
        var items = await _dataService.ItemService.GetAllItemsAsync(sizeRequest);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(items.metaData));
        return Ok(items.items);
    }


    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ItemResultDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetItemById(Guid id)
    {
        var item = await _dataService.ItemService.GetItemAsync(id);
        return Ok(item);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateItem(ItemRequestDto newItem)
    {
        if (newItem == null)
        {
            throw new BadRequestError("Invalid request for item creation.");
        }

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var itemResult = await _dataService.ItemService.CreateItemAsync(newItem);

        return CreatedAtAction(nameof(GetItemById), new { id = itemResult.Id }, itemResult);
    }


    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<ActionResult> UpdateItem(Guid id, ItemUpdateDto item)
    {
        if (item == null)
        {
            throw new BadRequestError("Invalid request for item creation.");
        }

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var update = await _dataService.ItemService.UpdateItem(id, item);

        return AcceptedAtAction(nameof(GetItemById), new { id }, update);
    }


    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteItem(Guid id)
    {
        await _dataService.ItemService.DeleteItem(id);
        return NoContent();
    }
}