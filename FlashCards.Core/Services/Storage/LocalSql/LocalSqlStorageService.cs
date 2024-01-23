using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using FlashCards.Core.Abstractions;
using FlashCards.Core.Services.Storage.Abstractions;
using FlashCards.Core.Services.Storage.LocalSql.Converters;
using FlashCards.Core.Services.Storage.LocalSql.Models;

namespace FlashCards.Core.Services.Storage.LocalSql
{
    public class LocalSqlStorageService : IStorageService
    {
        private readonly DatabaseContext _context = new DatabaseContext();

        public async Task<IEnumerable<IFlashCardSet>> GetFlashCardSets()
        {
            var result = await _context.SqlFlashCardSets.ToListAsync();
            return FlashCardConverters.ConvertSqlFlashCardSetsToFlashCardSetModels(result);
        }

        public async Task<IFlashCardSet> GetFlashCardSet(Guid id)
        {
            var result = await _context.SqlFlashCardSets.FirstOrDefaultAsync(s => s.Id == id);;

            return FlashCardConverters.ConvertSqlFlashCardSetToFlashCardSetModel(result);
        }

        public async Task<IFlashCardSet> CreateOrUpdateFlashCardSet(IFlashCardSet flashCardSet)
        {
            var sqlFlashCard = FlashCardConverters.ConvertFlashCardSetModelToSqlFlashCardSet(flashCardSet);
            _context.SqlFlashCardSets.AddOrUpdate(sqlFlashCard);
            
            await _context.SaveChangesAsync();

            return await GetFlashCardSet(flashCardSet.Id);
        }

        public async Task DeleteFlashCardSet(Guid flashCardSetId)
        {
            var flashCardSet = await _context.SqlFlashCardSets.FindAsync(flashCardSetId);
            if (flashCardSet != null)
            {
                _context.SqlFlashCardSets.Remove(flashCardSet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IFlashCard>> GetFlashCards()
        {
            var result = await _context.SqlFlashCards.ToListAsync();
            return FlashCardConverters.ConvertSqlFlashCardsToFlashCardModels(result);
        }

        public async Task<IFlashCard> GetFlashCard(Guid id)
        {
            var result = await _context.SqlFlashCards.FindAsync(id);
            return FlashCardConverters.ConvertSqlFlashCardToFlashCardModel(result);
        }

        public async Task<IFlashCard> CreateOrUpdateFlashCard(IFlashCard flashCard)
        {
            var sqlFlashCard = FlashCardConverters.ConvertFlashCardModelToSqlFlashCard(flashCard);
            _context.SqlFlashCards.AddOrUpdate(sqlFlashCard);

            await _context.SaveChangesAsync();

            return await GetFlashCard(flashCard.Id);
        }

        public async Task DeleteFlashCard(Guid flashCardId)
        {
            var flashCard = await _context.SqlFlashCards.FindAsync(flashCardId);

            if (flashCard != null)
            {
                _context.SqlFlashCards.Remove(flashCard);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
