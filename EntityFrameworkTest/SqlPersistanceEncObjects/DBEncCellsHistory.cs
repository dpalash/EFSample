//using Framework.PersistenceBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EncDomain.SqlPersistanceEncObjects
{
    [Table("EncCellsHistory")]
    public partial class DBEncCellsHistory //: IPersistanceEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime UtcAuditDate { get; set; }

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
    }
}
