using Ragnarok.Models.Payment;

namespace Ragnarok.Models.ViewModels

{
    public class SalesOrderFormViewModel
    {
        public SalesOrder SalesOrder { get; set; }
        public Debit debit { get; set; }
        public Credit Credit { get; set; }
        public Ticket Ticket { get; set; }
        public Money Money { get; set; }
        public PayLater PayLater { get; set; }
    }
}
