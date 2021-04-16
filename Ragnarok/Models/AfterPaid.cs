using Ragnarok.Models.Enums;
using System;

namespace Ragnarok.Models
{
    public class AfterPaid : Payment
    {
        public DateTime SupposedPaymentDate { get; set; }

        public AfterPaid()
        {
        }

        public AfterPaid(int id, StatusPayment statusPayment, double amount, SalesOrder salesOrde, DateTime dueData, DateTime supposedPaymentDate) :
            base(id, statusPayment, amount, salesOrde)
        {
            SupposedPaymentDate = supposedPaymentDate;
        }
    }
}
