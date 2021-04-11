using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Models.ManyToMany;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly RagnarokContext _context;

        public StockRepository(RagnarokContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Stock>> FindAllsAsync(int businessId)
        {
            try
            {
                return await _context.Stock.Where(x => x.Product.RegisterEmployee.BusinessId == businessId)
                    .Include(x => x.Product)
                    .ToListAsync();
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
                string command = "select ST.id, ST.Quantity,ST.ValidationDate,ST.SalesPrice,ST.InsertDate,ST.UpdateDate,ST.ProductId" +
                                                                        " from TB_Stock ST" +
                                                                         " join TB_Product P on ST.ProductId = P.Id" +
                                                                        " JOIN TB_Employee E on E.Id = P.RegisterEmployeeId" +
                                                                        " where E.BusinessId = '" + businessId.ToString() +
                                                                        "' AND ST.Id  not in (" +
                                                                                        " select StockId " +
                                                                                                " from TB_DiscontStock D " +
                                                                                                " join TB_DiscountProduct DP on D.DiscountProductId = DP.Id" +
                                                                                                " join TB_Stock ST on D.StockId = ST.Id" +
                                                                                                " join TB_Product P on ST.ProductId = P.Id" +
                                                                                                " JOIN TB_Employee E on E.Id = P.RegisterEmployeeId" +
                                                                                        " where DP.Active = 1" +
                                                                                        " and E.BusinessId = '" + businessId.ToString() + "')";

                ICollection<Stock> st = await _context.Stock.FromSql(command).Include(x=>x.Product).ToListAsync();
                return st;
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

        public void Insert(Stock stock)
        {
            try
            {
                _context.Stock.Add(stock);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Update(Stock stock)
        {
            try
            {
                _context.Stock.Update(stock);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
