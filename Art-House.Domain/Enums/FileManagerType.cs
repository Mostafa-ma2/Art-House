using System;
using System.ComponentModel;

namespace Art_House.Domain.Enums
{
    public static class FileManagerType
    {
        public enum FileType
        {
            PostTextImages = 1,
            PostImage = 2
        }

        public static string ParseType(FileType type)
        {
            if (!Enum.IsDefined(typeof(FileType), type))
            {
                throw new InvalidEnumArgumentException(nameof(type), (int)type, typeof(FileType));
            }

            return type switch
            {
                FileType.PostTextImages => "PostTextImages",
                FileType.PostImage => "PostImages",
                _ => throw new ArgumentException("please enter a valid type")
            };
        }
    }
}