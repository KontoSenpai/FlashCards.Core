using System.ComponentModel;

namespace FlashCards.Core.Services.TextToSpeech
{
    public enum EnumTtsApis
    {
        [Description("Google TTS Api")]
        Google,
        [Description("Microsoft TTS Api")]
        Microsoft
    }
}
