using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models
{
    [Table("TB_SaleBox")]
    public class SaleBox
    {
        public int Id { get; set; }
        public DateTime Opening { get; set; }
        public DateTime? Clouse { get; set; }
        public double ApertureValue { get; set; }
        public double ClosingValue { get; set; }
        public Employee RegisterSales { get; set; }
        public int RegisterSalesId { get; set; }

        public ICollection<SalesOrder> SalesOrders { get; set; } = new List<SalesOrder>();

        public SaleBox()
        {
        }

        public SaleBox(int id, DateTime opening, DateTime? clouse, double apertureValue, double closingValue, Employee registerSales)
        {
            Id = id;
            Opening = opening;
            Clouse = clouse;
            ApertureValue = apertureValue;
            ClosingValue = closingValue;
            RegisterSales = registerSales;
        }

        public override bool Equals(object obj)
        {
            return obj is SaleBox box &&
                   Id == box.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public TimeSpan OpenTime()
        {
            if (Clouse != null)
            {
                TimeSpan Date = ((TimeSpan)(Clouse - Opening));
                return Date;
            }
            else
            {
                TimeSpan Date = (DateTime.Now - Opening);
                return Date;
            }
        }

        public double ValueSold()
        {
            double sum = 0;
            foreach (var item in SalesOrders)
            {
                sum += item.TotalSales();
            }
            return sum;
        }
        public bool BoxIsOpen()
        {
            return Clouse == null ? false : true;
        }

    }
}
