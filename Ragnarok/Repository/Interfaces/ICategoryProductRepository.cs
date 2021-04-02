using Ragnarok.Models.ManyToMany;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface ICategoryProductRepository
    {
        void Insert(List<CategoryProduct> categoryProduct);
        ICollection<CategoryProduct> FindAllsProdut(int ProductId);
        void Remove(List<CategoryProduct> categoryProducts);
    }
}
