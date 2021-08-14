namespace EntityFrameworkTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
            : base("name=TestDBContext")
        {
        }

        public virtual DbSet<EncCell> EncCells { get; set; }
        public virtual DbSet<issuer> issuers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EncCell>()
                .Property(e => e.CellName)
                .IsUnicode(false);

            //modelBuilder.Entity<issuer>().Map<IssuerBO>(m => m.Requires("Discriminator").HasValue("NULL"));

            modelBuilder.Entity<issuer>()
                .Property(e => e.IssuerShortName)
                .IsUnicode(false);


            modelBuilder.Entity<issuer>()
                .HasMany(e => e.EncCells)
                .WithRequired(e => e.issuer)
                .HasForeignKey(e => e.Issuer3Id)
                .WillCascadeOnDelete(false);
        }
    }
}
