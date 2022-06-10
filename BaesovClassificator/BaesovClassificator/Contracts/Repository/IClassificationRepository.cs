using BaesovClassificator.Entities.Domain;

namespace BaesovClassificator.Contracts.Repository
{
    public interface IClassificationRepository
    {
        Task<IEnumerable<Classification>> GetAllClassificationsAsync();
        void UpdateClassification(Classification classification);
        Task<Classification?> GetClassificationByIdAsync(int? classificationId);
        Task<int> GetTotalMessagesCountAsync();

    }
}

/*
 GetById --> для того чтобы получить саму классификацию для обновления по переданному Idшнику из MessageDto
 
 
 */