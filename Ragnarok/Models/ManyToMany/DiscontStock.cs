using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Models.ManyToMany
{
    [Table("TB_DiscontStock")]
    public class DiscontStock
    {
        public DiscountProduct DiscountProduct { get; set; }
        public int DiscountProductId { get; set; }

        public Stock Stock { get; set; }
        public int StockId { get; set; }

        public double DiscountValue { get; set; }
        public DateTime MyProperty { get; set; }
    }
}
