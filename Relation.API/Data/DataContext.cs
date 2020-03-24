using Microsoft.EntityFrameworkCore;
using Relation.API.Models;

namespace Relation.API.Data
{
    public partial class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public virtual DbSet<AddressType> TblAddressType { get; set; }
        public virtual DbSet<Category> TblCategory { get; set; }
        public virtual DbSet<Country> TblCountry { get; set; }
        public virtual DbSet<Models.Relation> TblRelation { get; set; }
        public virtual DbSet<RelationAddress> TblRelationAddress { get; set; }
        public virtual DbSet<RelationCategory> TblRelationCategory { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblAddressType");

                entity.Property(e => e.Code1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp1).HasColumnType("datetime");

                entity.Property(e => e.Timestamp2).HasColumnType("datetime");

                entity.Property(e => e.Timestamp3).HasColumnType("datetime");

                entity.Property(e => e.Timestamp4).HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCategory");

                entity.Property(e => e.Code1)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code3)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code4)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code5)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code6)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp1).HasColumnType("datetime");

                entity.Property(e => e.Timestamp2).HasColumnType("datetime");

                entity.Property(e => e.Timestamp3).HasColumnType("datetime");

                entity.Property(e => e.Timestamp4).HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCountry");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iso31662)
                    .HasColumnName("ISO3166_2")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Iso31663)
                    .HasColumnName("ISO3166_3")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCodeFormat)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Models.Relation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblRelation");

                entity.Property(e => e.ArrivalBetween).HasColumnType("datetime");

                entity.Property(e => e.ArrivalBetweenAnd).HasColumnType("datetime");

                entity.Property(e => e.ArrivalName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BankAccount)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BankBic)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CarrierCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChamberOfCommerce)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DebtorNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultPostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultStreet)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureBetween).HasColumnType("datetime");

                entity.Property(e => e.DepartureBetweenAnd).HasColumnType("datetime");

                entity.Property(e => e.DepartureName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DigitalFreightDocumentEmailTemplateId).HasColumnName("DigitalFreightDocumentEMailTemplateId");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("EMailAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralLedgerAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imaddress)
                    .HasColumnName("IMAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceEmailAddress)
                    .HasColumnName("InvoiceEMailAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceGroupByTransportOrderColumnName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceTo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PriceListName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PriceListNameForCollecting)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).IsUnicode(false);

                entity.Property(e => e.SendDigitalFreightDocumentsByEmail).HasColumnName("SendDigitalFreightDocumentsByEMail");

                entity.Property(e => e.SendFreightStatusUpdateByEmail).HasColumnName("SendFreightStatusUpdateByEMail");

                entity.Property(e => e.SkypeAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SupplyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VatName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VatNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VendorNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RelationAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblRelationAddress");

                entity.Property(e => e.Building)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberSuffix)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RelationCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblRelationCategory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
