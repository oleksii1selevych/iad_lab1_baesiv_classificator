using BaesovClassificator.Contracts.Repository;
using BaesovClassificator.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaesovClassificator.Data.Repository
{
    public class WordRepository : RepositoryBase<WordDescription>, IWordRepository
    {
        public WordRepository(DataContext context) : base(context)
        {
        }

        public void CreateWord(WordDescription word)
            => Create(word);

        public async Task<IEnumerable<WordDescription>> GetAllWordsAsync()
            => await FindAll().OrderBy(w => w.Word).ToListAsync();

        public async Task<int> GetCountByWordAsync(string word)
            => await FindByCondition(w => w.Word == word).CountAsync();

        public async Task<int> GetWordCountByClassicationAsync(int classificationId, string word)
            => await FindByCondition(w => w.ClassificationId.Equals(classificationId) && w.Word == word).CountAsync();
    }
}
