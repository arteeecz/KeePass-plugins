/*
	(C) 2023 David Suchopar
*/

using KeePass.UI;
using KeePassLib;
using KeePassLib.Utility;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System;

namespace KPSAPLunch
{
    internal class HotColumnProvider : ColumnProvider
    {
        private const string sapGuiColumnName = "SAPGui";
        private const string bussinesClientColumnName = "BClient";
        private SAPQueryString oQuery = null;
        private ProjectConstants.ConnectionPlaceHolders pluginParameters;

        public override string[] ColumnNames
        {
            get { return new string[] { sapGuiColumnName, bussinesClientColumnName }; }
        }

        public HotColumnProvider(ProjectConstants.ConnectionPlaceHolders param)
        {
            pluginParameters = param;
        }

        /// <summary>
        /// Get column content - in this version will be only text
        /// </summary>
        /// <param name="strColumnName"></param>
        /// <param name="pe"></param>
        /// <returns></returns>
        public override string GetCellData(string strColumnName, PwEntry pe)
        {
            switch (strColumnName)
            {
                case sapGuiColumnName:
                    return sapGuiColumnName;
                case bussinesClientColumnName:
                    return bussinesClientColumnName;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Enable hotspot on cell
        /// </summary>
        /// <param name="strColumnName"></param>
        /// <returns></returns>
        public override bool SupportsCellAction(string strColumnName)
        { 
            switch (strColumnName)
            {
                case sapGuiColumnName:
                    return true;
                case bussinesClientColumnName:
                    return true;
                default:
                    return base.SupportsCellAction(strColumnName);
            }
        }

        /// <summary>
        /// Concat CLI string and run
        /// </summary>
        /// <param name="strColumnName"></param>
        /// <param name="pe"></param>
        public override void PerformCellAction(string strColumnName, PwEntry pe)
        {
            if (pe != null) {

                bool error = false;
                string sMessage = string.Empty;

                oQuery = new SAPQueryString(pluginParameters);


                //check if all placeholder are pressent
                if (!pe.Strings.Exists(pluginParameters.ApplSrv)) { error = true; sMessage += pluginParameters.ApplSrv + "\n"; }
                if (!pe.Strings.Exists(pluginParameters.Client)) { error = true; sMessage += pluginParameters.Client + "\n"; }
                if (!pe.Strings.Exists(pluginParameters.SysID)) { error = true; sMessage += pluginParameters.SysID + "\n"; }
                if (!pe.Strings.Exists(pluginParameters.Number)) { error = true; sMessage += pluginParameters.Number + "\n"; }
                if (!pe.Strings.Exists(pluginParameters.SapRouter)) { error = true; sMessage += pluginParameters.SapRouter + "\n"; }

                if (error) { MessageService.ShowFatal("Missing placeholders:\n" + sMessage); return; }
                
                switch (strColumnName)
                {
                    case sapGuiColumnName:
                        //_ = NativeLib.RunConsoleApp("sapshcut", oQuery.getQueryString(oQuery.getQueryParamtersFromEntry(pe)));
                        _ = DoLogon(DetectSAPGUIPath(ProjectConstants.SAPGUIShortCutEXE) + ProjectConstants.SAPGUIShortCutEXE, oQuery.getQueryString(oQuery.getQueryParamtersFromEntry(pe)));
                        break;
                    case bussinesClientColumnName:
                        //_ = NativeLib.RunConsoleApp("nwbc.exe", "/ SHORTCUT =\"" + oQuery.getQueryString(oQuery.getQueryParamtersFromEntry(pe)) + "\"");
                        _ = DoLogon(DetectSAPGUIPath(ProjectConstants.SAPNWBCShortCutEXE) + ProjectConstants.SAPNWBCShortCutEXE, $@"/SHORTCUT=""{oQuery.getQueryString(oQuery.getQueryParamtersFromEntry(pe))}""");
                        break;
                    default:
                        base.PerformCellAction(strColumnName, pe);
                        break;
                }
            }
        }

        private bool DoLogon(string exeName, string queryString)
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

        #region SAPLOGON
        private string DetectSAPGUIPath(string exec)
        {
            RegistryKey rootKey = RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, "");
            RegistryKey subKey = null;

            bool foundPath = true;
            object objPath;
            string sPath = "";
            string resPath = "";

            try
            {
                // Check path from registry for x86
                subKey = rootKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\" + exec);
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
                    // Check path from registry for 64bit
                    subKey = rootKey.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\" + exec);
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
                MessageService.ShowFatal("SAPGUI not installed!", KPSAPLunchExt.PlugInName + " settings error");
            }

            return resPath;

        } //DetectSAPGUIPath
        
        private bool ValidateSAPGUIPath(string path, string exec)
        {
            //Validating if 'sapshcut.exe' located by given path
            string fileLoc = Path.Combine(path, exec);
            FileInfo fileInfo = new FileInfo(fileLoc);
            return (fileInfo.Exists);
        }
        #endregion
    }
}
