using System.ComponentModel;

namespace FlashCardApp.Core.Services.TextToSpeech
{
    public enum EnumTtsApis
    {
        [Description("Google TTS Api")]
        Google,
        [Description("Microsoft TTS Api")]
        Microsoft
    }
}
