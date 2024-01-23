using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlashCardApp.Core.Services.Storage.Sql.Models
{
    [Table("FlashCards")]
    public class SqlFlashCard
    {
        public Guid Id { get; set; }

        public string Term { get; set; }

        public string Definition { get; set; }

        public Guid FlashCardSetId { get; set; }

        public virtual SqlFlashCardSet FlashCardSet { get; set; }
    }
}