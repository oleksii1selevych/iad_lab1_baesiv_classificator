using AutoMapper;
using BaesovClassificator.Contracts.Repository;
using BaesovClassificator.Contracts.Services;
using BaesovClassificator.Entities.Dtos;

namespace BaesovClassificator.Services
{
    public class ClassificationService : IClassificationService
    {
        private readonly IRepositoryManager repository;
        private readonly IMapper mapper;

        public ClassificationService(IRepositoryManager repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;   
        }

        public async Task<IEnumerable<ClassificationDto>> GetAllClassificationsAsync()
            => mapper.Map<IEnumerable<ClassificationDto>>(await repository.ClassificationRepository.GetAllClassificationsAsync());
    }
}
