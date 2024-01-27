using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlashCards.Core.Abstractions;
using FlashCards.Core.src.Services.Storage.Models;

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
        Task<IFlashCardSet> GetFlashCardSet(int id);

        /// <summary>
        /// Retrieves paginated <see cref="IFlashCardSet"/> that exists in the storage
        /// </summary>
        /// <returns>A <see cref="PaginationResult{T}"/> of all existing <see cref="IFlashCardSet"/></returns>
        Task<PaginationResult<IFlashCardSet>> GetFlashCardSets();

        /// <summary>
        /// Retrieves paginated <see cref="IFlashCardSet"/> that exists in the storage
        /// </summary>
        /// <param name="filter">Pagination Filter to use to retrieve the <see cref="IFlashCardSet"/></param>
        /// <returns>A <see cref="PaginationResult{T}"/> of all existing <see cref="IFlashCardSet"/></returns>
        Task<PaginationResult<IFlashCardSet>> GetFlashCardSets(PaginationQuery filter);

        /// <summary>
        /// Create an object in the storage if it doesn't exist.
        /// If it exists, update the object instead.
        /// </summary>
        /// <param name="flashCardSet">FlashCardSet to Create or Update</param>
        /// <param name="saveChanges">Whether or not to save changes after performing the query. Default is true</param>
        /// <returns>The update <see cref="IFlashCardSet"/> object in the storage</returns>
        Task<IFlashCardSet> CreateOrUpdateFlashCardSet(IFlashCardSet flashCardSet, bool saveChanges = true);

        /// <summary>
        /// Delete the <see cref="IFlashCardSet"/> corresponding to given unique identifier from the storage
        /// </summary>
        /// <param name="id">Unique Identifier of the <see cref="IFlashCardSet"/> to delete</param>
        /// <param name="saveChanges">Whether or not to save changes after performing the query. Default is true</param>
        /// <returns>True if the <see cref="IFlashCardSet"/> still exists in the storage, False otherwise</returns>
        Task<bool> DeleteFlashCardSet(int id, bool saveChanges = true);

        // FlashCards

        /// <summary>
        /// Retrieves the <see cref="IFlashCard"/> corresponding to given unique identifier from the storage
        /// </summary>
        /// <param name="id">Unique Identifier of the <see cref="IFlashCard"/> to retrieve</param>
        /// <returns>The <see cref="IFlashCard"/> if it exists, null otherwise</returns>
        Task<IFlashCard> GetFlashCard(int id);

        /// <summary>
        /// Retrieves all <see cref="IFlashCard"/> that exists in the storage
        /// </summary>
        /// <returns>A <see cref="IEnumerable{T}"/> of all existing <see cref="IFlashCard"/></returns>
        Task<PaginationResult<IFlashCard>> GetFlashCards();

        /// <summary>
        /// Retrieves all <see cref="IFlashCard"/> that exists in the storage
        /// </summary>
        /// <param name="filter">Pagination Filter to use to retrieve the <see cref="IFlashCard"/></param>
        /// <returns>A <see cref="IEnumerable{T}"/> of all existing <see cref="IFlashCard"/></returns>
        Task<PaginationResult<IFlashCard>> GetFlashCards(PaginationQuery filter);

        /// <summary>
        /// Create an object in the storage if it doesn't exist.
        /// If it exists, update the object instead.
        /// </summary>
        /// <param name="flashCard">FlashCardSet to Create or Update</param>
        /// <param name="saveChanges">Whether or not to save changes after performing the query. Default is true</param>
        /// <returns>The update <see cref="IFlashCard"/> object in the storage</returns>
        Task<IFlashCard> CreateOrUpdateFlashCard(IFlashCard flashCard, bool saveChanges = true);

        /// <summary>
        /// Delete the <see cref="IFlashCard"/> corresponding to given unique identifier from the storage
        /// </summary>
        /// <param name="id">Unique Identifier of the <see cref="IFlashCard"/> to delete</param>
        /// <param name="saveChanges">Whether or not to save changes after performing the query. Default is true</param>
        /// <returns>True if the <see cref="IFlashCard"/> still exists in the storage, False otherwise</returns>
        Task<bool> DeleteFlashCard(int id, bool saveChanges = true);
    }
}
