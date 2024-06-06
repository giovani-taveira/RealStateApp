namespace RealStateApp.Domain.Entities
{
	public class PropertyType : Entity
    {
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public virtual ICollection<Property> Properties { get; set; }
	}
}
