using Microsoft.EntityFrameworkCore;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        #region DbSets
        public DbSet<Address> Sections { get; set; }
        public DbSet<Condominium> DataRecords { get; set; }
        public DbSet<CondominiumCharacteristics> DataRecordRows { get; set; }
        public DbSet<CondominiumType> DataRecordColumns { get; set; }
        public DbSet<Property> DataRecordValues { get; set; }
        public DbSet<PropertyType> Users { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
