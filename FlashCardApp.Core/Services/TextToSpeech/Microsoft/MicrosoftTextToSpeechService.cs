using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlashCardApp.Core.Services.TextToSpeech.Abstractions;
using FlashCardApp.Core.Services.TextToSpeech.Models;

namespace FlashCardApp.Core.Services.TextToSpeech.Microsoft
{
    internal class MicrosoftTextToSpeechService : BaseTextToSpeechService, ITextToSpeakService
    {
        public MicrosoftTextToSpeechService()
        {

        }

        public void ReadText(string text, string languageCode)
        {
            throw new NotImplementedException();
        }

        public Task FetchLanguages()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TextToSpeechLanguage> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetLanguageCodes()
        {
            throw new NotImplementedException();
        }

        public TextToSpeechLanguage GetLanguage(string lanuageCode)
        {
            throw new NotImplementedException();
        }

        public bool HasLanguage(string languageCode)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
