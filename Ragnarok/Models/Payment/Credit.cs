using Ragnarok.Models.Enums;

namespace Ragnarok.Models.Payment
{
    public class Credit : Payment
    {
        public int Invoice { get; set; }

        public Credit()
        {
        }

        public Credit(int id, StatusPayment statusPayment, double amount, SalesOrder salesOrde, int invoice) :
            base(id, statusPayment, amount, salesOrde)
        {
            Invoice = invoice;
        }
    }
}
