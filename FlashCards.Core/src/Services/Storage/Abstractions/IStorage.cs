using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlashCards.Core.Abstractions;
using FlashCards.Core.Models;

namespace FlashCards.Core.Services.Storage.Abstractions
{
    public interface IStorage
    {
        Task<List<FlashCardSet>> GetFlashCardSetsAsync();
        Task<FlashCardSet> GetFlashCardSetAsync(Guid id);
        Task<FlashCardSet> AddFlashCardSetAsync(FlashCardSet flashCardSet);
        Task<FlashCardSet> UpdateFlashCardSetAsync(FlashCardSet flashCardSet);
        Task DeleteFlashCardSetAsync(Guid flashCardSetId);

        Task<IFlashCard> AddFlashCardAsync(IFlashCard flashCard);
        Task<IFlashCard> UpdateFlashCardAsync(IFlashCard flashCard);
        Task DeleteFlashCardAsync(Guid flashCardId);
    }
}
