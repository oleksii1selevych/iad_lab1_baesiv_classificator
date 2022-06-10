using AutoMapper;
using BaesovClassificator.Contracts.Repository;
using BaesovClassificator.Contracts.Services;

namespace BaesovClassificator.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMessageService> _lazyMessageService;
        private readonly Lazy<IResultService> _lazyResultService;
        private readonly Lazy<IClassificationService> _lazyClassificationService;

        public ServiceManager(IRepositoryManager repository, IMapper mapper)
        {
            _lazyMessageService = new Lazy<IMessageService>(() => new MessageService(repository));
            _lazyResultService = new Lazy<IResultService>(() => new ResultService(repository));
            _lazyClassificationService = new Lazy<IClassificationService>(() => new ClassificationService(repository, mapper));
        }

        public IMessageService MessageService => _lazyMessageService.Value;
        public IResultService ResultService => _lazyResultService.Value;
        public IClassificationService ClassificationService => _lazyClassificationService.Value;
    }
}
