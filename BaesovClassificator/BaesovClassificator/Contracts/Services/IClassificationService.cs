using BaesovClassificator.Entities.Dtos;

namespace BaesovClassificator.Contracts.Services
{
    public interface IClassificationService
    {
        Task<IEnumerable<ClassificationDto>> GetAllClassificationsAsync();
    }
}
