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
    public class StockRepository : IStockRepository
    {
        private readonly RagnarokContext _context;

        public StockRepository(RagnarokContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Stock>> FindAllsAsync(string search, DateTime startDate, DateTime endDate, int businessId)
        {
            try
            {

                if (string.IsNullOrEmpty(search))
                {
                    return await _context.Stock
                        .Include(x=>x.Product)
                        .Where(x => x.Product.RegisterEmployee.BusinessId == businessId
                        && (x.InsertDate >= startDate && x.InsertDate <= endDate))
                        .ToListAsync();
                }
                return await _context.Stock
                        .Include(x => x.Product)
                        .Where(x => x.Product.RegisterEmployee.BusinessId == businessId
                        && (x.InsertDate >= startDate && x.InsertDate <= endDate)
                        && (x.Product.Name.Contains(search.Trim()) || x.Product.BarCode.Contains(search.Trim())))
                        .ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<ICollection<Stock>> FindAllsAsync(int businessId)
        {
            try
            {
                return await _context.Stock
                    .Include(x => x.Product)
                    .Where(x=>x.Product.RegisterEmployee.BusinessId == businessId)
                    .ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message); ;
            }
        }

        public async Task<IPagedList<Stock>> FindAllsPagedListAsync(int? page, int? numberPerPage, string search, DateTime startDate, DateTime endDate, int businessId)
        {
            try
            {
                try
                {
                    int Page = page ?? 1;
                    int quantity = numberPerPage ?? 10;
                    if (string.IsNullOrEmpty(search))
                    {
                        return await _context.Stock.AsQueryable()
                            .Include(x => x.Product)
                            .Where(x => x.Product.RegisterEmployee.BusinessId == businessId 
                            && (x.InsertDate >= startDate && x.InsertDate <= endDate))
                            .ToPagedListAsync<Stock>((int)Page, quantity);
                    }
                    return await _context.Stock.AsQueryable()
                            .Include(x => x.Product)
                            .Where(x => x.Product.RegisterEmployee.BusinessId == businessId                             
                            && (x.InsertDate >= startDate && x.InsertDate <= endDate) 
                            && (x.Product.Name.Contains(search.Trim()) || x.Product.BarCode.Contains(search.Trim()) ))
                            .ToPagedListAsync<Stock>(Page, quantity);
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }               
        [Obsolete]
        public async Task<ICollection<Stock>> FindAllsProductsNotDiscount(int businessId)
        {
            try
            {
                string command = "select ST.id, ST.Quantity, ST.ValidationDate, ST.SalesPrice, ST.InsertDate, ST.UpdateDate, ST.ProductId" +
                                " from TB_Stock ST" +
                                " join TB_Product P on ST.ProductId = P.Id" +
                                " JOIN TB_Employee E on E.Id = P.RegisterEmployeeId" +
                                " where E.BusinessId = '" + businessId.ToString() +
                                "' AND ST.Id  not in (" +
                                                " select StockId " +
                                                        " from TB_DiscontStock D " +
                                                        " join TB_DiscountProduct DP on D.DiscountProductId = DP.Id" +
                                                        " JOIN TB_Employee E on E.Id = DP.RegisterEmployeeId" +
                                                " where DP.Active = 1" +
                                                " and E.BusinessId = '" + businessId.ToString() + "')";

                
                return await _context.Stock.FromSql(command).Include(x => x.Product).AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Stock> FindByIdAsync(int id, int businessId)
        {
            try
            {
                return await _context.Stock.Where(x => x.Id == id && x.Product.RegisterEmployee.BusinessId == businessId)
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<Stock> FindByProductBarCodeAsync(string productBarCode, int businessId)
        {
            try
            {
                return await _context.Stock.Where(x => x.Product.BarCode == productBarCode && x.Product.RegisterEmployee.BusinessId == businessId)
                    .Include(x=>x.Product)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task Insert(Stock stock)
        {
            try
            {
                _context.Stock.Add(stock);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task Update(Stock stock)
        {
            try
            {
                _context.Stock.Update(stock);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
