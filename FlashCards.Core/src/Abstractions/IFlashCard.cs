using System;
using System.ComponentModel;

namespace FlashCards.Core.Abstractions
{
    /// <summary>
    /// Generic representation of a FlashCard.
    /// A FlashCard represents a combination of a term and a definition
    /// </summary>
    public interface IFlashCard : INotifyPropertyChanged
    {
        /// <summary>
        /// Unique Identifier of the FlashCard
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Unique identifier of the <see cref="IFlashCardSet"/> that contains the FlashCard
        /// </summary>
        int FlashCardSetId { get; set; }

        /// <summary>
        /// Term of the FlashCard
        /// </summary>
        string Term { get; set; }

        /// <summary>
        /// Definition of the <see cref="Term"/> of the FlashCard
        /// </summary>
        string Definition { get; set; }

        /// <summary>
        /// Amount of times this <see cref="Term"/> has been studied
        /// </summary>
        int TimeStudied { get; set; }

        /// <summary>
        /// Amount of times the studied <see cref="Term"/> was guessed wrong
        /// </summary>
        int ErrorsMade { get; set; }

        /// <summary>
        /// Changes the logic of the FlashCard based on the state
        /// </summary>
        bool IsEditing { get; }

        /// <summary>
        /// Changes the state of the <see cref="IsEditing"/> value
        /// </summary>
        /// <returns>New <see cref="IsEditing"/> state</returns>
        bool ToggleEdit();
    }
}
