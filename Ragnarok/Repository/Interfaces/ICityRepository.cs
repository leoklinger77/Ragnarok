using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface ICityRepository
    {
        void Insert(City city);
        void Update(City city);
        void Delete(int id);

        City FindById(int id);        
        ICollection<City> FindByName(string name);
        ICollection<City> FindAlls();
    }
}
