using FlashCards.Core.Models;
using System;
using System.ComponentModel;

namespace FlashCards.Core.Abstractions
{
    public interface IFlashCardSet : INotifyPropertyChanged
    {
        Guid Id { get; }

        string Name { get; set; }

        string Description { get; set; }

        string TermLanguageCode { get; set; }

        string DefinitionLanguageCode { get; set; }

        ExpandedObservableCollection<IFlashCard> FlashCards { get; set; }
    }
}
