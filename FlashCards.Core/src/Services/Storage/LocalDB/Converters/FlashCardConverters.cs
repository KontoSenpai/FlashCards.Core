using System.Collections.Generic;
using FlashCards.Core.Abstractions;
using FlashCards.Core.src.Services.Storage.LocalDB;
using ServiceModel = FlashCards.Core.Models.FlashCardModel;

namespace FlashCards.Core.Services.Storage.LocalDB.Converters
{
    internal static class FlashCardConverters
    {
        public static IFlashCard ToServiceModel(this FlashCard flashCard)
        {
            return new ServiceModel()
            {
                Id = flashCard.Id,
                Definition = flashCard.Definition,
                Term = flashCard.Term,
                TimeStudied = flashCard.TimeStudied,
                ErrorsMade = flashCard.ErrorsMade,
                FlashCardSetId = flashCard.FlashCardSetId,
            };
        }

        public static IEnumerable<IFlashCard> ToServiceModels(this ICollection<FlashCard> flashCards)
        {
            var cards = new List<IFlashCard>();
            foreach (var flashCard in flashCards)
            {
                cards.Add(ToServiceModel(flashCard));
            }

            return cards;
        }

        public static FlashCard ToSqlModel(this IFlashCard flashCard)
        {
            return new FlashCard()
            {
                Id = flashCard.Id,
                Term = flashCard.Term,
                Definition = flashCard.Definition,
                TimeStudied = flashCard.TimeStudied,
                ErrorsMade = flashCard.ErrorsMade,
                FlashCardSetId = flashCard.FlashCardSetId,
            };
        }
    }
}
