using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Ragnarok.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly RagnarokContext _context;

        public ProductRepository(RagnarokContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> FindAllsAsync(int businessId)
        {
            try
            {
                return await _context.Product.Where(x => x.RegisterEmployee.BusinessId == businessId)
                    .Include(x => x.CategoryProduct)
                    .ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Product FindById(int id, int businessId)
        {
            try
            {
                return _context.Product.Include(x => x.CategoryProduct).FirstOrDefault(x => x.Id == id && x.RegisterEmployee.BusinessId == businessId);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public ICollection<Product> FindByBarCode(string barCode, int businessId)
        {
            try
            {
                return _context.Product.Where(x => x.BarCode == barCode && x.RegisterEmployee.BusinessId == businessId).AsNoTracking().ToList(); ;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Insert(Product product)
        {
            try
            {
                _context.Product.Add(product);
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
                Product product = FindById(id, businessId);
                _context.CategoryProduct.RemoveRange(product.CategoryProduct);
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Update(Product product)
        {
            try
            {
                _context.Product.Update(product);
                _context.Entry(product).Property(x => x.InsertDate).IsModified = false;
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<IPagedList<Product>> FindAllsPagedListAsync(int? page, string search, int? numberPerPage, int businessId)
        {
            try
            {
                int Page = page ?? 1;
                int quantity = numberPerPage ?? 10;
                if (string.IsNullOrEmpty(search))
                {
                    return await _context.Product.AsQueryable().Where(x => x.RegisterEmployee.BusinessId == businessId).ToPagedListAsync<Product>((int)Page, quantity);
                }
                return await _context.Product.AsQueryable()
                        .Where(x => x.RegisterEmployee.BusinessId == businessId && (x.Name.Contains(search.Trim()) || x.BarCode.Contains(search.Trim())))
                        .ToPagedListAsync<Product>(Page, quantity);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<ICollection<Product>> FindNameOrCodeProdut(string search, int businessId)
        {
            try
            {
                return await _context.Product.Where(x => x.RegisterEmployee.BusinessId == businessId && (x.Name.Contains(search.Trim()) || x.BarCode.Contains(search.Trim()))).ToListAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
