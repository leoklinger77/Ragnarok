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
                return _context.PurchaseOrder.Where(x => x.RegisterEmployee.BusinessId == BusinessId).Include(x => x.PurchaseItemOrder).Include(x=>x.Supplier).ToList();
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
                PurchaseOrder order = _context.PurchaseOrder
                    .Include(x=>x.Supplier.Address.City.State)
                    .Include(x=>x.Supplier.Contacts)
                    .Include(x => x.PurchaseItemOrder)
                    .FirstOrDefault(x => x.Id == id && x.RegisterEmployee.BusinessId == businessId);

                foreach (var item in order.PurchaseItemOrder)
                {
                    item.Product = _context.Product.AsNoTracking().First(x => x.Id == item.ProductId);
                }
                return order;

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

        public void Remove(int id, int BusinessId)
        {
            try
            {
                PurchaseOrder order = FindById(id, BusinessId);
                _context.PurchaseOrder.Remove(order);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
