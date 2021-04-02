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
    }
}
