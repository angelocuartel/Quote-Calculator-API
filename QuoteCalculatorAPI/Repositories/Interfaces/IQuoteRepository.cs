namespace QuoteCalculatorAPI.Repositories.Interfaces
{
    public interface IQuoteRepository<T> : IBaseRepository<T> where T : class
    {
        Task<string> CreateAndGetLatestHashedIdAsync(T model);

        Task<T> GetByHashedIdAsync(string hashId);
    }
}
