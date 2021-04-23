using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Ragnarok.Repository.Interfaces
{
    public interface IStockRepository
    {
        Task<IPagedList<Stock>> FindAllsPagedListAsync(int? page,int? numberPerPage,string search,DateTime startDate, DateTime endDate, int businessId);
        Task<ICollection<Stock>> FindAllsAsync(string search, DateTime startDate, DateTime endDate, int businessId);
        Task<ICollection<Stock>> FindAllsAsync(int businessId);
        Task<ICollection<Stock>> FindAllsProductsNotDiscount(int businessId);
        Task<Stock> FindByIdAsync(int id, int businessId);
        Task Insert(Stock stock);
        Task Update(Stock stock);
        Task<Stock> FindByProductBarCodeAsync(string productId, int businessId);
    }
}
