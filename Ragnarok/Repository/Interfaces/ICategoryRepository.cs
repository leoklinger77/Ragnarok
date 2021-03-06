using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> FindAllsAsync(int businessId);
        Category FindById(int id, int businessId);
        void Insert(Category category);
        void Update(Category category);
        void Remove(int id, int businessId);

        ICollection<Category> FindByName(string name, int businessId);
        
    }
}
