using Microsoft.EntityFrameworkCore;
using Ragnarok.Models;

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
    }
}
