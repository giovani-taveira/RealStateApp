using RealStateApp.Domain.DomainObjects;

namespace RealStateApp.Domain.Entities
{
	public class Condominium : Entity, IAggregateRoot
    {
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CondominiumTypeId { get; set; }
        public CondominiumType CondominiumType { get; set; }

        public virtual ICollection<CondominiumCharacteristic> Characteristics { get; set; }
		public virtual ICollection<Property> Properties { get; set; }
	}
}
