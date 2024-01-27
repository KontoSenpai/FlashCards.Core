using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FlashCards.Core.Abstractions
{
    /// <summary>
    /// Generic representation of a FlashCardSet.
    /// A FlashCardSet represents a container of <see cref="IFlashCard"/> with a language for both the terms and the definitions
    /// </summary>
    public interface IFlashCardSet : INotifyPropertyChanged
    {
        /// <summary>
        /// Unique Identifier of the FlashCardSet
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// User-Friendly Name of the FlashCardSet
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description to describe what the <see cref="IFlashCard"/> represents in the Set
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Language to use the TTS for the synthesized voice of the <see cref="IFlashCard.Term"/>
        /// </summary>
        string TermLanguageCode { get; set; }

        /// <summary>
        /// Language to use the TTS for the synthesized voice of the <see cref="IFlashCard.Definition"/>
        /// </summary>
        string DefinitionLanguageCode { get; set; }

        /// <summary>
        /// Date when the FlashCardSet was Created
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date when the FlashCardSet content was last modified
        /// </summary>
        DateTime LastModifiedAt { get; set; }

        /// <summary>
        /// List of <see cref="IFlashCard"/> contained in the FlashCardSet
        /// </summary>
        ObservableCollection<IFlashCard> FlashCards { get; set; }
    }
}
