using Microsoft.EntityFrameworkCore;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        #region DbSets
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Condominium> Condominiums { get; set; }
        public DbSet<CondominiumCharacteristic> CondominiumCharacteristics { get; set; }
        public DbSet<CondominiumType> CondominiumTypes { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
