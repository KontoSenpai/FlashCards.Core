using System.ComponentModel;

namespace FlashCards.Core.Services.TextToSpeech
{
    /// <summary>
    /// List all supported TTS Apis
    /// </summary>
    public enum EnumTtsApis
    {
        /// <summary>
        /// Cloud Google TTS Api to synthesize voices
        /// </summary>
        [Description("Google TTS Api")]
        Google,
        /// <summary>
        /// Native Microsoft to synthesize voices
        /// Not recommended as it is quite limited with the amount of available voices
        /// </summary>
        [Description("Microsoft TTS Api")]
        Microsoft
    }
}
