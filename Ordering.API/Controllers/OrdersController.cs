using MassTransit;
using Microsoft.AspNetCore.Mvc;
using WatchStore.Contracts;

namespace Ordering.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public class OrderRequest { public Guid WatchId { get; set; } public int Quantity { get; set; } }

    public OrdersController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequest orderRequest)
    {
        await _publishEndpoint.Publish<IOrderCreatedEvent>(new
        {
            orderRequest.WatchId,
            orderRequest.Quantity
        });

        return Ok(new { Message = "Pedido enviado para processamento!" });
    }
}
