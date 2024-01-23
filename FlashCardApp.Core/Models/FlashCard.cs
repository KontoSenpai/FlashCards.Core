using System;
using System.ComponentModel;
using FlashCardApp.Core.Abstractions;

namespace FlashCardApp.Core.Models
{
    public class FlashCard : IFlashCard
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            set { _id = value; }
        }

        private string _term;
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

        private bool _isEditing = false;
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                if (_isEditing == value) return;

                _isEditing = value;
                RaisePropertyChanged(nameof(IsEditing));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public Guid FlashCardSetId { get; set; }
        public virtual FlashCardSet FlashCardSet { get; set; }

        public bool ToggleEdit()
        {
            IsEditing = !IsEditing;
            return IsEditing;
        }
    }
}
