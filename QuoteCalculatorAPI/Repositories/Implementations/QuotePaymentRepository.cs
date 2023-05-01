using QuoteCalculatorAPI.Models;
using QuoteCalculatorAPI.Models.Data;
using QuoteCalculatorAPI.Repositories.Interfaces;

namespace QuoteCalculatorAPI.Repositories.Implementations
{
    public class QuotePaymentRepository : IQuotePaymentRepository<QuotePayment>
    {
        private readonly AppDbContext _context;

        public QuotePaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(QuotePayment payment)
        {
            await _context.QuotePayments.AddAsync(payment);

            await _context.SaveChangesAsync();
        }
    }
}
