using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using crm.Models;

namespace crm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<crm.Models.Customer>? Customer { get; set; }
        public DbSet<crm.Models.Company>? Company { get; set; }
        public DbSet<crm.Models.Product>? Product { get; set; }
        public DbSet<crm.Models.Complaints>? Complaints { get; set; }
        public DbSet<crm.Models.Orders>? Orders { get; set; }
        public DbSet<crm.Models.OrderDetails>? OrderDetails { get; set; }
    }
}