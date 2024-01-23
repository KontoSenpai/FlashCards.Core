using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using FlashCardApp.Core.Models;
using FlashCardApp.Core.Services.Storage.Sql.Models;
using FlashCardApp.Core.Services.Storage.Abstractions;
using FlashCardApp.Core.Services.Storage.Sql.Converters;
using FlashCardApp.Core.Abstractions;

namespace FlashCardApp.Core.Services.Storage.Sql
{
    public class SqlStorageService : IStorage
    {
        private readonly DBContext _context = new DBContext();

        public Task<List<FlashCardSet>> GetFlashCardSetsAsync()
        {
            var task = new Task<List<FlashCardSet>>(() =>
            {
                var result = _context.SqlFlashCardSets.ToListAsync().ConfigureAwait(true).GetAwaiter().GetResult();
                return FlashCardConverters.ConvertSqlFlashCardSetsToFlashCardSetModels(result);
            });

            task.Start();
            return task;
        }

        public Task<FlashCardSet> GetFlashCardSetAsync(Guid id)
        {
            return null;
            //return _context.FlashCardSets.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<FlashCardSet> AddFlashCardSetAsync(FlashCardSet flashCardSet)
        {
            var sqlFlashCard = FlashCardConverters.ConvertFlashCardSetModelToSqlFlashCardSet(flashCardSet);
            _context.SqlFlashCardSets.Add(sqlFlashCard);
            await _context.SaveChangesAsync();
            return FlashCardConverters.ConvertSqlFlashCardSetToFlashCardSetModel(_context.SqlFlashCardSets.Find(sqlFlashCard));
        }

        public async Task<FlashCardSet> UpdateFlashCardSetAsync(FlashCardSet flashCardSet)
        {
            //if (!_context.FlashCardSets.Local.Any(c => c.Id == flashCardSet.Id))
            //{
            //    _context.FlashCardSets.Attach(flashCardSet);
            //}

            _context.Entry(flashCardSet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return flashCardSet;
        }

        public async Task DeleteFlashCardSetAsync(Guid flashCardSetId)
        {
            var flashCardSet = _context.SqlFlashCardSets.FirstOrDefault(c => c.Id == flashCardSetId);

            if (flashCardSet != null)
            {
                _context.SqlFlashCardSets.Remove(flashCardSet);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IFlashCard> AddFlashCardAsync(IFlashCard flashCard)
        {
            var sqlFlashCard = FlashCardConverters.ConvertFlashCardModelToSqlFlashCard(flashCard);

            _context.SqlFlashCards.Add(sqlFlashCard);
            await _context.SaveChangesAsync();
            
            return FlashCardConverters.ConvertSqlFlashCardToFlashCardModel(_context.SqlFlashCards.Single(c => c.Id == sqlFlashCard.Id));
        }

        public async Task<IFlashCard> UpdateFlashCardAsync(IFlashCard flashCard)
        {
            var sqlFlashCard = FlashCardConverters.ConvertFlashCardModelToSqlFlashCard(flashCard);
            _context.SqlFlashCards.AddOrUpdate(sqlFlashCard);

            await _context.SaveChangesAsync();

            return FlashCardConverters.ConvertSqlFlashCardToFlashCardModel(_context.SqlFlashCards.Single(c => c.Id == sqlFlashCard.Id));
        }

        public async Task DeleteFlashCardAsync(Guid flashCardId)
        {
            var flashCard = _context.SqlFlashCards.FirstOrDefault(c => c.Id == flashCardId);

            if (flashCard != null)
            {
                _context.SqlFlashCards.Remove(flashCard);
                await _context.SaveChangesAsync();
            }
        }
    }
}
