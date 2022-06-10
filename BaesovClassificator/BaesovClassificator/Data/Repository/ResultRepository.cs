using BaesovClassificator.Contracts.Repository;
using BaesovClassificator.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaesovClassificator.Data.Repository
{
    public class ResultRepository : RepositoryBase<Result>, IResultRepository
    {
        public ResultRepository(DataContext context) : base(context)
        {
        }

        public async Task<int> CorrectResultsPerQuantityAsync(int quantity)
            => await FindByCondition(r => r.Correct == true && r.TotalMessageCount == quantity).CountAsync();

        public void CreateResult(Result result)
            => Create(result);

        public async Task<IEnumerable<Result>> GetAllResultsAsync()
            => await FindAll().OrderBy(r => r.TotalMessageCount).ToListAsync();

        public async Task<IEnumerable<int>> GetDistinctQuantitiesAsync()
            => await FindAll().Select(r => r.TotalMessageCount).Distinct().ToListAsync();

        public async Task<int> TotalNumberOfResultsPerQuantity(int quantity)
            => await FindByCondition(r => r.TotalMessageCount == quantity).CountAsync();
    }
}
