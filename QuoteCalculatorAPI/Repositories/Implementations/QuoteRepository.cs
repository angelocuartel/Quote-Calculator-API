
using QuoteCalculatorAPI.Repositories.Interfaces;
using QuoteCalculatorAPI.Models;
using QuoteCalculatorAPI.Models.Data;
using ExpenseComputerAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace QuoteCalculatorAPI.Repositories.Implementations
{
    public class QuoteRepository : IQuoteRepository<QuoteInformation>
    {
        private readonly AppDbContext _dbContext;

        public QuoteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> CreateAndGetLatestHashedIdAsync(QuoteInformation model)
        {
            await CreateAsync(model);

            model.HashedId = HashUtil.ComputeToSha256(model.Id.ToString());

            await UpdateAsync(model);

            return model.HashedId;
        }

        public async Task CreateAsync(QuoteInformation entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<QuoteInformation> GetByHashedIdAsync(string hashId)
            => await _dbContext.QuoteInformations.AsNoTracking()
            .Where(i => i.HashedId == hashId)
            .FirstOrDefaultAsync();
        

        public async Task<QuoteInformation> GetByIdAsync(int id)
        => await _dbContext.QuoteInformations.FindAsync(id);

        public async Task UpdateAsync(QuoteInformation entity)
        {
            QuoteInformation quoteInfo = await _dbContext.QuoteInformations.FindAsync(entity.Id);
            quoteInfo.DateOfBirth = entity.DateOfBirth;
            quoteInfo.FirstName = entity.FirstName;
            quoteInfo.LastName = entity.LastName;
            quoteInfo.Term = entity.Term;
            quoteInfo.AmountRequired = entity.AmountRequired;
            quoteInfo.MobileNo = entity.MobileNo;
            quoteInfo.Email= entity.Email;

            _dbContext.QuoteInformations.Update(quoteInfo);

            await _dbContext.SaveChangesAsync();
        }
    }
}
