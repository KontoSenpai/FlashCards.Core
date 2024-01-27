using System;
using System.ComponentModel.DataAnnotations.Schema;
using FlashCards.Core.Abstractions;

namespace FlashCards.Core.Services.Storage.LocalDB.Models
{
    /// <summary>
    /// Represent a Storage implementation of a <see cref="IFlashCard"/>
    /// </summary>
    [Table("FlashCards")]
    internal class SqlFlashCard
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
