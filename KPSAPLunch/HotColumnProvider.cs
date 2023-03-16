/*
	(C) 2023 David Suchopar
*/

using KeePass.UI;
using KeePassLib;
using KeePassLib.Utility;
using System.Diagnostics;
using System.IO;

namespace KPSAPLunch
{
    internal class HotColumnProvider : ColumnProvider
    {
        private const string sapGuiColumnName = "SAPGui";
        private const string bussinesClientColumnName = "BClient";
        private SAPQueryString oQuery = null;
        private PluginParameters pluginParameters;

        public override string[] ColumnNames
        {
            get { return new string[] { sapGuiColumnName, bussinesClientColumnName }; }
        }

        public HotColumnProvider(PluginParameters param)
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
            if (pe != null)
            {

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

                SAPBinaries oExec = new SAPBinaries();

                switch (strColumnName)
                {
                    case sapGuiColumnName:
                        DoLogon(oExec.DetectSAPGUIPath(PluginParameters.SAPGUIShortCutEXE) + PluginParameters.SAPGUIShortCutEXE, oQuery.GetQueryString(oQuery.GetQueryParamtersFromEntry(pe)));
                        break;
                    case bussinesClientColumnName:
                        //DoLogon(oExec.DetectSAPGUIPath(PluginParameters.SAPNWBCShortCutEXE) + PluginParameters.SAPNWBCShortCutEXE, $@"/SHORTCUT=""{oQuery.GetQueryString(oQuery.GetQueryParamtersFromEntry(pe))}""");
                        DoLogon(oExec.DetectSAPGUIPath(PluginParameters.SAPNWBCShortCutEXE) + PluginParameters.SAPNWBCShortCutEXE, "/SHORTCUT=\"" + oQuery.GetQueryString(oQuery.GetQueryParamtersFromEntry(pe)) + "\"");
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
    }
}
