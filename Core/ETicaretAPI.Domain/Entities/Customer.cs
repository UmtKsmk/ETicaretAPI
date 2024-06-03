using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer : BaseEntitiy
    {
        public string Name { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}
