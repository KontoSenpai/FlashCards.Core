using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using FlashCardApp.Core.Services.TextToSpeech.Abstractions;
using Google.Cloud.TextToSpeech.V1;
using FlashCardApp.Core.Services.TextToSpeech.Models;
using System.Globalization;

namespace FlashCardApp.Core.Services.TextToSpeech.GoogleApi
{
    internal class GoogleTextToSpeechService : BaseTextToSpeechService, ITextToSpeakService
    {
        private TextToSpeechClient _client;

        private List<Voice> _voices;

        public GoogleTextToSpeechService()
        {
            _client = TextToSpeechClient.Create();
        }

        public void ReadText(string text, string languageCode)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(languageCode))
            {
                return;
            }

            // The input to be synthesized, can be provided as text or SSML.
            var input = new SynthesisInput
            {
                Text = text
            };

            // Build the voice request.
            var voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = languageCode,
                SsmlGender = SsmlVoiceGender.Female
            };

            // Specify the type of audio file.
            var audioConfig = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16
            };

            string fileName = $"{input.GetHashCode().ToString()}-{languageCode}";

            if (!TryGetFile(fileName, out string filePath))
            {
                // Perform the text-to-speech request.
                var response = _client.SynthesizeSpeech(input, voiceSelection, audioConfig);
                if (!TryCreateFile(fileName, out FileStream stream))
                {
                    throw new Exception("Unable to create file");
                }
                // Write the response to the output file.
                using (var output = stream)
                {
                    response.AudioContent.WriteTo(output);
                }
                stream.Dispose();
            }


            using (var soundPlayer = new SoundPlayer(filePath))
            {
                soundPlayer.Play();
            }
        }

        public async Task FetchLanguages()
        {
            var response = await _client.ListVoicesAsync(new ListVoicesRequest());
            _voices = response.Voices.ToList();
        }

        public IEnumerable<TextToSpeechLanguage> GetLanguages()
        {
            return _voices.Select(x => new TextToSpeechLanguage()
            {
                DisplayName =
                    CultureInfo.GetCultures(CultureTypes.AllCultures)
                        .FirstOrDefault(c => c.Name == x.LanguageCodes.First())?.DisplayName ?? "Unknown",
                LanguageCode = x.LanguageCodes.First(),
            }).GroupBy(l => l.LanguageCode).Select(l => l.First());
        }

        public IEnumerable<string> GetLanguageCodes()
        {
            return _voices.Select(x => x.LanguageCodes.First());
        }

        public TextToSpeechLanguage GetLanguage(string languageCode)
        {
            return GetLanguages().FirstOrDefault(l => l.LanguageCode == languageCode);
        }

        public bool HasLanguage(string languageCode)
        {
            var response = _client.ListVoices(languageCode);

            return response.Voices.Any();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
