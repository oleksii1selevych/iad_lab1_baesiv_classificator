using BaesovClassificator.Entities.Dtos;

namespace BaesovClassificator.Contracts.Services
{
    public interface IMessageService
    {
        Task AddMessageAsync(MessageDto messageDto);
        Task SetMessageClassification(MessageDto messageDto);
    }
}
