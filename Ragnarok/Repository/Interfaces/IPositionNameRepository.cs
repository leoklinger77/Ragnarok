using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface IPositionNameRepository
    {
        void Insert(PositionName positionName);
        void Update(PositionName positionName);
        void Remove(int id);

        PositionName FindById(int id);

        Task<ICollection<PositionName>> FindAllsAsync(int businessId);

    }
}
