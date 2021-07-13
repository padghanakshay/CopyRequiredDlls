using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CopyRequiredDlls
{
    class FilesFinder
    {
        private string m_processName;

        public FilesFinder(string processName)
        {
            m_processName = processName;
        }

        public static void GetAllActiveProcessName(out List<string> names)
        {
            names = new List<string>();
            Process[] allProcess = Process.GetProcesses();
            for (int iNum = 0; iNum < allProcess.Length; ++iNum)
            {
                Process pProcess = allProcess[iNum];
                string name = pProcess.MainWindowTitle;
                if (string.IsNullOrEmpty(name))
                    continue;

                names.Add(name);
            }
        }

        // Execute All files
        public void Execute(out List<string> files)
        {
            files = new List<string>();
            Process[] allProcess = Process.GetProcesses();

            Process pValidProcess = null;

            for (int iNum = 0; iNum < allProcess.Length; ++iNum)
            {
                Process pProcess = allProcess[iNum];
                string name = pProcess.MainWindowTitle;

                if (m_processName == name)
                {
                    pValidProcess = pProcess;
                    break;
                }
            }

            if (pValidProcess == null)
            {
                for (int iNum = 0; iNum < allProcess.Length; ++iNum)
                {
                    Process pProcess = allProcess[iNum];
                    string name = pProcess.MainWindowTitle;

                    if (name.IndexOf(m_processName) >= 0)
                    {
                        pValidProcess = pProcess;
                        break;
                    }
                }
            }

            ProcessModuleCollection moduleCollection = pValidProcess.Modules;
            for (int iNum = 0; iNum < moduleCollection.Count; ++iNum)
            {
                ProcessModule pProcessModule = moduleCollection[iNum];
                string filePath = pProcessModule.FileName;
                files.Add(filePath);
            }
        }

    }
}
