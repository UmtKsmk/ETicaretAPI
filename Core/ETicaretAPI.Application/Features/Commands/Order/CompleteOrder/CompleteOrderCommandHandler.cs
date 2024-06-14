using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Order.CompleteOrder
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommandRequest, CompleteOrderCommandResponse>
    {
        readonly IOrderService _orderService;

        public CompleteOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
