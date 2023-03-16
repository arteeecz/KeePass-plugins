/*
	(C) 2023 David Suchopar
*/

using KeePassLib;
using System.Text;

namespace KPSAPLunch
{
    internal class SAPQueryString
    {
        public struct QueryParams
        {
            public string applicationServer;
            public string instanceNumber;
            public string systemId;
            public string sapRouter;
            public string systemClient;
            public string logonLanguage;
            public string runCommand;
            public string userName;
            public string password;
            public bool maxGui;
        }

        private PluginParameters pluginParameters;

        public SAPQueryString(PluginParameters param)
        {
            pluginParameters = param;
        }

        public string GetQueryString(QueryParams p)
        {
            /*
            StringBuilder arg = new StringBuilder();
            arg.Append($@"-gui=""{p.sapRouter}/H/{p.applicationServer}/S/32{p.instanceNumber}"""); arg.Append(" ");
            arg.Append($@"-system={p.systemId}"); arg.Append(" ");
            arg.Append($@"-client={p.systemClient}"); arg.Append(" ");
            arg.Append($@"-user={p.userName}"); arg.Append(" ");
            arg.Append($@"-pw={p.password}"); arg.Append(" ");
            if (!string.IsNullOrEmpty(p.logonLanguage)) { arg.Append($@"-lang={p.logonLanguage}"); arg.Append(" "); }
            if (!string.IsNullOrEmpty(p.runCommand)) { arg.Append($@"-command={p.runCommand}"); arg.Append(" "); }
            if (p.maxGui) { arg.Append("-maxgui"); }
            */

            StringBuilder arg = new StringBuilder();
            arg.Append("-gui=\"" + p.sapRouter + "/H/" + p.applicationServer + "/S/32" + p.instanceNumber + "\""); arg.Append(" ");
            arg.Append("-system=" + p.systemId); arg.Append(" ");
            arg.Append("-client=" + p.systemClient); arg.Append(" ");
            arg.Append("-user=" + p.userName); arg.Append(" ");
            arg.Append("-pw=" + p.password); arg.Append(" ");
            if (!string.IsNullOrEmpty(p.logonLanguage)) { arg.Append("-lang=" + p.logonLanguage); arg.Append(" "); }
            if (!string.IsNullOrEmpty(p.runCommand)) { arg.Append("-command=" + p.runCommand); arg.Append(" "); }
            if (p.maxGui) { arg.Append("-maxgui"); }

            return arg.ToString();
        }

        public QueryParams GetQueryParamtersFromEntry(PwEntry entry)
        {
            QueryParams p = new QueryParams
            {
                // Mandatory palceholders
                applicationServer = entry.Strings.ReadSafe(pluginParameters.ApplSrv),
                systemClient = entry.Strings.ReadSafe(pluginParameters.Client),
                systemId = entry.Strings.ReadSafe(pluginParameters.SysID),
                instanceNumber = entry.Strings.ReadSafe(pluginParameters.Number),
                sapRouter = entry.Strings.ReadSafe(pluginParameters.SapRouter),
                userName = entry.Strings.ReadSafe(pluginParameters.Username),
                password = entry.Strings.ReadSafe(pluginParameters.Password),
                runCommand = entry.Strings.ReadSafe(pluginParameters.Transaction),
                logonLanguage = entry.Strings.ReadSafe(pluginParameters.Language),
                maxGui = pluginParameters.isMaxGui
            };

            /*
            // Optional placeholders
            if (entry.Strings.Exists(pluginParameters.Language))
            {
                p.logonLanguage = entry.Strings.Get(pluginParameters.Language).ReadString();
            }
            else p.logonLanguage = "CS";
            */

            return p;
        }
    }
}