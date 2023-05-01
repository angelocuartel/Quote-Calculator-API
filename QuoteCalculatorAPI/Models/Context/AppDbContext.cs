using Microsoft.EntityFrameworkCore;
using QuoteCalculatorAPI.EntityConfigurations;
using System.Data;

namespace QuoteCalculatorAPI.Models.Data
{
    public class AppDbContext:  DbContext
    {
        public DbSet<QuoteInformation> QuoteInformations { get; set; }
        public DbSet<QuotePayment> QuotePayments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new QuoteInformationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new QuotePaymentEntityConfiguration());
        }
    }
}
