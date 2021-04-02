using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ragnarok.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RagnarokContext _context;

        public CategoryRepository(RagnarokContext ragnarokContext)
        {
            _context = ragnarokContext;
        }

        public ICollection<Category> FindAlls(int businessId)
        {
            try
            {
                return _context.Category.Where(x => x.RegisterEmployee.BusinessId == businessId).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Category FindById(int id, int businessId)
        {
            try
            {
                return _context.Category.FirstOrDefault(x => x.Id == id && x.RegisterEmployee.BusinessId == businessId);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ICollection<Category> FindByName(string name, int businessId)
        {
            try
            {
                return _context.Category.Where(x => x.Name == name && x.RegisterEmployee.BusinessId == businessId).AsNoTracking().ToList(); ;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
