using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackupTools
{
    public static class FileUtilities
    {
        public static FileInfo[] GetAllFileInfo(string dir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (dirInfo.Exists)
            {
                return dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            }
            return new FileInfo[0];
        }
    }
}
