using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Repository
{
    public class DiscountStock : IDiscountStock
    {
        private readonly RagnarokContext _context;

        public DiscountStock(RagnarokContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Models.DiscountStock>> FindAllsAsync(int businessId)
        {
            try
            {
                return await _context.DiscountStock
                    .Where(x => x.RegisterEmployee.BusinessId == businessId)
                    .Include(x => x.DiscountProductStock).ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task InsertAsync(Models.DiscountStock discountStock)
        {
            try
            {
                _context.DiscountStock.Add(discountStock);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
