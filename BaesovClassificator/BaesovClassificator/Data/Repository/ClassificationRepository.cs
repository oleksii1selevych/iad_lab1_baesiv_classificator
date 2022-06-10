using BaesovClassificator.Contracts.Repository;
using BaesovClassificator.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaesovClassificator.Data.Repository
{
    public class ClassificationRepository : RepositoryBase<Classification>, IClassificationRepository
    {
        public ClassificationRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Classification>> GetAllClassificationsAsync()
            => await FindAll().OrderBy(c => c.ClassificationName).ToListAsync();

        public async Task<Classification?> GetClassificationByIdAsync(int? classificationId)
            => await FindByCondition(c => c.Id.Equals(classificationId)).FirstOrDefaultAsync();

        public async Task<int> GetTotalMessagesCountAsync()
            => await FindAll().Select(c => c.MessagesCount).SumAsync();

        public void UpdateClassification(Classification classification)
            => Update(classification);
    }
}
