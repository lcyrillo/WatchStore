using Catalog.API.Data;
using MassTransit;
using WatchStore.Contracts;

namespace Catalog.API.Consumers;

public class OrderCreatedConsumer : IConsumer<IOrderCreatedEvent>
{
    private readonly CatalogDbContext _context;
    private readonly ILogger<OrderCreatedConsumer> _logger;

    public OrderCreatedConsumer(CatalogDbContext context, 
        ILogger<OrderCreatedConsumer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<IOrderCreatedEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation("Processando baixa de estoque para o Relógio: {WatchId}", message.WatchId);

        var watch = await _context.Watches.FindAsync(message.WatchId);

        if (watch != null)
        {
            if (watch.Stock >= message.Quantity)
            {
                watch.Stock -= message.Quantity;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Estoque atualizado! Novo saldo: {Stock}", watch.Stock);
            }
            else
            {
                _logger.LogWarning("Estoque insuficiente para o relógio {WatchId}", message.WatchId);
            }
        }
    }
}
