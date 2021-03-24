using Ragnarok.Models;
using System.Collections.Generic;

namespace Ragnarok.Repository.Interfaces
{
    public interface IBusinessRepository
    {
        void Insert(Business business);
        void Update(Business business);
        void Delete(int id);
        Business FindById(int id);
        ICollection<Business> FindAlls();
        ICollection<Business> FindAllsEmals(string email);
        ICollection<BusinessPhysical> FindAllsCpf(string cpf);
        ICollection<BusinessJuridical> FindAllsCpnj(string cnpj);
    }
}
