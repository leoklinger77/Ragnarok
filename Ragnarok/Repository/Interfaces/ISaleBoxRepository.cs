using Ragnarok.Models;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface ISaleBoxRepository
    {
        Task<SaleBox> FindByHasOpenBoxAsync(int employeeId);
        Task InsertAsync(SaleBox saleBox);
        Task UpdateAsync(SaleBox saleBox);
    }
}
