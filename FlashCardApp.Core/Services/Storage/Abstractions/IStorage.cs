using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlashCardApp.Core.Abstractions;
using FlashCardApp.Core.Models;

namespace FlashCardApp.Core.Services.Storage.Abstractions
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
