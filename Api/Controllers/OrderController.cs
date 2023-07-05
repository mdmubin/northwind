using Api.Models.Dto;
using Api.Models.ErrorModels;
using Api.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/orders/")]
public class OrderController : ControllerBase
{
    private readonly IDataServiceManager _dataService;

    public OrderController(IDataServiceManager dataService)
    {
        _dataService = dataService;
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OrderResultDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetOrderById(Guid id)
    {
        var order = await _dataService.OrderService.GetOrderDetailsAsync(id);
        return Ok(order);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateOrder(OrderRequestDto request)
    {
        if (request == null)
        {
            throw new BadRequestError("Invalid request for order creation.");
        }

        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }

        var orderResult = await _dataService.OrderService.CreateOrderAsync(request);

        return CreatedAtAction(nameof(GetOrderById), new { id = orderResult.Id }, orderResult);
    }


    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteOrder(Guid id)
    {
        await _dataService.OrderService.DeleteOrderAsync(id);
        return NoContent();
    }
}