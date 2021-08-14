namespace EntityFrameworkTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EncCells")]
    public partial class EncCell
    {
        public int Id { get; set; }

        [Column("Issuer3Id")]
        public int Issuer3Id { get; set; }

        [Required]
        [StringLength(8)]
        public string CellName { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public bool? IsForSale { get; set; }

        [ForeignKey("Issuer3Id")]
        public virtual issuer issuer { get; set; }
    }
}
