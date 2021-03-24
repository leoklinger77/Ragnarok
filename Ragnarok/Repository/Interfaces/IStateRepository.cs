using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IStateRepository
    {
        void Insert(State state);
        void Update(State state);
        void Delete(int id);

        State FindById(int id);
        ICollection<State> FindBySigle(string sigla);
        ICollection<State> FindByName(string name);

        ICollection<State> FindAlls();
    }
}
