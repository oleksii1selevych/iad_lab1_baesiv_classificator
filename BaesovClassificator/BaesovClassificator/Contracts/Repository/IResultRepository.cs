using BaesovClassificator.Entities.Domain;

namespace BaesovClassificator.Contracts.Repository
{
    public interface IResultRepository
    {
        Task<IEnumerable<Result>> GetAllResultsAsync();
        void CreateResult(Result result);
        Task<int> CorrectResultsPerQuantityAsync(int quantity);
        Task<int> TotalNumberOfResultsPerQuantity(int quantity);
        Task<IEnumerable<int>> GetDistinctQuantitiesAsync();
    }
}
