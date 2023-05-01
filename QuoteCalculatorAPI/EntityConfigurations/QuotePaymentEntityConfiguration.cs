using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuoteCalculatorAPI.Models;

namespace QuoteCalculatorAPI.EntityConfigurations
{
    public class QuotePaymentEntityConfiguration : IEntityTypeConfiguration<QuotePayment>
    {
        public void Configure(EntityTypeBuilder<QuotePayment> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.MonthlyPayments).HasPrecision(18, 2);
            builder.Property(i => i.EstablishmentFee).HasPrecision(18, 2);
            builder.Property(i => i.TotalRepayments).HasPrecision(18, 2);
            builder.Property(i => i.InterestFee).HasPrecision(18, 2);

            builder.HasOne(i => i.QuoteInformation)
                .WithOne(i => i.QuotePayment)
                .HasForeignKey<QuotePayment>(i => i.QuoteInformationId);

        }
    }
}
