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

        public async Task<ICollection<Category>> FindAllsAsync(int businessId)
        {
            try
            {
                return await _context.Category.Where(x => x.RegisterEmployee.BusinessId == businessId).ToListAsync();
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
            try
            {
                _context.Category.Add(category);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Remove(int id, int businessId)
        {
            try
            {
                Category category = FindById(id, businessId);
                _context.Category.Remove(category);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Update(Category category)
        {
            try
            {
                _context.Category.Update(category);
                _context.Entry(category).Property(x => x.InsertDate).IsModified = false;
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
