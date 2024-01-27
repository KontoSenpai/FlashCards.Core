using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using FlashCards.Core.Abstractions;
using FlashCards.Core.Services.Storage.Abstractions;
using FlashCards.Core.Services.Storage.LocalDB.Converters;
using FlashCards.Core.src.Services.Storage.LocalDB;
using FlashCards.Core.src.Services.Storage.Models;

namespace FlashCards.Core.Services.Storage.LocalDB
{
    /// <summary>
    /// Implementation of <see cref="IStorage"/>.
    /// Uses a LocalDB Connection to handle CRUD on <see cref="IFlashCardSet"/> and <see cref="IFlashCard"/>
    /// </summary>
    internal class LocalDBStorageService : IStorage
    {
        private readonly LocalStorageDBContext _context = new LocalStorageDBContext();

        #region FlashCardSets
        public async Task<PaginationResult<IFlashCardSet>> GetFlashCardSets()
        {
            return await GetFlashCardSets(new PaginationQuery());
        }

        public async Task<PaginationResult<IFlashCardSet>> GetFlashCardSets(PaginationQuery filter)
        {
            var sets = await _context.FlashCardSets
                .OrderBy(s => s.Id)
                .Where(s => s.Id >= filter.Page - 1 * filter.Limit)
                .Where(s => (!string.IsNullOrEmpty(filter.Owner) ? s.Owner == filter.Owner : true) 
                        && (!string.IsNullOrEmpty(filter.Name) ? s.Name == filter.Name : true))
                .Take(filter.Limit)
                .ToListAsync();

            var totalCount = sets
                .Where(s => (!string.IsNullOrEmpty(filter.Owner) ? s.Owner == filter.Owner : true)
                        && (!string.IsNullOrEmpty(filter.Name) ? s.Name == filter.Name : true))
                .Count();

            return new PaginationResult<IFlashCardSet>
            {
                Items = sets.ToServiceModels(),
                CurrentPage = filter.Page,
                Limit = filter.Limit,
                Total = totalCount,
                TotalPages = (int)Math.Ceiling((float)(totalCount / filter.Limit)),
            };
        }

        public async Task<IFlashCardSet> GetFlashCardSet(Guid id)
        {
            return (await _context.FlashCardSets.FindAsync(id))?.ToServiceModel();
        }

        public async Task<IFlashCardSet> CreateOrUpdateFlashCardSet(IFlashCardSet flashCardSet, bool saveChanges = true)
        {
            _context.FlashCardSets.AddOrUpdate(flashCardSet.ToSqlModel());

            await Task.WhenAll(flashCardSet.FlashCards.AsParallel().Select(c => CreateOrUpdateFlashCard(c, false)));

            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }

            return (await _context.FlashCardSets.FindAsync(flashCardSet.Id))?.ToServiceModel();
        }

        public async Task<bool> DeleteFlashCardSet(Guid id, bool saveChanges = true)
        {
            var flashCardSet = await _context.FlashCardSets.FindAsync(id);

            if (flashCardSet != null)
            {
                _context.FlashCardSets.Remove(flashCardSet);

                if (saveChanges)
                {
                    await _context.SaveChangesAsync();
                }
            }

            return (await _context.FlashCardSets.FindAsync(id)) == null;
        }
        #endregion

        #region FlashCard
        public async Task<PaginationResult<IFlashCard>> GetFlashCards()
        {
            return await GetFlashCards(new PaginationQuery());
        }

        public async Task<PaginationResult<IFlashCard>> GetFlashCards(PaginationQuery filter)
        {
            var cards = await _context.FlashCards
                .OrderBy(s => s.Id)
                .Where(s => s.Id >= filter.Page - 1 * filter.Limit)
                .Take(filter.Limit)
                .ToListAsync();

            return new PaginationResult<IFlashCard>
            {
                Items = cards.ToServiceModels(),
                CurrentPage = filter.Page,
                Limit = filter.Page,
            };
        }

        public async Task<IFlashCard> GetFlashCard(Guid id)
        {
            return (await _context.FlashCards.FindAsync(id))?.ToServiceModel();
        }

        public async Task<IFlashCard> CreateOrUpdateFlashCard(IFlashCard flashCard, bool saveChanges = true)
        {
            _context.FlashCards.AddOrUpdate(flashCard.ToSqlModel());
            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }

            var card = await _context.FlashCards.FindAsync(flashCard.Id);

            return card?.ToServiceModel();
        }

        public async Task<bool> DeleteFlashCard(Guid id, bool saveChanges = true)
        {
            var flashCard = await _context.FlashCards.FindAsync(id);

            if (flashCard != null)
            {
                _context.FlashCards.Remove(flashCard);

                if (saveChanges)
                {
                    await _context.SaveChangesAsync();
                }
            }

            return (await _context.FlashCards.FindAsync(id)) == null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
