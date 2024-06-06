namespace RealStateApp.Domain.Entities
{
    public class CondominiumCharacteristics : Entity
    {
		public string Characteristic { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public int CondominiumId { get; set; }
		public virtual Condominium Condominium { get; set; }
	}
}
