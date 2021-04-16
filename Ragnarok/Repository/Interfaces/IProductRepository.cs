using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Ragnarok.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> FindAllsAsync(int businessId);
        Task<IPagedList<Product>> FindAllsPagedListAsync(int? page, string search, int? numberPerPage, int businessId);
        Product FindById(int id, int businessId);
        void Insert(Product product);
        void Update(Product product);
        void Remove(int id, int businessId);
        ICollection<Product> FindByBarCode(string barCode, int businessId);
        Task<ICollection<Product>> FindNameOrCodeProdut(string search, int businessId);
    }
}
