namespace RealStateApp.Domain.Entities
{
    public class CondominiumType : Entity
    {
        public string Name { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Condominium> Condominiums { get; set; }
    }
}
