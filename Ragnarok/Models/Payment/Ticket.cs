using Ragnarok.Models.Enums;
using System;

namespace Ragnarok.Models.Payment
{
    public class Ticket : Payment
    {
        public DateTime DueData { get; set; }
        public DateTime PayDay { get; set; }

        public Ticket()
        {
        }

        public Ticket(int id, StatusPayment statusPayment, double amount, SalesOrder salesOrde, DateTime dueData, DateTime payDay):
            base(id, statusPayment, amount, salesOrde)
        {
            DueData = dueData;
            PayDay = payDay;
        }
    }
}
