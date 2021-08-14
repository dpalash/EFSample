////using Framework.PersistenceBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EncDomain.SqlPersistanceEncObjects
{
    [Table("EncCells")]
    public partial class DBEncCell //: IPersistanceEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DBEncCell()
        {
            ReplacedEncCell = new List<DBEncCellReplacement>();
            ReplacingEncCell = new List<DBEncCellReplacement>();
            EncProducts = new List<DBEncProduct>();
        }

        public int Id { get; set; }

        public int IssuerId { get; set; }

        [Required]
        [StringLength(8)]
        public string CellName { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public byte NavigationalPurpose { get; set; }

        public decimal BoundarySLat { get; set; }

        public decimal BoundaryWLon { get; set; }

        public decimal BoundaryNLat { get; set; }

        public decimal BoundaryELon { get; set; }

        public string PolygonPoints { get; set; }

        public short BaseEdition { get; set; }

        public DateTime BaseIssueDate { get; set; }

        public short? LatestUpdateNumber { get; set; }

        public DateTime? RecordLastUpdated { get; set; }

        public DateTime? AddedDate { get; set; }

        public string GeometryData { get; set; }

        public DateTime? ReleaseDateUtc { get; set; }

        public DateTime? CancelDateUtc { get; set; }

        public DateTime? ReplaceDateUtc { get; set; }

        public DbGeography Geography { get; set; }

        public int? DownloadedBaseEdition { get; set; }

        public int? DownloadedUpdateNumber { get; set; }

        public DateTime? DownloadedUtcDate { get; set; }

        public DbGeometry Geometry { get; set; }

        public int? DownloadedIhoBaseEdition { get; set; }

        public int? DownloadedIhoUpdateNumber { get; set; }

        public DateTime? DownloadedIhoUtcDate { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool IsForSale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("ReplacedEncCell")]
        public virtual List<DBEncCellReplacement> ReplacedEncCell { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [InverseProperty("ReplacingEncCell")]
        public virtual List<DBEncCellReplacement> ReplacingEncCell { get; set; }

        [ForeignKey("IssuerId")]
        public virtual DBIssuer Issuer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<DBEncProduct> EncProducts { get; set; }
    }
}
