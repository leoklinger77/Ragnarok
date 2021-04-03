using Microsoft.EntityFrameworkCore;
using Ragnarok.Models;
using Ragnarok.Models.ManyToMany;

namespace Ragnarok.Data
{
    public class RagnarokContext : DbContext
    {
        public RagnarokContext(DbContextOptions<RagnarokContext> options) : base(options)
        {
        }
        public DbSet<Business> Business { get; set; }
        public DbSet<BusinessJuridical> BusinessJuridical { get; set; }
        public DbSet<BusinessPhysical> BusinessPhysicals { get; set; }

        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; set; }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<PositionName> PositionName { get; set; }

        public DbSet<Client> Client { get; set; }
        public DbSet<ClientJuridical> ClientJuridical { get; set; }
        public DbSet<ClientPhysical> ClientPhysical { get; set; }

        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<SupplierJuridical> SupplierJuridical { get; set; }
        public DbSet<SupplierPhysical> SupplierPhysical { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseItemOrder> PurchaseItemOrder { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasKey(x => new { x.CategoryId, x.ProductId });
            modelBuilder.Entity<CategoryProduct>()
                .HasOne(x => x.Category)
                .WithMany(x => x.CategoryProduct)
                .HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<CategoryProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.CategoryProduct)
                .HasForeignKey(x => x.ProductId);



            modelBuilder.Entity<PurchaseItemOrder>()
    .HasKey(x => new { x.ProductId, x.PurchaseOrderId });
            modelBuilder.Entity<PurchaseItemOrder>()
                .HasOne(x => x.PurchaseOrder)
                .WithMany(x => x.PurchaseItemOrder)
                .HasForeignKey(x => x.PurchaseOrderId);
            modelBuilder.Entity<PurchaseItemOrder>()
                .HasOne(x => x.Product)
                .WithMany(x => x.PurchaseItemOrder)
                .HasForeignKey(x => x.ProductId);

        }
    }
}
