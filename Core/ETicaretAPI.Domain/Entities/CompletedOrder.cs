using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class CompletedOrder : BaseEntitiy
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
