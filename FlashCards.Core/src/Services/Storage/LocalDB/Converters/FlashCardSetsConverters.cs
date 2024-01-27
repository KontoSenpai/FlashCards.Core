using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlashCards.Core.Abstractions;
using FlashCards.Core.src.Services.Storage.LocalDB;
using ServiceModel = FlashCards.Core.Models.FlashCardSetModel;

namespace FlashCards.Core.Services.Storage.LocalDB.Converters
{
    internal static class FlashCardSetConverters
    {
        public static IFlashCardSet ToServiceModel(this FlashCardSet flashCardSet)
        {
            var set = new ServiceModel()
                {
                    Id = flashCardSet.Id,
                    Name = flashCardSet.Name,
                    Description = flashCardSet.Description,
                    TermLanguageCode = flashCardSet.TermLanguageCode,
                    DefinitionLanguageCode = flashCardSet.DefinitionLanguageCode,
                    CreatedAt = flashCardSet.CreatedAt,
                    LastModifiedAt = flashCardSet.LastModifiedAt,
                    Owner = flashCardSet.Owner,
                    FlashCards = new ObservableCollection<IFlashCard>(flashCardSet.FlashCards.ToServiceModels()),
                };

            return set;
        }

        public static IEnumerable<IFlashCardSet> ToServiceModels(this ICollection<FlashCardSet> flashCardSets)
        {
            var sets = new List<IFlashCardSet>();
            foreach (var flashCardSet in flashCardSets)
            {
                sets.Add(ToServiceModel(flashCardSet));
            }

            return sets;
        }

        public static FlashCardSet ToSqlModel(this IFlashCardSet flashCardSet)
        {
            return new FlashCardSet()
            {
                Id = flashCardSet.Id,
                Name = flashCardSet.Name,
                Description = flashCardSet.Description,
                TermLanguageCode = flashCardSet.TermLanguageCode,
                DefinitionLanguageCode = flashCardSet.DefinitionLanguageCode,
                CreatedAt = flashCardSet.CreatedAt,
                LastModifiedAt = flashCardSet.LastModifiedAt,
                Owner = flashCardSet.Owner,
            };
        }
    }
}
