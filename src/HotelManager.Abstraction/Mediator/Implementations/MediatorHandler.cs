using MediatR;
using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Abstraction.Mediator.Implementations
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task PublishAsync(object notification)
        {
            return _mediator.Publish(notification, default);
        }

        public Task PublishAsync<TDomainEvent>(TDomainEvent notification) where TDomainEvent : IDomainEvent
        {
            return _mediator.Publish(notification, default);
        }

        public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request)
        {
            return _mediator.Send(request, default);
        }

        public Task SendAsync(ICommand request)
        {
            return _mediator.Send(request, default);
        }
    }
}