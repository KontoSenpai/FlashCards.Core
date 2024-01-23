using FlashCards.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Core.Services.Storage.Abstractions
{
    public interface IStorageService : IDisposable
    {
        // FlashCardSets
        Task<IEnumerable<IFlashCardSet>> GetFlashCardSets();
        Task<IFlashCardSet> GetFlashCardSet(Guid id);

        Task<IFlashCardSet> CreateOrUpdateFlashCardSet(IFlashCardSet flashCardSet);
        Task DeleteFlashCardSet(Guid flashCardSetId);

        // FlashCards
        Task<IEnumerable<IFlashCard>> GetFlashCards();
        Task<IFlashCard> GetFlashCard(Guid id);

        Task<IFlashCard> CreateOrUpdateFlashCard(IFlashCard flashCard);
        Task DeleteFlashCard(Guid flashCardId);
    }
}
