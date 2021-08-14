namespace EncDomain.SqlPersistanceEncObjects
{
    using EncDomain.SqlPersistanceEncObjects;
    //using Framework.PersistenceBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EncCellsInEncProduct")]
    public partial class DBEncCellsInEncProduct //: IPersistanceEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DBEncCellsInEncProduct()
        {

        }

        public int EncCellId { get; set; }

        public int EncProductId { get; set; }

    }
}
