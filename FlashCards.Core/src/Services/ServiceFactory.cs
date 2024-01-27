using System;
using FlashCards.Core.Services.Storage;
using FlashCards.Core.Services.Storage.Abstractions;
using FlashCards.Core.Services.Storage.LocalDB;
using FlashCards.Core.Services.TextToSpeech;
using FlashCards.Core.Services.TextToSpeech.Abstractions;
using FlashCards.Core.Services.TextToSpeech.GoogleApi;
using FlashCards.Core.Services.TextToSpeech.Microsoft;

namespace FlashCards.Core.Services
{
    /// <summary>
    /// Factory handling the different implementation of each service provided by the API
    /// </summary>
    public static class ServiceFactory
    {
        private static ITextToSpeakService _ttsService;
        private static IStorage _storageService;

        /// <summary>
        /// Returns the <see cref="ITextToSpeakService"/> implementation corresponding to currently selected <see cref="EnumTtsApis"/>
        /// </summary>
        /// <param name="selectedTtsApi">Requested TTS service</param>
        /// <returns>Implementation of the corresponding <see cref="ITextToSpeakService"/></returns>
        /// <exception cref="NotImplementedException">When requested TTS Api doesn't exists</exception>
        public static ITextToSpeakService GeTextToSpeakService(EnumTtsApis selectedTtsApi)
        {
            switch (selectedTtsApi)
            {
                case EnumTtsApis.Google:
                    if (_ttsService == null || _ttsService.GetType() != typeof(GoogleTextToSpeechService))
                    {
                        _ttsService?.Dispose();
                        _ttsService = new GoogleTextToSpeechService();
                    }

                    break;
                case EnumTtsApis.Microsoft:
                    if (_ttsService == null || _ttsService.GetType() != typeof(MicrosoftTextToSpeechService))
                    {
                        _ttsService = new MicrosoftTextToSpeechService();
                    }
                    break;
                default:
                    throw new NotImplementedException($"There is no existing implementation for selected TTS Api {selectedTtsApi}");
            }

            return _ttsService;
        }

        /// <summary>
        /// Returns the <see cref="ITextToSpeakService"/> implementation corresponding to currently selected <see cref="EnumTtsApis"/>
        /// </summary>
        /// <param name="selectedStorageApi">Requested storage service</param>
        /// <returns>Implementation of the corresponding <see cref="ITextToSpeakService"/></returns>
        /// <exception cref="NotImplementedException">When requested TTS Api doesn't exists</exception>
        public static IStorage GetStorageService(EnumStorageApis selectedStorageApi)
        {
            switch (selectedStorageApi)
            {
                case EnumStorageApis.LocalDb:
                    if (_storageService == null || _storageService.GetType() != typeof(LocalDBStorageService))
                    {
                        _storageService?.Dispose();
                        _storageService = new LocalDBStorageService();
                    }

                    break;
                default:
                    throw new NotImplementedException($"There is no existing implementation for selected Storage Api {selectedStorageApi}");
            }

            return _storageService;
        }
    }
}
