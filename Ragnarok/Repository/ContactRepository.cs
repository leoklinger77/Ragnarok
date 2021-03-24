using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Linq;

namespace Ragnarok.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly RagnarokContext _context;

        public ContactRepository(RagnarokContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            try
            {
                Contact contact = FindById(id);
                _context.Contact.Remove(contact);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Contact FindById(int id)
        {
            try
            {
                return _context.Contact.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Insert(Contact contact)
        {
            try
            {
                _context.Contact.Add(contact);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Contact contact)
        {
            try
            {
                _context.Contact.Update(contact);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
