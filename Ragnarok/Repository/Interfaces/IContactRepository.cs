using Ragnarok.Models;

namespace Ragnarok.Repository.Interfaces
{
    public interface IContactRepository
    {
        void Insert(Contact contact);
        void Update(Contact contact);
        void Delete(int id);

        Contact FindById(int id);
    }
}
