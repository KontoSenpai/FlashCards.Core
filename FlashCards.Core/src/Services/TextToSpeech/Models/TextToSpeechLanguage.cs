namespace FlashCards.Core.Services.TextToSpeech.Models
{
    /// <summary>
    /// Represents A Service TTS Language model
    /// </summary>
    public class TextToSpeechLanguage
    {
        /// <summary>
        /// Display value of the language
        /// <example>English (United-States)</example>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// LanguageCode to generate the voice for language
        /// <example>EN-US</example>
        /// </summary>
        public string LanguageCode { get; set; }
    }
}
