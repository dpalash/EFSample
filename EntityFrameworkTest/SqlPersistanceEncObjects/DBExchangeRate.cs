namespace EncDomain.SqlPersistanceEncObjects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExchangeRate")]
    public partial class DBExchangeRate
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string BaseCurrency { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string ForeignCurrency { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Rate { get; set; }
    }
}
