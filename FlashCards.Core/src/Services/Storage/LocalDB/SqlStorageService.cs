using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using FlashCards.Core.Abstractions;
using FlashCards.Core.Services.Storage.Abstractions;
using FlashCards.Core.Services.Storage.LocalDB.Converters;
using FlashCards.Core.Services.Storage.LocalDB.Models;

namespace FlashCards.Core.Services.Storage.LocalDB
{
    /// <summary>
    /// Implementation of <see cref="IStorage"/>.
    /// Uses a LocalDB Connection to handle CRUD on <see cref="IFlashCardSet"/> and <see cref="IFlashCard"/>
    /// </summary>
    internal class SqlStorageService : IStorage
    {
        private readonly DBContext _context = new DBContext();

        #region FlashCardSets
        public async Task<IEnumerable<IFlashCardSet>> GetFlashCardSets()
        {
            return (await _context.SqlFlashCardSets.ToListAsync()).ToServiceModels();
        }

        public async Task<IFlashCardSet> GetFlashCardSet(Guid id)
        {
            return (await _context.SqlFlashCardSets.FindAsync(id))?.ToServiceModel();
        }

        public async Task<IFlashCardSet> CreateOrUpdateFlashCardSet(IFlashCardSet flashCardSet)
        {
            _context.SqlFlashCardSets.AddOrUpdate(flashCardSet.ToSqlModel());
            await _context.SaveChangesAsync();

            return (await _context.SqlFlashCardSets.FindAsync(flashCardSet.Id))?.ToServiceModel();
        }

        public async Task<bool> DeleteFlashCardSet(Guid id)
        {
            var flashCardSet = await _context.SqlFlashCardSets.FindAsync(id);

            if (flashCardSet != null)
            {
                _context.SqlFlashCardSets.Remove(flashCardSet);
                await _context.SaveChangesAsync();
            }

            return (await _context.SqlFlashCardSets.FindAsync(id)) == null;
        }
        #endregion

        #region FlashCard
        public async Task<IEnumerable<IFlashCard>> GetFlashCards()
        {
            return (await _context.SqlFlashCards.ToListAsync()).ToServiceModels();
        }

        public async Task<IFlashCard> GetFlashCard(Guid id)
        {
            return (await _context.SqlFlashCards.FindAsync(id))?.ToServiceModel();
        }

        public async Task<IFlashCard> CreateOrUpdateFlashCard(IFlashCard flashCard)
        {
            _context.SqlFlashCards.AddOrUpdate(flashCard.ToSqlModel());
            await _context.SaveChangesAsync();

            return (await _context.SqlFlashCards.FindAsync(flashCard.Id))?.ToServiceModel();
        }

        public async Task<bool> DeleteFlashCard(Guid id)
        {
            var flashCard = await _context.SqlFlashCards.FindAsync(id);

            if (flashCard != null)
            {
                _context.SqlFlashCards.Remove(flashCard);
                await _context.SaveChangesAsync();
            }

            return (await _context.SqlFlashCards.FindAsync(id)) == null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
