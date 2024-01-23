using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FlashCards.Core.Abstractions;
using FlashCards.Core.Models;
using FlashCards.Core.Services.Storage.LocalSql.Models;

namespace FlashCards.Core.Services.Storage.LocalSql.Converters
{
    /// <summary>
    /// Contains all methods to convert data between the Service Models and Storage Models
    /// </summary>
    public static class FlashCardConverters
    {
        /// <summary>
        /// Converts an SQL FlashCardSet model into a Service <see cref="IFlashCardSet"/> models
        /// </summary>
        /// <param name="sqlFlashCardSet">SQL Model to convert</param>
        /// <returns>Service FlashCardSet Implementation Model</returns>
        public static IFlashCardSet ConvertSqlFlashCardSetToFlashCardSetModel(SqlFlashCardSet sqlFlashCardSet)
        {
            var flashCardSet = new FlashCardSet()
                {
                    Id = sqlFlashCardSet.Id,
                    Name = sqlFlashCardSet.Name,
                    Description = sqlFlashCardSet.Description,
                    TermLanguageCode = sqlFlashCardSet.TermLanguageCode,
                    DefinitionLanguageCode = sqlFlashCardSet.DefinitionLanguageCode,
                    FlashCards = new ObservableCollection<IFlashCard>(),
                };

                ObservableCollection<IFlashCard> cards = new ObservableCollection<IFlashCard>();
                foreach (var flashCard in sqlFlashCardSet.FlashCards)
                {
                    cards.Add(ConvertSqlFlashCardToFlashCardModel(flashCard));
                }

                flashCardSet.FlashCards = cards;

            return flashCardSet;
        }

        /// <summary>
        /// Converts a List of SQL FlashCardSets into a List of Service <see cref="IFlashCardSet"/> models
        /// </summary>
        /// <param name="sqlFlashCardSets"></param>
        /// <returns></returns>
        public static IEnumerable<IFlashCardSet> ConvertSqlFlashCardSetsToFlashCardSetModels(IEnumerable<SqlFlashCardSet> sqlFlashCardSets)
        {
            return sqlFlashCardSets.Select(ConvertSqlFlashCardSetToFlashCardSetModel).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flashCardSet"></param>
        /// <returns></returns>
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

        public static IEnumerable<IFlashCard> ConvertSqlFlashCardsToFlashCardModels(IEnumerable<SqlFlashCard> sqlFlashCards)
        {
            return sqlFlashCards.Select(ConvertSqlFlashCardToFlashCardModel);
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
