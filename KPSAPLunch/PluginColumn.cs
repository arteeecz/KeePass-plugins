/*
	(C) 2023 David Suchopar
*/

using KeePassLib;
using System;
using System.Runtime.Remoting.Messaging;

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

        public string GetContent() { return GetContentInt(); }

        public bool HasAction() { return true; }

        public void PerformAction(PwEntry entry){ PerformActionInt(entry); }

        protected virtual string GetContentInt() { return "run"; }
        protected virtual void PerformActionInt(PwEntry entry) { }
    }

    /// <summary>
    /// SAP GUI column
    /// </summary>
    public class PluginColumnGui : PluginColumn
    {
        public PluginColumnGui(string name, PluginParameters pluginParameters) : base(name,pluginParameters)  { Title = "GUI"; }

        protected override string GetContentInt() { return "▶"; }

        protected override void PerformActionInt(PwEntry entry)
        {
            var oExec = new SAPBinaries();
            var oQuery = new SAPQueryString(pluginParameters);

            if (oExec.DoLogon(oExec.DetectSAPGUIPath(PluginParameters.SAPGUIShortCutEXE) + PluginParameters.SAPGUIShortCutEXE, oQuery.GetQueryString(oQuery.GetQueryParamtersFromEntry(entry))))
            { };
        }
    }

    /// <summary>
    /// SAP Business Client column
    /// </summary>
    public class PluginColumnBC : PluginColumn
    { 
        public PluginColumnBC(string name, PluginParameters pluginParameters) : base(name, pluginParameters) { Title = "BC"; }

        protected override string GetContentInt() { return "▶"; }

        protected override void PerformActionInt(PwEntry entry)
        {
            var oExec = new SAPBinaries();
            var oQuery = new SAPQueryString(pluginParameters);

            if (oExec.DoLogon(oExec.DetectSAPGUIPath(PluginParameters.SAPNWBCShortCutEXE) + PluginParameters.SAPNWBCShortCutEXE, "/SHORTCUT=\"" + oQuery.GetQueryString(oQuery.GetQueryParamtersFromEntry(entry)) + "\""))
            { };
        }
    }
}