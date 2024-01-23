using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashCards.Core.Services.Storage.LocalSql.Models
{
    [Table("FlashCards")]
    public class SqlFlashCard
    {
        public Guid Id { get; set; }

        public string Term { get; set; }

        public string Definition { get; set; }

        public Guid FlashCardSetId { get; set; }

        public int TimeStudied { get; set; }

        public int ErrorsMade { get; set; }

        public virtual SqlFlashCardSet FlashCardSet { get; set; }
    }
}
