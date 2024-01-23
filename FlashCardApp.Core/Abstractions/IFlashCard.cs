using System;
using System.ComponentModel;

namespace FlashCardApp.Core.Abstractions
{
    public interface IFlashCard : INotifyPropertyChanged
    {
        Guid Id { get; }

        Guid FlashCardSetId { get; set; }

        string Term { get; set; }

        string Definition { get; set; }

        bool ToggleEdit();
    }
}
