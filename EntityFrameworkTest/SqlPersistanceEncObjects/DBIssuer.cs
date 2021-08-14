namespace EncDomain.SqlPersistanceEncObjects
{
    //using Framework.PersistenceBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("issuers")]
    public partial class DBIssuer//:IPersistanceEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DBIssuer()
        {
            EncCells = new HashSet<DBEncCell>();
            EncProducts = new HashSet<DBEncProduct>();
        }

        [Key]
        [Column("_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("_Issuer")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("_IssuerShortName")]
        [StringLength(10)]
        public string ShortName { get; set; }

        [Column("_Active")]
        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DBEncCell> EncCells { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DBEncProduct> EncProducts { get; set; }
    }
}
