using ETicaretAPI.Application.Abstractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Basket.AddedItemToBasket
{
    internal class AddedItemToBasketCommandHandler : IRequestHandler<AddedItemToBasketCommandRequest, AddedItemToBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public AddedItemToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<AddedItemToBasketCommandResponse> Handle(AddedItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.AddedItemToBasketAsync(new()
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
            });

            return new();
        }
    }
}
