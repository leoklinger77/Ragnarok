using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Repository
{
    public class SaleBoxRepository : ISaleBoxRepository
    {
        private readonly RagnarokContext _context;

        public SaleBoxRepository(RagnarokContext context)
        {
            _context = context;
        }

        public async Task<SaleBox> FindByHasOpenBoxAsync(int employeeId)
        {
            try
            {
                return await _context.SaleBox.Where(x => x.RegisterSalesId == employeeId && x.Clouse == null).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task InsertAsync(SaleBox saleBox)
        {
            try
            {
                await _context.SaleBox.AddAsync(saleBox);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task UpdateAsync(SaleBox saleBox)
        {
            try
            {
                 _context.SaleBox.Update(saleBox);
                _context.Entry(saleBox).Property(x => x.Opening).IsModified = false;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
