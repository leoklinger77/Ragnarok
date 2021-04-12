using Ragnarok.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_DiscountProduct")]
    public class DiscountStock
    {
        public int Id { get; set; }
        public double DiscountAmount { get; set; }
        public bool Active { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Employee RegisterEmployee { get; set; }
        public int RegisterEmployeeId { get; set; }

        public ICollection<DiscountProductStock> DiscountProductStock { get; set; } = new List<DiscountProductStock>();

        public DiscountStock()
        {
        }

        public DiscountStock(int id, double discountAmount, bool active, DateTime start, DateTime end, DateTime insertDate, DateTime updateDate, Employee registerEmployee)
        {
            Id = id;
            DiscountAmount = discountAmount;
            Active = active;
            Start = start;
            End = end;
            InsertDate = insertDate;
            UpdateDate = updateDate;
            RegisterEmployee = registerEmployee;

        }
        
    }
}
