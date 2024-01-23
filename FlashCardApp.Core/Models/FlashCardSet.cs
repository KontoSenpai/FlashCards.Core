using System;
using System.ComponentModel;
using FlashCardApp.Core.Abstractions;

namespace FlashCardApp.Core.Models
{
    public class FlashCardSet : IFlashCardSet
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get => _name;

            set
            {
                if (_name == value) return;

                _name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private string _description;
        public string Description
        {
            get => _description;

            set
            {
                if (_description == value) return;

                _description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        private string _termLanguageCode;
        public string TermLanguageCode
        {
            get => _termLanguageCode;
            set
            {
                if (_termLanguageCode == value) return;

                _termLanguageCode = value;
                RaisePropertyChanged(nameof(TermLanguageCode));
            }
        }

        private string _definitionLanguageCode;
        public string DefinitionLanguageCode
        {
            get => _definitionLanguageCode;
            set
            {
                if (_definitionLanguageCode == value) return;

                _definitionLanguageCode = value;
                RaisePropertyChanged(nameof(DefinitionLanguageCode));
            }
        }

        private ExpandedObservableCollection<IFlashCard> _flashCards;
        public ExpandedObservableCollection<IFlashCard> FlashCards
        {
            get => _flashCards;
            set
            {
                if (_flashCards == value) return;

                _flashCards = value;
                RaisePropertyChanged(nameof(FlashCards));
            }
        }

        public FlashCardSet()
        {
            FlashCards = new ExpandedObservableCollection<IFlashCard>();
        }

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
