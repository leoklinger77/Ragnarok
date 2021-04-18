using Ragnarok.Models.Enums;

namespace Ragnarok.Models.Payment
{
    public class Money : Payment
    {
        public double GetMoney { get; set; }
        public double MoneyBack { get; set; }

        public Money()
        {
        }

        public Money(int id, StatusPayment statusPayment, double amount, SalesOrder salesOrde, double getMoney, double moneyBack) :
            base(id, statusPayment, amount, salesOrde)
        {
            GetMoney = getMoney;
            MoneyBack = moneyBack;
        }


    }
}
