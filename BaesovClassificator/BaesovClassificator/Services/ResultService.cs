using BaesovClassificator.Contracts.Repository;
using BaesovClassificator.Contracts.Services;
using BaesovClassificator.Entities.Domain;
using BaesovClassificator.Entities.Dtos;

namespace BaesovClassificator.Services
{
    public class ResultService : IResultService
    {
        private readonly IRepositoryManager repository;
        public ResultService(IRepositoryManager repository) => this.repository = repository; 

        public async Task AddResult(bool result)
        {
            var totalCount = await repository.ClassificationRepository.GetTotalMessagesCountAsync();
            Result guessResult = new Result { Correct = result, TotalMessageCount = totalCount };
            repository.ResultRepository.CreateResult(guessResult);
            await repository.SaveAsync();
        }
        public async Task<IEnumerable<CorrectResultPercentageDto>> GetCorrectResultsPercentagesAsync()
        {
            List<CorrectResultPercentageDto> results = new List<CorrectResultPercentageDto>();
            IEnumerable<int> availiblleQuantities = await repository.ResultRepository.GetDistinctQuantitiesAsync();

            foreach(var quantity in availiblleQuantities)
            {
                int correctAnswers = await repository.ResultRepository.CorrectResultsPerQuantityAsync(quantity);
                int totalAnswersNumber = await repository.ResultRepository.TotalNumberOfResultsPerQuantity(quantity);

                double correctPercentage = (Convert.ToDouble(correctAnswers) / Convert.ToDouble(totalAnswersNumber)) * 100;

                results.Add(new CorrectResultPercentageDto { Quantity = quantity, Percentage = correctPercentage });
            }
            return results.OrderBy(r => r.Quantity);
        }
    }
}
