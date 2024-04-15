using MediatR;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageHandler : IRequestHandler<RemoveProductImageRequest, RemoveProductImageResponse>
    {
        public async Task<RemoveProductImageResponse> Handle(RemoveProductImageRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
