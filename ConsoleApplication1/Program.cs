using MyBackupTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MissingFileDector comparer = new MissingFileDector();
            var srcDir = @"I:\xJohn\Documents";
            var destDir = @"E:\Documents\Dropbox\Doc";
            var missingFiles = comparer.Compare(srcDir, destDir);

            if (missingFiles.Any())
            {
                foreach (var missingFile in missingFiles)
                {
                    Console.WriteLine(missingFile.FullName);
                }
            }
            else
            {
                Console.WriteLine("No missing files!!!");
            }
            Console.ReadKey();
        }
    }
}
