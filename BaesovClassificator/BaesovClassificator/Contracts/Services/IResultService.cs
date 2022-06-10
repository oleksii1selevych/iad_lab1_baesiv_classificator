using BaesovClassificator.Entities.Domain;
using BaesovClassificator.Entities.Dtos;

namespace BaesovClassificator.Contracts.Services
{
    public interface IResultService
    {
        Task AddResult(bool result);
        Task<IEnumerable<CorrectResultPercentageDto>> GetCorrectResultsPercentagesAsync();
    }
}
