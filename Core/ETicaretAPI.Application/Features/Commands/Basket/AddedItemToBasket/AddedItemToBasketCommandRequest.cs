using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Basket.AddedItemToBasket
{
    public class AddedItemToBasketCommandRequest : IRequest<AddedItemToBasketCommandResponse>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
