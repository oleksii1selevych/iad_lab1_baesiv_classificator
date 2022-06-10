using BaesovClassificator.Contracts.Repository;
using BaesovClassificator.Contracts.Services;
using BaesovClassificator.Entities.Domain;
using BaesovClassificator.Entities.Dtos;
using System.Text.RegularExpressions;

namespace BaesovClassificator.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepositoryManager repository;

        public MessageService(IRepositoryManager repository) => this.repository = repository;

        public async Task AddMessageAsync(MessageDto messageDto)
        {
            string lowercasedMessage = messageDto.Message.ToLower();
            string[] words = Regex.Replace(lowercasedMessage, "[?()!,:-><]*", "").Split(' ');

            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word) && !string.IsNullOrEmpty(word))
                {
                    WordDescription wordDescription = new WordDescription { Word = word, ClassificationId = messageDto.ClassificationId };
                    repository.WordRepository.CreateWord(wordDescription);
                }
            }

            Classification classification = await repository.ClassificationRepository.GetClassificationByIdAsync(messageDto.ClassificationId) ?? null!;
            classification.MessagesCount += 1;
            repository.ClassificationRepository.UpdateClassification(classification);

            await repository.SaveAsync();
        }

        public async Task SetMessageClassification(MessageDto messageDto)
        {
            string lowercasedMessage = messageDto.Message.ToLower();
            string[] words = Regex.Replace(lowercasedMessage, "[?()!,:-><]*", "").Split(' ');
            IEnumerable<Classification> classifications = await repository.ClassificationRepository.GetAllClassificationsAsync();

            Classification resultClassification = null;
            double biggestProbability = 0;

            foreach (var classification in classifications)
            {
                double classificationProbability = await GetClassificationProbability(classification, words);
                if (classificationProbability > biggestProbability)
                {
                    biggestProbability = classificationProbability;
                    resultClassification = classification;
                }
            }
            messageDto.ClassificationId = resultClassification != null ? resultClassification.Id : 0;
        }

        private async Task<double> GetClassificationProbability(Classification classification, string[] words)
        {
            int totalMessagesCount = await repository.ClassificationRepository.GetTotalMessagesCountAsync();

            double classificationProbability = Convert.ToDouble(classification.MessagesCount) / Convert.ToDouble(totalMessagesCount);
            double result = classificationProbability;

            foreach (var word in words)
                if (!string.IsNullOrWhiteSpace(word) && !string.IsNullOrEmpty(word))
                    result *= await GetWordNormalizedProbability(word, classificationProbability, classification.Id);

            return result;
        }

        private async Task<double> GetWordNormalizedProbability(string word, double classificationProbability, int classificationId)
        {
            int totalWordQuantity = await repository.WordRepository.GetCountByWordAsync(word);
            if (totalWordQuantity == 0)
                return classificationProbability;

            int wordClassificationQuantity = await repository.WordRepository.GetWordCountByClassicationAsync(classificationId, word);

            double numerator = totalWordQuantity * (Convert.ToDouble(wordClassificationQuantity) / Convert.ToDouble(totalWordQuantity)) + classificationProbability;
            double denominator = totalWordQuantity + 1;

            return Convert.ToDouble(numerator) / Convert.ToDouble(denominator);
        }
    }
}

