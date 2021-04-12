using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models.ManyToMany;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Repository
{
    public class DiscountProductStockRepository : IDiscountProductStockRepository
    {
        private readonly RagnarokContext _context;

        public DiscountProductStockRepository(RagnarokContext ragnarokContext)
        {
            _context = ragnarokContext;
        }

        public async Task InsertAsync(DiscountProductStock discountProductStock)
        {
            try
            {
                _context.DiscountProductStock.Add(discountProductStock);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task RemoveAllsDiscountIdAsync(int discountStockId)
        {
            try
            {
                _context.DiscountProductStock.RemoveRange(await _context.DiscountProductStock.Where(x=>x.DiscountProductId == discountStockId).AsNoTracking().ToListAsync());
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task UpdateRangeAsync(ICollection<DiscountProductStock> discountProductStock)
        {
            try
            {
                _context.DiscountProductStock.UpdateRange(discountProductStock);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
