using Ragnarok.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Ragnarok.Repository.Interfaces
{
    public interface ISalesOrderRepository
    {
        Task<IPagedList<SalesOrder>> FindAllsAsync(int? page, int? numberPerPage, string search, DateTime start, DateTime end, int businessId);
        Task<ICollection<SalesOrder>> FindAllsAsync(string search, DateTime start, DateTime end, int businessId);
        Task InsertAsync(SalesOrder salesOrder);
        Task<SalesOrder> FindById(int id, int businessId);
        Task<ICollection<SalesOrder>> TopSeven(int businessId);
        Task<ICollection<SalesOrder>> FindAllsSevenDaysAsync(int businessId);
        Task<ICollection<SalesOrder>> LastTwoWeeksAsync(int businessId);
        Task<int> SoldAmount(DateTime date, int businessId);
        Task<double> ValueSold(DateTime date, int businessId);
    }
}
