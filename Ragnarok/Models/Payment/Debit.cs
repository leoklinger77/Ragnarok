using Ragnarok.Models.Enums;
using System;

namespace Ragnarok.Models.Payment
{
    public class Debit : Payment
    {
        public DateTime TimeOfPayment { get; set; }

        public Debit() : base()
        {
        }

        public Debit(int id, StatusPayment statusPayment, double amount, SalesOrder salesOrde, DateTime timeOfPayment) :
            base(id, statusPayment, amount, salesOrde)
        {
            TimeOfPayment = timeOfPayment;
        }
    }
}
