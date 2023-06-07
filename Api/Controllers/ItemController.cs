using Api.Models.Dto;
using Api.Models.ErrorModels;
using Api.Services.DataServices;
using Api.Services.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/items")]
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
    public ActionResult GetItems()
    {
        var items = _dataService.ItemService.GetAllItems();
        return Ok(items);
    }


    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ItemResultDto), StatusCodes.Status200OK)]
    public ActionResult GetItemById(Guid id)
    {
        var item = _dataService.ItemService.GetItem(id);
        return Ok(item);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult CreateItem(ItemRequestDto newItem)
    {
        if (newItem == null)
        {
            throw new BadRequestError("Invalid request for item creation.");
        }

        var itemResult = _dataService.ItemService.CreateItem(newItem);

        return CreatedAtAction(nameof(GetItemById), new { id = itemResult.Id }, itemResult);
    }


    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public ActionResult UpdateItem(Guid id, ItemUpdateDto item)
    {
        if (item == null)
        {
            throw new BadRequestError("Invalid request for item creation.");
        }

        var update = _dataService.ItemService.UpdateItem(id, item);

        return AcceptedAtAction(nameof(GetItemById), new { id }, update);
    }


    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeleteItem(Guid id)
    {
        _dataService.ItemService.DeleteItem(id);
        return NoContent();
    }
}