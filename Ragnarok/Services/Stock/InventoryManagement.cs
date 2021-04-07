using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Ragnarok.Services.Stock
{
    public class InventoryManagement
    {
        private readonly IStockRepository _stockRepository;        

        public InventoryManagement(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task StockManagementAsync(PurchaseItemOrder itemOrder, int BusinessId)
        {
            Models.Stock stockDB = await _stockRepository.FindByIdAsync(itemOrder.ProductId, BusinessId);
            if (stockDB == null)
            {
                Models.Stock stock = new Models.Stock();
                stock.InsertDate = DateTime.Now;
                stock.ProductId = itemOrder.ProductId;
                stock.AddQuantityStock(itemOrder.Quantity);
                stock.SalesPrice = itemOrder.SalesPrice;
                stock.ValidationDate = itemOrder.ValidationDate;                
                _stockRepository.Insert(stock);
            }
            else
            {
                stockDB.AddQuantityStock(itemOrder.Quantity);
                stockDB.SalesPrice = itemOrder.SalesPrice;
                _stockRepository.Update(stockDB);
            }
        }
    }
}
