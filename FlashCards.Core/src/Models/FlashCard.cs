using System;
using System.ComponentModel;
using FlashCards.Core.Abstractions;

namespace FlashCards.Core.Models
{
    /// <summary>
    /// Default implementation of <see cref="IFlashCard"/>
    /// </summary>
    public class FlashCard : IFlashCard
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

        /// <inheritdoc/>
        public Guid FlashCardSetId { get; set; }

        private string _term;
        /// <inheritdoc/>
        public string Term
        {
            get => _term;
            set
            {
                if (_term == value) return;

                _term = value;
                RaisePropertyChanged(nameof(Term));
            }
        }

        private string _definition;
        /// <inheritdoc/>
        public string Definition
        {
            get => _definition;
            set
            {
                if (_definition == value) return;

                _definition = value;
                RaisePropertyChanged(nameof(Definition));
            }
        }

        private int _timeStudied;
        /// <inheritdoc/>
        public int TimeStudied
        {
            get => _timeStudied;
            set
            {
                if (_timeStudied == value) return;

                _timeStudied = value;
                RaisePropertyChanged(nameof(TimeStudied));
            }
        }

        private int _errorsMade;
        /// <inheritdoc/>
        public int ErrorsMade
        {
            get => _errorsMade;
            set
            {
                if (_errorsMade == value) return;

                _errorsMade = value;
                RaisePropertyChanged(nameof(ErrorsMade));
            }
        }

        private bool _isEditing = false;
        /// <inheritdoc/>
        public bool IsEditing
        {
            get => _isEditing;
            private set
            {
                if (_isEditing == value) return;

                _isEditing = value;
                RaisePropertyChanged(nameof(IsEditing));
            }
        }

        /// <inheritdoc/>
        public bool ToggleEdit()
        {
            IsEditing = !IsEditing;
            return IsEditing;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        
        /// <summary>
        /// <see cref="FlashCardSet"/> containing the FlashCard
        /// </summary>
        public virtual FlashCardSet FlashCardSet { get; set; }
    }
}
