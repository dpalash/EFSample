namespace EncDomain.SqlPersistanceEncObjects
{
    //using EncDomain.SqlPersistanceEncOrderObjects;
    //using Framework.PersistenceBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EncProducts")]
    public partial class DBEncProduct //: IPersistanceEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DBEncProduct()
        {
            EncProductPrices = new HashSet<DBEncProductPrice>();
            EncCells = new HashSet<DBEncCell>();
            //EncOrders = new HashSet<DBEncOrder>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(15)]
        public string ValidLicensePeriod { get; set; }

        public bool IsForSale { get; set; }

        public int EncProductTypeId { get; set; }

        public int IssuerId { get; set; }

        public int PriceBand { get; set; }

        public int CountryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DBEncProductPrice> EncProductPrices { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DBEncOrder> EncOrders { get; set; }

        [ForeignKey("EncProductTypeId")]
        public virtual DBEncProductType EncProductType { get; set; }

        [ForeignKey("IssuerId")]
        public virtual DBIssuer issuer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DBEncCell> EncCells { get; set; }
    }
}
