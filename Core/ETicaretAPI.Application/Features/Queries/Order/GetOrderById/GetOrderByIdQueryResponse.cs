﻿namespace ETicaretAPI.Application.Features.Queries.Order.GetOrderById
{
    public class GetOrderByIdQueryResponse
    {
        public string Id { get; set; }
        public string OrderCode { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public object BasketItems { get; set; }
        public bool Completed { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
