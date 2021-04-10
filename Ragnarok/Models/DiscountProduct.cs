using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_DiscountProduct")]
    public class DiscountProduct
    {
        public int Id { get; set; }
        public double DiscountAmount { get; set; }
        public bool Active { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DiscountProduct()
        {
        }

        public DiscountProduct(int id, double discountAmount, bool active, DateTime start, DateTime end, DateTime insertDate, DateTime updateDate){
            Id = id;
            DiscountAmount = discountAmount;
            Active = active;
            Start = start;
            End = end;
            InsertDate = insertDate;
            UpdateDate = updateDate;
        }
        
    }
}
