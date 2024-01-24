using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FlashCards.Core.Abstractions;
using FlashCards.Core.Models;
using FlashCards.Core.Services.Storage.Sql.Models;

namespace FlashCards.Core.Services.Storage.Sql.Converters
{
    public static class FlashCardConverters
    {
        public static FlashCardSet ConvertSqlFlashCardSetToFlashCardSetModel(SqlFlashCardSet flashCardSet)
        {
            var newR = new FlashCardSet()
                {
                    Id = flashCardSet.Id,
                    Name = flashCardSet.Name,
                    Description = flashCardSet.Description,
                    TermLanguageCode = flashCardSet.TermLanguageCode,
                    DefinitionLanguageCode = flashCardSet.DefinitionLanguageCode,
                    FlashCards = new ExpandedObservableCollection<IFlashCard>(),
                };

                ExpandedObservableCollection<IFlashCard> cards = new ExpandedObservableCollection<IFlashCard>();
                foreach (var flashCard in flashCardSet.FlashCards)
                {
                    cards.Add(ConvertSqlFlashCardToFlashCardModel(flashCard));
                }

                newR.FlashCards = cards;

            return newR;
        }

        public static List<FlashCardSet> ConvertSqlFlashCardSetsToFlashCardSetModels(List<SqlFlashCardSet> flashCardSets)
        {
            var r = new List<FlashCardSet>();
            foreach (var flashCardSet in flashCardSets)
            {
                r.Add(ConvertSqlFlashCardSetToFlashCardSetModel(flashCardSet));
            }

            return r;
        }

        public static SqlFlashCardSet ConvertFlashCardSetModelToSqlFlashCardSet(IFlashCardSet flashCardSet)
        {
            return new SqlFlashCardSet()
            {
                Id = flashCardSet.Id,
                Name = flashCardSet.Name,
                Description = flashCardSet.Description,
                TermLanguageCode = flashCardSet.TermLanguageCode,
                DefinitionLanguageCode = flashCardSet.DefinitionLanguageCode,
            };
        }

        public static IFlashCard ConvertSqlFlashCardToFlashCardModel(SqlFlashCard flashCard)
        {
            return new FlashCard()
            {
                Id = flashCard.Id,
                Definition = flashCard.Definition,
                Term = flashCard.Term,
                FlashCardSetId = flashCard.FlashCardSetId,
            };
        }
        
        public static SqlFlashCard ConvertFlashCardModelToSqlFlashCard(IFlashCard flashCard)
        {
            return new SqlFlashCard()
            {
                Id = flashCard.Id,
                Term = flashCard.Term,
                Definition = flashCard.Definition,
                FlashCardSetId = flashCard.FlashCardSetId,
            };
        }
    }
}
