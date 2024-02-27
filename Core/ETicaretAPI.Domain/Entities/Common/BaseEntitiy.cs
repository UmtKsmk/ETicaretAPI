namespace ETicaretAPI.Domain.Entities.Common
{
    public class BaseEntitiy
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
