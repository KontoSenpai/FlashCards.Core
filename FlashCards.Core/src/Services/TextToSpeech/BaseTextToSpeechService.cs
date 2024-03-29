﻿using System.IO;
using FlashCards.Core.Helpers;

namespace FlashCards.Core.Services.TextToSpeech
{
    public abstract class BaseTextToSpeechService
    {
        protected bool TryCreateFile(string name, out FileStream fileStream)
        {
            DirectoryInfo di = new DirectoryInfo(FilesManager.GetFolderPath());
            if (!di.Exists)
            {
                di.Create();
            }
            fileStream = File.Create(FilesManager.GetFilePath(name));

            return fileStream != null;
        }

        protected bool TryGetFile(string name, out string file)
        {
            file = FilesManager.GetFilePath(name);

            return File.Exists(file);
        }
    }
}
