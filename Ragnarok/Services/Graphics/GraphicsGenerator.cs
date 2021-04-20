using Ragnarok.Models;
using Ragnarok.Models.Payment;
using Ragnarok.Models.ViewModels.Graphics;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Services.Graphics
{
    public class GraphicsGenerator
    {
        private readonly ISalesOrderRepository _salesOrderRepository;

        public GraphicsGenerator(ISalesOrderRepository salesOrderRepository)
        {
            _salesOrderRepository = salesOrderRepository;
        }

        public async Task<ICollection<GraphicsStandard>> SalesForTheLastSevenDays(int businessId)
        {
            ICollection<SalesOrder> list = await _salesOrderRepository.FindAllsSevenDaysAsync(businessId);
            ICollection<GraphicsStandard> Graphics = new List<GraphicsStandard>();

            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        for (int y = 0; y < 7; y++)
                        {
                            Graphics.Add(new GraphicsStandard
                            {
                                Date = DateTime.Now.Date.AddDays(-y),
                                Day = DateTime.Now.Date.AddDays(-y).Day.ToString(),
                                Month = DateTime.Now.Date.AddDays(-y).Month.ToString(),
                                Yaer = DateTime.Now.Date.AddDays(-y).Year.ToString(),
                                TypePayment = "Money"
                            });
                        }
                        break;
                    case 1:
                        for (int y = 0; y < 7; y++)
                        {
                            Graphics.Add(new GraphicsStandard
                            {
                                Date = DateTime.Now.Date.AddDays(-y),
                                Day = DateTime.Now.Date.AddDays(-y).Day.ToString(),
                                Month = DateTime.Now.Date.AddDays(-y).Month.ToString(),
                                Yaer = DateTime.Now.Date.AddDays(-y).Year.ToString(),
                                TypePayment = "Debit"
                            });
                        }
                        break;
                    case 2:
                        for (int y = 0; y < 7; y++)
                        {
                            Graphics.Add(new GraphicsStandard
                            {
                                Date = DateTime.Now.Date.AddDays(-y),
                                Day = DateTime.Now.Date.AddDays(-y).Day.ToString(),
                                Month = DateTime.Now.Date.AddDays(-y).Month.ToString(),
                                Yaer = DateTime.Now.Date.AddDays(-y).Year.ToString(),
                                TypePayment = "Credit"
                            });
                        }
                        break;
                }
            }
            foreach (var item in Graphics)
            {
                List<SalesOrder> itemList = list.Where(x => x.InsertDate.Date == item.Date.Date).ToList();

                switch (item.TypePayment)
                {
                    case "Money":
                        item.Value += itemList.Where(x => x.Payment is Money).Sum(x => x.TotalSales());
                        break;
                    case "Debit":
                        item.Value += itemList.Where(x => x.Payment is Debit).Sum(x => x.TotalSales());
                        break;
                    case "Credit":
                        item.Value += itemList.Where(x => x.Payment is Credit).Sum(x => x.TotalSales());
                        break;
                    default:
                        break;
                }
            }

            return Graphics;
        }
        public async Task<ICollection<GraphicsStandard>> ComparativeWeekly(int businessId)
        {
            ICollection<SalesOrder> listOrders = await _salesOrderRepository.LastTwoWeeksAsync(businessId);
            List<GraphicsStandard> Graphics = new List<GraphicsStandard>();

            for (int i = 0; i < 14; i++)
            {

                Graphics.Add(new GraphicsStandard
                {
                    Date = DateTime.Now.Date.AddDays(-i),
                    Day = DateTime.Now.Date.AddDays(-i).Day.ToString(),
                    Month = DateTime.Now.Date.AddDays(-i).Month.ToString(),
                    Yaer = DateTime.Now.Date.AddDays(-i).Year.ToString(),
                   
                });

                List<SalesOrder> itemList = listOrders.Where(x => x.InsertDate.Date == DateTime.Now.Date.AddDays(-i)).ToList();
                Graphics[i].Value += itemList.Sum(x => x.TotalSales());
            }

            return Graphics;
        }
    }
}
