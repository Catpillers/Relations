using Microsoft.EntityFrameworkCore;
using Relations.Dal.Models;

namespace Relations.Dal.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<RelationAddress> RelationAddresses { get; set; }
        public virtual DbSet<RelationCategory> RelationCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AddressType>()
                .HasMany(_ => _.RelationAddresses)
                .WithOne(_ => _.AddressType)
                .HasForeignKey(_ => _.AddressTypeId);

            builder.Entity<Category>()
                .HasMany(_ => _.RelationCategories)
                .WithOne(_ => _.Category)
                .HasForeignKey(_ => _.CategoryId);

            builder.Entity<Country>()
                .HasMany(_ => _.RelationAddresses)
                .WithOne(_ => _.Country)
                .HasForeignKey(_ => _.CountryId);


            builder.Entity<Relation>()
                .HasMany(_ => _.RelationCategories)
                .WithOne(_ => _.Relation)
                .HasForeignKey(_ => _.RelationId);

            builder.Entity<Relation>()
                .HasMany(_ => _.RelationAddresses)
                .WithOne(_ => _.Relation)
                .HasForeignKey(_ => _.RelationId);

            builder.Entity<RelationCategory>()
                .HasKey(_ => new {_.CategoryId, _.RelationId});

        }

        
    }
}
