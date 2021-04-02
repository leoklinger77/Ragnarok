using Microsoft.EntityFrameworkCore;
using Ragnarok.Data;
using Ragnarok.Models;
using Ragnarok.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ragnarok.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly RagnarokContext _context;

        public ProductRepository(RagnarokContext context)
        {
            _context = context;
        }

        public ICollection<Product> FindAlls(int businessId)
        {
            try
            {
                return _context.Product.Where(x => x.RegisterEmployee.BusinessId == businessId)
                    .Include(x=>x.CategoryProduct)
                    .ToList();
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

        public ICollection<Product> FindByName(string name, int businessId)
        {
            try
            {
                return _context.Product.Where(x => x.Name == name && x.RegisterEmployee.BusinessId == businessId).AsNoTracking().ToList(); ;
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
    }
}
