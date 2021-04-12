using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface IDiscountStock
    {
        Task<ICollection<Models.DiscountStock>> FindAllsAsync(int businessId);
        Task InsertAsync(Models.DiscountStock discountStock);
        Task<Models.DiscountStock> FindByAsync(int id, int businessId);
        Task UpdateAsync(Models.DiscountStock discountStock);
    }
}
