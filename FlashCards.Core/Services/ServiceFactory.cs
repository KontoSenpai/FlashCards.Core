using System;
using FlashCards.Core.Services.Storage;
using FlashCards.Core.Services.Storage.Abstractions;
using FlashCards.Core.Services.Storage.LocalSql;
using FlashCards.Core.Services.TextToSpeech;
using FlashCards.Core.Services.TextToSpeech.Abstractions;
using FlashCards.Core.Services.TextToSpeech.GoogleApi;
using FlashCards.Core.Services.TextToSpeech.Microsoft;

namespace FlashCards.Core.Services
{
    public static class ServiceFactory
    {
        private static ITextToSpeakService _ttsService;
        private static IStorageService _storageService;

        public static ITextToSpeakService GeTextToSpeakService(EnumTtsApis ttsApis)
        {
            switch (ttsApis)
            {
                case EnumTtsApis.Google:
                    if (_ttsService == null || _ttsService.GetType() != typeof(GoogleTextToSpeechService))
                    {
                        _ttsService = new GoogleTextToSpeechService();
                    }

                    break;
                case EnumTtsApis.Microsoft:
                    if (_ttsService == null || _ttsService.GetType() != typeof(MicrosoftTextToSpeechService))
                    {
                        _ttsService = new MicrosoftTextToSpeechService();
                    }

                    break;
            }

            return _ttsService;
        }

        public static IStorageService GetStorageService(EnumStorageApis storageApis)
        {
            switch (storageApis)
            {
                case EnumStorageApis.LocalSql:
                    if (_storageService == null || _storageService.GetType() != typeof(LocalSqlStorageService))
                    {
                        _storageService = new LocalSqlStorageService();
                    }

                    break;
                default:
                    throw new NotImplementedException();
            }

            return _storageService;
        }
    }
}
