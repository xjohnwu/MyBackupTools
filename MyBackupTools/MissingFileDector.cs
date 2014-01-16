using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackupTools
{
    public class MissingFileDector
    {
        public IEnumerable<FileInfo> Compare(string srcDir, string destDir)
        {
            var srcFileInfos = FileUtilities.GetAllFileInfo(srcDir);
            var destFileInfos = FileUtilities.GetAllFileInfo(destDir);

            return DetectMissingFiles(srcFileInfos, destFileInfos);
        }

        private IEnumerable<FileInfo> DetectMissingFiles(FileInfo[] srcFiles, FileInfo[] destFiles)
        {
            var destFileList = new List<FileInfo>(destFiles);
            foreach (var srcFile in srcFiles)
            {
                if (!Constains(ref destFileList, srcFile))
                {
                    yield return srcFile;
                }
            }
        }

        private bool Constains(ref List<FileInfo> destFiles, FileInfo srcFile)
        {
            FileInfo matchingFile = null;
            if (TryGetMatchingFile(srcFile, destFiles, out matchingFile))
            {
                destFiles.Remove(matchingFile);
                return true;
            }
            return false;
        }

        private bool TryGetMatchingFile(FileInfo srcFile, IEnumerable<FileInfo> searchFiles, out FileInfo matchingFile)
        {
            matchingFile = null;
            foreach (var destFile in searchFiles)
            {
                if (AreSame(srcFile, destFile))
                {
                    matchingFile = destFile;
                    return true;
                }
            }
            return false;
        }

        private bool AreSame(FileInfo srcFile, FileInfo destFile)
        {
            return srcFile.Name == destFile.Name && srcFile.Length == destFile.Length;
        }
    }
}
