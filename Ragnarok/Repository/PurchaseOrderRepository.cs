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
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly RagnarokContext _context;

        public PurchaseOrderRepository(RagnarokContext context)
        {
            _context = context;
        }

        public ICollection<PurchaseOrder> FindAlls(int BusinessId)
        {
            try
            {
                return _context.PurchaseOrder.Where(x => x.RegisterEmployee.BusinessId == BusinessId).Include(x => x.PurchaseItemOrder).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public PurchaseOrder FindById(int id, int businessId)
        {
            try
            {
                return _context.PurchaseOrder.Where(x => x.Id == id && x.RegisterEmployee.BusinessId == businessId)
                    .Include(x => x.PurchaseItemOrder)
                    .FirstOrDefault();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Insert(PurchaseOrder order)
        {
            try
            {
                _context.PurchaseOrder.Add(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
