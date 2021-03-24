using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IPositionNameRepository
    {
        void Insert(PositionName positionName);
        void Update(PositionName positionName);
        void Remove(int id);

        PositionName FindById(int id);

        ICollection<PositionName> FindAlls(int businessId);

    }
}
