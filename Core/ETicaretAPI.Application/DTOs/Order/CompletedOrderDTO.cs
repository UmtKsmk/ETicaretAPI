namespace ETicaretAPI.Application.DTOs.Order
{
    public class CompletedOrderDTO
    {
        public string Username { get; set; }
        public string EMail { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
