namespace RealStateApp.Domain.Entities
{
    public class BaseEntity
    {

    }

    public class Entity : BaseEntity
    {
        public int Id { get;  set; }
    }

    public class Entity<Guid> : BaseEntity
    {
        public Guid Id { get; set; }
    }
}
