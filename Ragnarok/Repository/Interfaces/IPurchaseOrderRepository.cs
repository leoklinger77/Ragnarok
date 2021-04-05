using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        ICollection<PurchaseOrder> FindAlls(int BusinessId);
        PurchaseOrder FindById(int id, int businessId);
        void Insert(PurchaseOrder order);
        void Remove(int id, int BusinessId);
        
    }
}
