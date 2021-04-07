using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
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

        public async Task<Stock> FindByIdAsync(int id, int businessId)
        {
            try
            {
                return await _context.Stock.Where(x => x.Id == id && x.Product.RegisterEmployee.BusinessId == businessId).FirstOrDefaultAsync();
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
