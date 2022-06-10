using BaesovClassificator.Entities.Domain;

namespace BaesovClassificator.Contracts.Repository
{
    public interface IWordRepository
    {
        Task<IEnumerable<WordDescription>> GetAllWordsAsync();
        void CreateWord(WordDescription word);

        Task<int> GetCountByWordAsync(string word);
        Task<int> GetWordCountByClassicationAsync(int classificationId, string word);
    }
}
