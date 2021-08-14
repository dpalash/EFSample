namespace EntityFrameworkTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class issuer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public issuer()
        {
            EncCells = new List<EncCell>();
        }

        [Key]
        [Column("_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("_Issuer")]
        [Required]
        [StringLength(50)]
        public string Issuer { get; set; }

        [Column("_IssuerShortName")]
        [StringLength(10)]
        public string IssuerShortName { get; set; }

        [Column("_Active")]
        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<EncCell> EncCells { get; set; }
    }
}
