using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Domain.Entities
{
    public class Basket : BaseEntitiy
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
