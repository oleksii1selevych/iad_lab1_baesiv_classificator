namespace BaesovClassificator.Contracts.Services
{
    public interface IServiceManager
    {
        IMessageService MessageService { get; }
        IResultService ResultService { get; }
        IClassificationService ClassificationService { get; }
    }
}
