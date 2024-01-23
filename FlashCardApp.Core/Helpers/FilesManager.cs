using System;
using System.IO;
using System.Threading.Tasks;

namespace FlashCardApp.Core.Helpers
{
    public static class FilesManager
    {
        private static readonly string _soundsFolder = "Sounds";

        public static async Task CleanSoundsFolder()
        {
            var folderPath = GetFolderPath();
            if (!Directory.Exists(folderPath))
            {
                return;
            }

            Parallel.ForEach(Directory.EnumerateFiles(folderPath), File.Delete);

            Directory.Delete(GetFolderPath());
        }

        public static string GetFolderPath()
        {
            string baseFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            string ttsFolder = Path.Combine(baseFolder, AppDomain.CurrentDomain.FriendlyName, _soundsFolder);

            return Path.Combine(baseFolder, ttsFolder);
        }

        public static string GetFilePath(string name)
        {
            return Path.Combine(GetFolderPath(), $"{name}.wav");
        }
    }
}
