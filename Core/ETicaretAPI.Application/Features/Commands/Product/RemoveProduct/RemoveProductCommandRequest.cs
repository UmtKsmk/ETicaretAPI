using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Product.DeleteProduct
{
    public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
    {
        public string Id { get; set; }
    }
}
