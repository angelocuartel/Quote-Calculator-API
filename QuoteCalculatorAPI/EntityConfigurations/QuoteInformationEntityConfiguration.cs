using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuoteCalculatorAPI.Models;

namespace QuoteCalculatorAPI.EntityConfigurations
{
    public class QuoteInformationEntityConfiguration : IEntityTypeConfiguration<QuoteInformation>
    {
        public void Configure(EntityTypeBuilder<QuoteInformation> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.AmountRequired).HasPrecision(18, 2);
        }
    }
}
