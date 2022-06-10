using BaesovClassificator.Contracts.Repository;

namespace BaesovClassificator.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly Lazy<IWordRepository> _lazyWordRepository;
        private readonly Lazy<IClassificationRepository> _lazyClassificationRepository;
        private readonly Lazy<IResultRepository> _lazyResultRepository;
        private readonly DataContext _context;

        public RepositoryManager(DataContext context)
        {
            this._context = context;
            _lazyWordRepository = new Lazy<IWordRepository>(() => new WordRepository(context));
            _lazyResultRepository = new Lazy<IResultRepository>(() => new ResultRepository(context));
            _lazyClassificationRepository = new Lazy<IClassificationRepository>(() => new ClassificationRepository(context));
        }

        public IWordRepository WordRepository => _lazyWordRepository.Value;

        public IClassificationRepository ClassificationRepository => _lazyClassificationRepository.Value;

        public IResultRepository ResultRepository => _lazyResultRepository.Value;

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}

