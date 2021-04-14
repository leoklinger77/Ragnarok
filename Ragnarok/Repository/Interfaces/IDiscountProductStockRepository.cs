using Ragnarok.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface IDiscountProductStockRepository
    {
        Task InsertAsync(DiscountProductStock discountProductStock);
        Task UpdateRangeAsync(ICollection<DiscountProductStock> discountProductStock);
        Task RemoveAllsDiscountIdAsync(int discountStockId);
        Task<DiscountProductStock> FindByProdutDiscountAsync(int stockId);

    }
}
