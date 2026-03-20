namespace WatchStore.Contracts;

public interface IOrderCreatedEvent
{
    Guid WatchId { get; set; }
    int Quantity { get; set; }
}
