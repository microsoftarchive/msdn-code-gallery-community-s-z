using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveManager
{
    public enum ArchiverType
    {
        Zip,
        Gzip,
        Tar,
        Tgz
    }

    [Flags]
    public enum MenuOptions
    {
        ArchiveComment = 1,
        Password = 2,
        CreateSfx = 4,
        AddFolder = 8,
        Delete = 16,
        CreateDirectory = 32,
        Move = 64,
        ArchiveItemComment = 128,
        Update = 256,

        All = 0xFFFF,
    }
}
