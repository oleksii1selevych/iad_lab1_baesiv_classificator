namespace BaesovClassificator.Contracts.Repository
{
    public interface IRepositoryManager
    {
        IWordRepository WordRepository { get; }
        IClassificationRepository ClassificationRepository { get; }
        IResultRepository ResultRepository { get; }
        Task SaveAsync();
    }
}


/*
 1) Получить сообщение
 2) Добавить новые слова
 
 
 
 
 
 */