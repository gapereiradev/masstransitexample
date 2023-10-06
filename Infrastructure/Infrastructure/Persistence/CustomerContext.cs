using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class CustomerContext : DbContext
    {
        public DbSet<TbCustomer> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }
    }
}