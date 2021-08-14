namespace EncDomain.SqlPersistanceEncObjects
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    //using AzureStorage.SqlDB;
    //using Framework.Mapper;
    //using EncDomain.Entity;
    using System.Collections.Generic;

    public partial class EncManagementDbContext : DbContext//Base
    {
        public EncManagementDbContext() : base(@"data source=FARUK-ASUS\FARUK;initial catalog=neptune;user id=sa;password=Pass@123;MultipleActiveResultSets=True;App=EntityFramework")//base()
        {

        }

        //public EncManagementDbContext( Action<string> log)
        //    : base("name=EncManagementDbContext")//, objectConverter, log)
        //{
        //    //this.Configuration.AutoDetectChangesEnabled = false;
        //    //this.Configuration.ValidateOnSaveEnabled = false;
        //}
        public virtual DbSet<DBIssuer> issuers { get; set; }
        public virtual DbSet<DBEncCellReplacement> EncCellReplacements { get; set; }
        public virtual DbSet<DBEncCell> EncCells { get; set; }
        public virtual DbSet<DBEncCellsHistory> EncCellsHistories { get; set; }
        public virtual DbSet<DBEncProductPrice> EncProductPrices { get; set; }
        public virtual DbSet<DBEncProduct> EncProducts { get; set; }
        public virtual DbSet<DBEncProductType> EncProductTypes { get; set; }
        public virtual DbSet<DBExchangeRate> ExchangeRates { get; set; }

        //public virtual DbSet<Issuer> issuers { get; set; }
        //public virtual DbSet<EncCellReplacement> EncCellReplacements { get; set; }
        //public virtual DbSet<EncCell> EncCells { get; set; }
        //public virtual DbSet<DBEncCellsHistory> EncCellsHistories { get; set; }
        //public virtual DbSet<EncProductPrice> EncProductPrices { get; set; }
        //public virtual DbSet<EncProduct> EncProducts { get; set; }
        //public virtual DbSet<EncProductType> EncProductTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBEncCell>()
                .Property(e => e.CellName)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncCell>()
                .Property(e => e.BoundarySLat)
                .HasPrecision(11, 8);

            modelBuilder.Entity<DBEncCell>()
                .Property(e => e.BoundaryWLon)
                .HasPrecision(11, 8);

            modelBuilder.Entity<DBEncCell>()
                .Property(e => e.BoundaryNLat)
                .HasPrecision(11, 8);

            modelBuilder.Entity<DBEncCell>()
                .Property(e => e.BoundaryELon)
                .HasPrecision(11, 8);

            modelBuilder.Entity<DBEncCell>()
                .Property(e => e.PolygonPoints)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncCell>()
                .Property(e => e.GeometryData)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncCell>()
                .HasMany(e => e.ReplacedEncCell)
                .WithRequired(e => e.ReplacedEncCell)
                .HasForeignKey(e => e.OriginalCellId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DBEncCell>()
                .HasMany(e => e.ReplacingEncCell)
                .WithRequired(e => e.ReplacingEncCell)
                .HasForeignKey(e => e.ReplacementCellId);

            modelBuilder.Entity<DBEncCell>()
                .HasMany(e => e.EncProducts)
                .WithMany(e => e.EncCells)
                .Map(m => m.ToTable("EncCellsInEncProduct").MapLeftKey("EncCellId").MapRightKey("EncProductId"));

            modelBuilder.Entity<DBEncCellsHistory>()
                .Property(e => e.CellName)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncCellsHistory>()
                .Property(e => e.BoundarySLat)
                .HasPrecision(11, 8);

            modelBuilder.Entity<DBEncCellsHistory>()
                .Property(e => e.BoundaryWLon)
                .HasPrecision(11, 8);

            modelBuilder.Entity<DBEncCellsHistory>()
                .Property(e => e.BoundaryNLat)
                .HasPrecision(11, 8);

            modelBuilder.Entity<DBEncCellsHistory>()
                .Property(e => e.BoundaryELon)
                .HasPrecision(11, 8);

            modelBuilder.Entity<DBEncCellsHistory>()
                .Property(e => e.PolygonPoints)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncCellsHistory>()
                .Property(e => e.GeometryData)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncProductPrice>()
                .Property(e => e.Price)
                .HasPrecision(12, 2);

            modelBuilder.Entity<DBEncProduct>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncProduct>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncProduct>()
                .Property(e => e.ValidLicensePeriod)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncProduct>()
                .HasMany(e => e.EncProductPrices)
                .WithRequired(e => e.EncProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DBEncProductType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DBEncProductType>()
                .HasMany(e => e.EncProducts)
                .WithRequired(e => e.EncProductType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DBExchangeRate>()
                .Property(e => e.BaseCurrency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DBExchangeRate>()
                .Property(e => e.ForeignCurrency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DBExchangeRate>()
                .Property(e => e.Rate)
                .HasPrecision(18, 6);

            modelBuilder.Entity<DBIssuer>()
                .Property(e => e.ShortName)
                .IsUnicode(false);

            modelBuilder.Entity<DBIssuer>()
                .HasMany(e => e.EncCells)
                .WithRequired(e => e.Issuer)
                .HasForeignKey(e => e.IssuerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DBIssuer>()
                .HasMany(e => e.EncProducts)
                .WithRequired(e => e.issuer)
                .HasForeignKey(e => e.IssuerId)
                .WillCascadeOnDelete(false);
        }
    }
}
