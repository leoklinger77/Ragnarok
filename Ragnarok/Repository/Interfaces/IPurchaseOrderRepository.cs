using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<ICollection<PurchaseOrder>> FindAllsAsync(int BusinessId);
        PurchaseOrder FindById(int id, int businessId);
        void Insert(PurchaseOrder order);
        void Remove(int id, int BusinessId);
        
    }
}
