namespace EncDomain.SqlPersistanceEncObjects
{
    //using Framework.PersistenceBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EncProductPrices")]
    public partial class DBEncProductPrice //: IPersistanceEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EncProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EncOrderTypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime ValidFromUtcDate { get; set; }

        public DateTime? ValidToUtcDateTo { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("EncProductId")]
        public virtual DBEncProduct EncProduct { get; set; }
    }
}
