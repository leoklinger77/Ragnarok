using Ragnarok.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models.Payment
{
    [Table("TB_Payment")]
    public abstract class Payment
    {
        public int Id { get; set; }
        public StatusPayment StatusPayment { get; set; }
        public double Amount { get; set; }

        public SalesOrder SalesOrder { get; set; }                

        protected Payment()
        {
        }

        protected Payment(int id, StatusPayment statusPayment, double amount, SalesOrder salesOrder)
        {
            Id = id;
            StatusPayment = statusPayment;
            Amount = amount;
            SalesOrder = salesOrder;
        }
    }
}
