using Ragnarok.Data;
using Ragnarok.Models.ManyToMany;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class CategoryProductRepository : ICategoryProductRepository
    {
        private readonly RagnarokContext _context;

        public CategoryProductRepository(RagnarokContext ragnarokContext)
        {
            _context = ragnarokContext;
        }

        public ICollection<CategoryProduct> FindAllsProdut(int ProductId)
        {
            try
            {
                return _context.CategoryProduct.Where(x => x.ProductId == ProductId).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Insert(List<CategoryProduct> categoryProduct)
        {
            try
            {
                _context.CategoryProduct.AddRange(categoryProduct);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Remove(List<CategoryProduct> categoryProducts)
        {
            try
            {
                _context.CategoryProduct.RemoveRange(categoryProducts);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
