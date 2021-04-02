using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ragnarok.Models.ManyToMany
{
    [Table("TB_CategoryProduct")]
    public class CategoryProduct
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public CategoryProduct()
        {
        }

        public CategoryProduct(Category category, Product product)
        {
            Category = category;
            Product = product;
        }


    }
}
