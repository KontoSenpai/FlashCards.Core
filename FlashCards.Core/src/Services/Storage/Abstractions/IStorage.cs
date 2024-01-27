using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlashCards.Core.Abstractions;

namespace FlashCards.Core.Services.Storage.Abstractions
{
    /// <summary>
    /// Interface defining permitted operations on storage implementations
    /// </summary>
    public interface IStorage : IDisposable
    {
        // FlashCardSets

        /// <summary>
        /// Retrieves the <see cref="IFlashCardSet"/> corresponding to given unique identifier from the storage
        /// </summary>
        /// <param name="id">Unique Identifier of the <see cref="IFlashCardSet"/> to retrieve</param>
        /// <returns>The <see cref="IFlashCardSet"/> if it exists, null otherwise</returns>
        Task<IFlashCardSet> GetFlashCardSet(Guid id);

        /// <summary>
        /// Retrieves all <see cref="IFlashCardSet"/> that exists in the storage
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of all existing <see cref="IFlashCardSet"/></returns>
        Task<IEnumerable<IFlashCardSet>> GetFlashCardSets();

        /// <summary>
        /// Create an object in the storage if it doesn't exist.
        /// If it exists, update the object instead.
        /// </summary>
        /// <param name="flashCardSet">FlashCardSet to Create or Update</param>
        /// <returns>The update <see cref="IFlashCardSet"/> object in the storage</returns>
        Task<IFlashCardSet> CreateOrUpdateFlashCardSet(IFlashCardSet flashCardSet);

        /// <summary>
        /// Delete the <see cref="IFlashCardSet"/> corresponding to given unique identifier from the storage
        /// </summary>
        /// <param name="id">Unique Identifier of the <see cref="IFlashCardSet"/> to delete</param>
        /// <returns>True if the <see cref="IFlashCardSet"/> still exists in the storage, False otherwise</returns>
        Task<bool> DeleteFlashCardSet(Guid id);

        // FlashCards

        /// <summary>
        /// Retrieves the <see cref="IFlashCard"/> corresponding to given unique identifier from the storage
        /// </summary>
        /// <param name="id">Unique Identifier of the <see cref="IFlashCard"/> to retrieve</param>
        /// <returns>The <see cref="IFlashCard"/> if it exists, null otherwise</returns>
        Task<IFlashCard> GetFlashCard(Guid id);

        /// <summary>
        /// Retrieves all <see cref="IFlashCard"/> that exists in the storage
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of all existing <see cref="IFlashCard"/></returns>
        Task<IEnumerable<IFlashCard>> GetFlashCards();

        /// <summary>
        /// Create an object in the storage if it doesn't exist.
        /// If it exists, update the object instead.
        /// </summary>
        /// <param name="flashCard">FlashCardSet to Create or Update</param>
        /// <returns>The update <see cref="IFlashCard"/> object in the storage</returns>
        Task<IFlashCard> CreateOrUpdateFlashCard(IFlashCard flashCard);

        /// <summary>
        /// Delete the <see cref="IFlashCard"/> corresponding to given unique identifier from the storage
        /// </summary>
        /// <param name="id">Unique Identifier of the <see cref="IFlashCard"/> to delete</param>
        /// <returns>True if the <see cref="IFlashCard"/> still exists in the storage, False otherwise</returns>
        Task<bool> DeleteFlashCard(Guid id);
    }
}
