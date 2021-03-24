using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IAddressRepository
    {
        void Insert(Address address);
        void Update(Address address);
        void Delete(int id);

        Address FindById(int id);        
        ICollection<Address> FindAlls();
    }
}
