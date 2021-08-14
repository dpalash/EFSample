//using Framework.PersistenceBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EncDomain.SqlPersistanceEncObjects
{
    [Table("EncCellReplacements")]
    public partial class DBEncCellReplacement //: IPersistanceEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OriginalCellId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReplacementCellId { get; set; }

        public DateTime? ReplacedDate { get; set; }

        [ForeignKey("ReplacementCellId")]
        public virtual DBEncCell ReplacingEncCell { get; set; }

        [ForeignKey("OriginalCellId")]
        public virtual DBEncCell ReplacedEncCell { get; set; }
    }
}
