namespace ETicaretAPI.Domain.Entities.Common
{
    public class BaseEntitiy
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
