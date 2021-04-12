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
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly RagnarokContext _context;

        public SalesOrderRepository(RagnarokContext context)
        {
            _context = context;
        }

        public async Task<ICollection<SalesOrder>> FindAllsAsync(int businessId)
        {
            try
            {
                return await _context.SalesOrder.Where(x => x.SaleBox.RegisterSales.BusinessId == businessId).ToListAsync();
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
    }
}
