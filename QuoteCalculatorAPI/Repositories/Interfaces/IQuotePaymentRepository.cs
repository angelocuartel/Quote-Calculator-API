namespace QuoteCalculatorAPI.Repositories.Interfaces
{
    public interface IQuotePaymentRepository<T> where T:class
    {
        Task CreateAsync(T payment);
    }
}
