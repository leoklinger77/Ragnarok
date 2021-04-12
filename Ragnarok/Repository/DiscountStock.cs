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
        public async Task<Models.DiscountStock> FindByAsync(int id, int businessId)
        {
            try
            {
                DiscountProductStock discount =  await _context.DiscountProductStock.Where(x => x.DiscountProductId == id && x.Stock.Product.RegisterEmployee.BusinessId == businessId).FirstOrDefaultAsync();

                if (discount != null )
                {
                    return await _context.DiscountStock.Where(x => x.Id == id)
                        .Include(x=>x.DiscountProductStock)
                        .FirstAsync();
                }
                //TODO Implementar Exception Personalizada
                throw new Exception("Id Not Found");
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
        public async Task UpdateAsync(Models.DiscountStock discountStock)
        {
            try
            {
                _context.DiscountStock.Update(discountStock);
                _context.Entry(discountStock).Property(x => x.InsertDate).IsModified = false;
                _context.Entry(discountStock).Property(x => x.RegisterEmployeeId).IsModified = false;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
