using AutoMapper;
using BaesovClassificator.Contracts.Mapping;
using BaesovClassificator.Entities.Domain;

namespace BaesovClassificator.Entities.Dtos
{
    public class ClassificationDto : IMapFrom<Classification>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public void Mapping(Profile profile) => profile.CreateMap<Classification, ClassificationDto>().ForMember(c => c.Name, act => act.MapFrom(src => src.ClassificationName));

    }
}
