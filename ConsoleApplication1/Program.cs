using MyBackupTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream stream = new FileStream(@"d:\temp\summerintern.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    Console.SetOut(writer);
                    MissingFileDector comparer = new MissingFileDector();
                    var srcDir = @"I:\xJohn\Documents\Summer Internship";
                    var destDir = @"E:\Documents\Dropbox\Doc\Summer Internship";
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
                }
            }
        }
    }
}
