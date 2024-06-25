using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Order.CompleteOrder
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommandRequest, CompleteOrderCommandResponse>
    {
        readonly IOrderService _orderService;
        readonly IMailService _mailService;

        public CompleteOrderCommandHandler(
            IOrderService orderService,
            IMailService mailService
            )
        {
            _orderService = orderService;
            _mailService = mailService;
        }
        public async Task<CompleteOrderCommandResponse> Handle(CompleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            (bool succeeded, CompletedOrderDTO dto) = await _orderService.CompleteOrderAsync(request.id);
            if (succeeded)
                await _mailService.SendCompletedOrderMailAsync(dto.EMail, dto.Username, dto.OrderCode, dto.OrderDate);
            return new();
        }
    }
}
