namespace HotelManager.Abstraction.Mediator.Abstractions
{
    public interface IMediatorHandler
    {
        Task PublishAsync(object notification);

        Task PublishAsync<TDomainEvent>(TDomainEvent notification) where TDomainEvent : IDomainEvent;

        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request);

        Task SendAsync(ICommand request);
    }
}