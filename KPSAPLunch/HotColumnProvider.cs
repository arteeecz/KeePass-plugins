/*
	(C) 2023 David Suchopar
*/

using KeePass.UI;
using KeePassLib;
using KeePassLib.Utility;
using System.Collections.Generic;
using System.Linq;

namespace KPSAPLunch
{
    internal class HotColumnProvider : ColumnProvider
    {
        private PluginParameters pluginParameters;
        private Dictionary<string, IPluginColumn> Columns = new Dictionary<string, IPluginColumn>();

        public override string[] ColumnNames
        {
            get { return Columns.Keys.ToArray(); }
        }

        public HotColumnProvider(string column, PluginParameters param)
        {
            pluginParameters = param;

            switch (column)
            {
                case KPSAPLunchExt.ColGuiName:
                    Columns.Add(column, new PluginColumnGui(column, pluginParameters));
                    break;
                case KPSAPLunchExt.ColNBCName:
                    Columns.Add(column, new PluginColumnBC(column, pluginParameters));
                    break;
            }
        }

        public override string GetCellData(string strColumnName, PwEntry pe)
        {
            return Columns[strColumnName].GetContent(pe);
        }

        public override bool SupportsCellAction(string strColumnName)
        {
            return Columns[strColumnName].HasAction();
        }

        public override void PerformCellAction(string strColumnName, PwEntry pe)
        {
            if (pe != null)
            {
                bool error = false;
                string sMessage = string.Empty;

                // Check if all mandatory placeholder are pressent
                if (!pe.Strings.Exists(pluginParameters.ApplSrv)) { error = true; sMessage += pluginParameters.ApplSrv + "\n"; }
                if (!pe.Strings.Exists(pluginParameters.Client)) { error = true; sMessage += pluginParameters.Client + "\n"; }
                if (!pe.Strings.Exists(pluginParameters.SysID)) { error = true; sMessage += pluginParameters.SysID + "\n"; }
                if (!pe.Strings.Exists(pluginParameters.Number)) { error = true; sMessage += pluginParameters.Number + "\n"; }
                if (!pe.Strings.Exists(pluginParameters.SapRouter)) { error = true; sMessage += pluginParameters.SapRouter + "\n"; }

                if (error) { MessageService.ShowFatal("Missing placeholders:\n" + sMessage); return; }

                Columns[strColumnName].PerformAction(pe);
            }
        }
    }
}
