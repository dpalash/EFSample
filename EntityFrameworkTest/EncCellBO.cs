using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest
{
    public partial class EncCellBO : EncCell
    {
        [NotMapped]
        public int CountryId { get; set; }
    }
}
