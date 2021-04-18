using Ragnarok.Models.Enums;
using System;

namespace Ragnarok.Models.Payment
{
    public class PayLater : Payment
    {
        public DateTime SupposedPaymentDate { get; set; }

        public PayLater()
        {
        }

        public PayLater(int id, StatusPayment statusPayment, double amount, SalesOrder salesOrde, DateTime dueData, DateTime supposedPaymentDate) :
            base(id, statusPayment, amount, salesOrde)
        {
            SupposedPaymentDate = supposedPaymentDate;
        }
    }
}
