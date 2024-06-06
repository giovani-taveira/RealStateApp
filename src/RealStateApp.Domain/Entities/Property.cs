using RealStateApp.Domain.DomainObjects;

namespace RealStateApp.Domain.Entities
{
	public class Property : Entity, IAggregateRoot
	{
		public string Title { get; set; }
		public string Characteristics { get; set; }
		public double Price { get; set; }
		public int QtyBedrooms { get; set; }
		public int QtyBathrooms { get; set; }
		public int QtySuites { get; set; }
		public double BuildingArea { get; set; }
		public double LandArea { get; set; }
		public DateTime CreatedAt { get; set; }

		public int AddressId { get; set; }
		public virtual Address Address { get; set; }

		public int? CondominiumId { get; set; }
		public virtual Condominium Condominium { get; set; }

		public int PropertyTypeId { get; set; }
		public virtual PropertyType PropertyType { get; set; }
	}
}
