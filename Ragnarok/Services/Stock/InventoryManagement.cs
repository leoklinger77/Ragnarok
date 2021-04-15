using Ragnarok.Models.ManyToMany;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task StockManagementAddAsync(PurchaseItemOrder itemOrder, int BusinessId)
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
                await _stockRepository.Insert(stock);
            }
            else
            {
                stockDB.AddQuantityStock(itemOrder.Quantity);
                stockDB.SalesPrice = itemOrder.SalesPrice;
                await _stockRepository.Update(stockDB);
            }
        }
        public async Task StockManagementRemoveAsync(ICollection<SalesItem> salesItem, int BusinessId)
        {
            foreach (var item in salesItem)
            {
                Models.Stock stockDB = await _stockRepository.FindByIdAsync(item.StockId, BusinessId);
                if (stockDB != null)
                {
                    stockDB.RemoveQuantityStock(item.Quantity);
                    await _stockRepository.Update(stockDB);
                }
                //TODO Implementar throw
            }

        }
    }
}
