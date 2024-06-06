namespace RealStateApp.Domain.Entities
{
	public class Address : Entity
    {
		public string CEP { get; set; }
		public string StreetName { get; set; }
		public string NeighborhoodName { get; set; }
		public string City { get; set; }
		public string Longitude { get; set; }
		public string Latitude { get; set; }
		public string Number { get; set; }
		public string Complement { get; set; }
		public DateTime CreatedAt { get; set; }

		public virtual Property Property { get; set; }
	}
}
