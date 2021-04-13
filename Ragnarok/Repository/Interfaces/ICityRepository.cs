using Ragnarok.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ragnarok.Repository.Interfaces
{
    public interface ICityRepository
    {
        void Insert(City city);
        void Update(City city);
        Task DeleteAsync(int id);

        Task<City> FindByIdAsync(int id);        
        ICollection<City> FindByName(string name);
        City FindByNameAndState(string name, string stateSigle);
        ICollection<City> FindAlls();
    }
}
