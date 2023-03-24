/*
	(C) 2023 David Suchopar
*/

using KeePassLib.Utility;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace KPSAPLunch
{
    public class SAPBinaries
    {
        public string DetectSAPGUIPath(string exec)
        {
            RegistryKey rootKey = RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, "");

            bool foundPath = true;
            object objPath;
            string sPath = "";
            string resPath = "";

            try
            {
                // Check path from registry for x86
                RegistryKey subKey = rootKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\" + exec);
                objPath = subKey.GetValue("Path");
                sPath = Convert.ToString(objPath);
            }
            catch
            {
                foundPath = false;
            };

            if (!foundPath)
            {
                try
                {
                    // Check path from registry for amd64
                    RegistryKey subKey = rootKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\" + exec);
                    objPath = subKey.GetValue("Path");
                    sPath = Convert.ToString(objPath);
                }
                catch
                {
                    foundPath = false;
                }
            }

            if (foundPath)
            {
                for (int i = 0; ((i < sPath.Length) && (sPath[i] != ';')); i++)
                {
                    resPath += sPath[i].ToString();
                }

                if (resPath.Length < 3)  // "C:\"
                {
                    foundPath = false;
                }
                else
                {
                    if (ValidateSAPGUIPath(resPath, exec)) return resPath + "\\";
                }
            }
            else
            {
                //MessageService.ShowFatal(exec + " not installed!", KPSAPLunchExt.PlugInName + " settings error");
            }

            return resPath;

        }

        private bool ValidateSAPGUIPath(string path, string exec)
        {
            // Validating if binary located by given path
            string fileLoc = Path.Combine(path, exec);
            FileInfo fileInfo = new FileInfo(fileLoc);
            return (fileInfo.Exists);
        }

        public bool DoLogon(string exeName, string queryString)
        {
            if (string.IsNullOrEmpty(exeName)) { return false; }

            FileInfo fileInfo = new FileInfo(exeName);
            ProcessStartInfo info = new ProcessStartInfo(fileInfo.FullName)
            {
                Arguments = queryString,
                CreateNoWindow = false,
                UseShellExecute = true,
                ErrorDialog = true,
                RedirectStandardInput = false,
                RedirectStandardOutput = false
            };

            Process process = Process.Start(info);

            return !process.HasExited;
        }
    }
}
