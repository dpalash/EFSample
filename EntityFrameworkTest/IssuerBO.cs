using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest
{
    public class IssuerBO : EntityTypeConfiguration<issuer>
    {
        [NotMapped]
        public int LocationId { get; set; }

        public IssuerBO()
        {
            ToTable("issuers");
            HasKey(a => a.Id);
            HasKey(a => a.EncCells);
            HasKey(a => a.IssuerShortName);
        }

    }
}

