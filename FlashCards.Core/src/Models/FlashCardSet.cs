﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FlashCards.Core.Abstractions;

namespace FlashCards.Core.Models
{
    /// <summary>
    /// Default implementation of <see cref="IFlashCard"/>
    /// </summary>
    public class FlashCardSet : IFlashCardSet
    {
        private Guid _id;
        /// <inheritdoc/>
        public Guid Id
        {
            get => _id;
            set
            {
                if (_id == value) return;

                _id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        private string _name;
        /// <inheritdoc/>
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
        /// <inheritdoc/>
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
        /// <inheritdoc/>
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
        /// <inheritdoc/>
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

        private DateTime _createdAt;
        /// <inheritdoc/>
        public DateTime CreatedAt
        {
            get => _createdAt;
            set
            {
                if (_createdAt == value) return;

                _createdAt = value;
                RaisePropertyChanged(nameof(CreatedAt));
            }
        }

        private DateTime _lastModifiedAt;
        /// <inheritdoc/>
        public DateTime LastModifiedAt
        {
            get => _lastModifiedAt;
            set
            {
                if (_lastModifiedAt == value) return;

                _lastModifiedAt = value;
                RaisePropertyChanged(nameof(LastModifiedAt));
            }
        }

        private ObservableCollection<IFlashCard> _flashCards;
        /// <inheritdoc/>
        public ObservableCollection<IFlashCard> FlashCards
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
            FlashCards = new ObservableCollection<IFlashCard>();
            CreatedAt = DateTime.Now;
            LastModifiedAt = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
