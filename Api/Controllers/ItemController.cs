using Api.Models.Dto;
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
}