using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CopyRequiredDlls
{
    class Program
    {
        static void CopyFiles(string destinationFolder, List<string> files)
        {
            for (int iNum = 0; iNum < files.Count; ++iNum)
            {
                string filename = Path.GetFileName(files[iNum]);
                string destinationFile = Path.Combine(destinationFolder, filename);
                File.Copy(files[iNum], destinationFile, true);
            }
        }

        static void Opetion_2()
        {
            Console.WriteLine("======== Opetion 2 =============");
            Console.WriteLine("All Active Process Below");

            List<string> process;
            FilesFinder.GetAllActiveProcessName(out process);

            if (process.Count == 0)
            {
                Console.WriteLine("Process Not Found");
                return;
            }

            for (int iNum = 0; iNum < process.Count; ++iNum)
            {
                Console.WriteLine(iNum.ToString() + ":\t " + process[iNum]);
            }

            Console.WriteLine(" ");
            Console.WriteLine("Get Process Index ");
            string indexS = Console.ReadLine();
            int index = Int32.Parse(indexS);
            if (index > process.Count || index <= 0)
            {
                Console.WriteLine("Out off Index");
                return;
            }

            FilesFinder pFilesFinder = new FilesFinder(process[index]);
            List<string> files;
            pFilesFinder.Execute(out files);

            Console.WriteLine(" ");
            Console.WriteLine("Give Destination folder Path ");
            string destinationFolder = Console.ReadLine();

            CopyFiles(destinationFolder, files);

            Console.WriteLine(" ");
            Console.WriteLine("File Copied! Congrats");
            Console.Read();
        }

        static void Opetion_1()
        {
            Console.WriteLine("======== Opetion 1=============");
            Console.WriteLine("Give Program - Process name");
            string processName = Console.ReadLine();

            FilesFinder pFilesFinder = new FilesFinder(processName);
            List<string> files;
            pFilesFinder.Execute(out files);

            if (files.Count == 0)
            {
                Console.WriteLine("Process Not Found");
                return;
            }

            Console.WriteLine(" ");
            Console.WriteLine("Give Destination folder Path ");
            string destinationFolder = Console.ReadLine();
            CopyFiles(destinationFolder, files);

            Console.WriteLine(" ");
            Console.WriteLine("File Copied! Congrats");
            Console.Read();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("Choose Opetion:");
            Console.WriteLine(" 1. Copy Program file from name");
            Console.WriteLine(" 2. Copy Program file from index(names shown on screen)");
            Console.WriteLine("");
            string opetion = Console.ReadLine();
            int option = Int32.Parse(opetion);
            if (option == 1)
            {
                Opetion_1();
            }
            else if (option == 2)
            {
                Opetion_2();
            }
        }
    }
}
