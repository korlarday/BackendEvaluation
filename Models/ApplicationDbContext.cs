using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Evaluation.Models
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(): base()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
