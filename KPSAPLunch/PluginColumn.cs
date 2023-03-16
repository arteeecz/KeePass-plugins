/*
	(C) 2023 David Suchopar
*/

using KeePassLib;

namespace KPSAPLunch
{
    /// <summary>
    /// Abstract class of plugin's column with mandatory functionality
    /// </summary>
    public abstract class PluginColumn : IPluginColumn
    {
        protected string Name;
        protected string Title;
        protected PluginParameters pluginParameters;

        public PluginColumn(string name, PluginParameters pluginParameters)
        {
            Name = name;
            Title = string.Empty;
            this.pluginParameters = pluginParameters;
        }

        public string GetName() { return Name; }
        public string GetTitle() { return Title; }

        public string GetContent(PwEntry entry) { return GetContentInt(entry); }

        public bool HasAction() { return true; }

        public void PerformAction(PwEntry entry) { PerformActionInt(entry); }

        protected virtual string GetContentInt(PwEntry entry) { return string.Empty; }
        protected virtual void PerformActionInt(PwEntry entry) { }

        protected bool IsEntryExecutable(PwEntry entry)
        {
            int count = 0;
            if (entry.Strings.Exists(pluginParameters.ApplSrv)) { count++; }
            if (entry.Strings.Exists(pluginParameters.Client)) { count++; }
            if (entry.Strings.Exists(pluginParameters.SysID)) { count++; }
            if (entry.Strings.Exists(pluginParameters.Number)) { count++; }
            if (entry.Strings.Exists(pluginParameters.SapRouter)) { count++; }

            // If exist at least two placeholders used by plugin entry has executable potencial
            if (count > 1)
            {
                // Check binary
                if (
                    ((Name == KPSAPLunchExt.ColNBCName) && !string.IsNullOrEmpty(pluginParameters.nBCPath)) ||
                    ((Name == KPSAPLunchExt.ColGuiName) && !string.IsNullOrEmpty(pluginParameters.sapGuiPath))
                    ) { return true; }
                else { return false; }
            }
            else { return false; }
        }
    }

    /// <summary>
    /// SAP GUI column
    /// </summary>
    public class PluginColumnGui : PluginColumn
    {
        public PluginColumnGui(string name, PluginParameters pluginParameters) : base(name, pluginParameters) { Title = "GUI"; }

        protected override string GetContentInt(PwEntry entry)
        {
            if (IsEntryExecutable(entry))
            {
                return "▶";
            }
            else
            {
                return string.Empty;
            }

        }

        protected override void PerformActionInt(PwEntry entry)
        {
            var oQuery = new SAPQueryString(pluginParameters);

            if (new SAPBinaries().DoLogon(pluginParameters.sapGuiPath + PluginParameters.SAPGUIShortCutEXE, oQuery.GetQueryString(oQuery.GetQueryParamtersFromEntry(entry))))
            { };
        }
    }

    /// <summary>
    /// SAP Business Client column
    /// </summary>
    public class PluginColumnBC : PluginColumn
    {
        public PluginColumnBC(string name, PluginParameters pluginParameters) : base(name, pluginParameters) { Title = "BC"; }

        protected override string GetContentInt(PwEntry entry)
        {
            if (IsEntryExecutable(entry))
            {
                return "▶";
            }
            else
            {
                return string.Empty;
            }
        }

        protected override void PerformActionInt(PwEntry entry)
        {
            var oQuery = new SAPQueryString(pluginParameters);

            if (new SAPBinaries().DoLogon(pluginParameters.nBCPath + PluginParameters.SAPNWBCShortCutEXE, "/SHORTCUT=\"" + oQuery.GetQueryString(oQuery.GetQueryParamtersFromEntry(entry)) + "\""))
            { };
        }
    }
}