using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlashCards.Core.Abstractions;
using FlashCards.Core.Models;
using FlashCards.Core.Services.Storage.LocalDB.Models;

namespace FlashCards.Core.Services.Storage.LocalDB.Converters
{
    internal static class FlashCardSetConverters
    {
        public static IFlashCardSet ToServiceModel(this SqlFlashCardSet flashCardSet)
        {
            var set = new FlashCardSet()
                {
                    Id = flashCardSet.Id,
                    Name = flashCardSet.Name,
                    Description = flashCardSet.Description,
                    TermLanguageCode = flashCardSet.TermLanguageCode,
                    DefinitionLanguageCode = flashCardSet.DefinitionLanguageCode,
                    CreatedAt = flashCardSet.CreatedAt,
                    LastModifiedAt = flashCardSet.LastModifiedAt,
                    FlashCards = new ObservableCollection<IFlashCard>(flashCardSet.FlashCards.ToServiceModels()),
                };

            return set;
        }

        public static IEnumerable<IFlashCardSet> ToServiceModels(this ICollection<SqlFlashCardSet> flashCardSets)
        {
            var sets = new List<IFlashCardSet>();
            foreach (var flashCardSet in flashCardSets)
            {
                sets.Add(ToServiceModel(flashCardSet));
            }

            return sets;
        }

        public static SqlFlashCardSet ToSqlModel(this IFlashCardSet flashCardSet)
        {
            return new SqlFlashCardSet()
            {
                Id = flashCardSet.Id,
                Name = flashCardSet.Name,
                Description = flashCardSet.Description,
                TermLanguageCode = flashCardSet.TermLanguageCode,
                DefinitionLanguageCode = flashCardSet.DefinitionLanguageCode,
                CreatedAt = flashCardSet.CreatedAt,
                LastModifiedAt = flashCardSet.LastModifiedAt,
            };
        }
    }
}
