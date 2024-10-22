﻿using MediatR;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImage
{
    public class GetProductImagesQueryRequest : IRequest<List<GetProductImagesQueryResponse>>
    {
        public string Id { get; set; }
    }
}
