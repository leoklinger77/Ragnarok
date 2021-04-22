using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Ragnarok.Repository
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly RagnarokContext _context;

        public SalesOrderRepository(RagnarokContext context)
        {
            _context = context;
        }

        public async Task<IPagedList<SalesOrder>> FindAllsAsync(int? page, int? numberPerPage, string search, DateTime start, DateTime end, int businessId)
        {
            try
            {
                int Page = page ?? 1;
                int quantity = numberPerPage ?? 10;
                if (string.IsNullOrEmpty(search))
                {
                    return await _context.SalesOrder.AsQueryable()
                        .Include(x => x.SalesItem)
                        .Where(x => x.SaleBox.RegisterSales.BusinessId == businessId && x.InsertDate.Date >= start && x.InsertDate.Date <= end)
                        .OrderByDescending(x => x.InsertDate)
                        .ToPagedListAsync<SalesOrder>((int)Page, quantity);
                }
                return await _context.SalesOrder.AsQueryable()
                        .Include(x => x.SalesItem)
                        .Where(x => x.SaleBox.RegisterSales.BusinessId == businessId && x.InsertDate.Date >= start.Date && x.InsertDate.Date <= end.Date)
                        .OrderByDescending(x => x.InsertDate)
                        .ToPagedListAsync<SalesOrder>(Page, quantity);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ICollection<SalesOrder>> FindAllsAsync(string search, DateTime start, DateTime end, int businessId)
        {
            try
            {
                List<SalesOrder> list = await _context.SalesOrder
                    .Include(x => x.SalesItem)
                    .Include(x => x.Client)
                    .Include(x => x.Payment)
                    .Include(x => x.SaleBox.RegisterSales)
                    .Where(x => x.SaleBox.RegisterSales.BusinessId == businessId && x.InsertDate.Date >= start && x.InsertDate.Date <= end)
                    .OrderByDescending(x => x.InsertDate)
                    .ToListAsync();
                foreach (SalesOrder item in list)
                {
                    item.SalesItem = await _context.SalesItem.Include(x => x.Stock.Product).Where(x => x.SalesOrderId == item.Id).ToListAsync();
                }

                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Obsolete]
        public async Task<ICollection<SalesOrder>> FindAllsSevenDaysAsync(int businessId)
        {
            try
            {
                return await _context.SalesOrder
                    .Include(x => x.SalesItem)
                    .Include(x => x.Payment)
                    .Where(x => x.SaleBox.RegisterSales.BusinessId == businessId && x.InsertDate > DateTime.Now.Date.AddDays(-7))
                    .ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<SalesOrder> FindById(int id, int businessId)
        {
            try
            {
                return await _context.SalesOrder.FirstOrDefaultAsync(x => x.Id == id && x.SaleBox.RegisterSales.BusinessId == businessId);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task InsertAsync(SalesOrder salesOrder)
        {
            try
            {
                await _context.SalesOrder.AddAsync(salesOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<ICollection<SalesOrder>> LastTwoWeeksAsync(int businessId)
        {
            try
            {
                return await _context.SalesOrder
                    .Where(x => x.SaleBox.RegisterSales.BusinessId == businessId && x.InsertDate > DateTime.Now.Date.AddDays(-14))
                    .Include(x => x.SalesItem)
                    .Include(x => x.Payment)
                    .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> SoldAmount(DateTime date, int businessId)
        {
            try
            {
                return await _context.SalesOrder.Where(x => x.InsertDate.Date == date.Date).Select(x => x.SaleBox.RegisterSales.BusinessId == businessId).CountAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<ICollection<SalesOrder>> TopSeven(int businessId)
        {
            try
            {
                return await _context.SalesOrder
                    .Include(x => x.SalesItem)
                    .Include(x => x.Payment)
                    .OrderByDescending(x => x.Id).Take(7).ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<double> ValueSold(DateTime date, int businessId)
        {
            try
            {
                ICollection<SalesOrder> list = await _context.SalesOrder
                    .Where(x => x.InsertDate.Date == date.Date && x.SaleBox.RegisterSales.BusinessId == businessId)
                    .Include(x => x.SalesItem)
                    .AsNoTracking()
                    .ToListAsync();

                return list.Select(x => x.TotalSales()).Sum();


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

