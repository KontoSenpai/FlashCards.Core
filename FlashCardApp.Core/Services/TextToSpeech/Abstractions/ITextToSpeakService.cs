using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlashCardApp.Core.Services.TextToSpeech.Models;

namespace FlashCardApp.Core.Services.TextToSpeech.Abstractions
{
    public interface ITextToSpeakService : IDisposable
    {
        void ReadText(string text, string languageCode);

        Task FetchLanguages();

        IEnumerable<TextToSpeechLanguage> GetLanguages();

        IEnumerable<string> GetLanguageCodes();

        TextToSpeechLanguage GetLanguage(string languageCode);

        bool HasLanguage(string languageCode);
    }
}
