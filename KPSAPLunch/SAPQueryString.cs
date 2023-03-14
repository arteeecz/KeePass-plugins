/*
	(C) 2023 David Suchopar
*/

using KeePassLib;
using KeePassLib.Security;
using KeePassLib.Utility;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;

namespace KPSAPLunch
{
    internal class SAPQueryString
    {
        public struct queryParams
        {
            public string applicationServer;
            public string instanceNumber;
            public string systemId;
            public string sapRouter;
            public string systemClient;
            public string logonLanguage;
            public string userName;
            public string password;
        }

        private ProjectConstants.ConnectionPlaceHolders pluginParameters;

        public SAPQueryString(ProjectConstants.ConnectionPlaceHolders param)
        {
            pluginParameters = param;
        }

        public string getQueryString(queryParams p)
        {
            /*
            string queryString = "-gui=\"" + p.sapRouter + "/H/" + p.applicationServer + "/S/32" + p.instanceNumber + "\" ";
            queryString += "-system=" + p.systemId + " ";
            queryString += "-client=" + p.systemClient + " ";
            queryString += "-user=" + p.userName + " ";
            queryString += "-pw=" + p.password + " ";
            queryString += "-maxgui ";
            queryString += "lang=" + p.logonLanguage + " ";
            */

            StringBuilder arg = new StringBuilder();
            arg.Append($@"-gui=""{p.sapRouter}/H/{p.applicationServer}/S/32{p.instanceNumber}"""); arg.Append(" ");
            arg.Append($@"-system={p.systemId}"); arg.Append(" ");
            arg.Append($@"-client={p.systemClient}"); arg.Append(" ");
            arg.Append($@"-user={p.userName}"); arg.Append(" ");
            arg.Append($@"-pw={p.password}"); arg.Append(" ");
            arg.Append($@"-lang={p.logonLanguage}"); arg.Append(" ");
            arg.Append("-maxgui");

            return arg.ToString();
        }

        public queryParams getQueryParamtersFromEntry(PwEntry entry)
        {
            queryParams p = new queryParams
            {
                //mandatory palceholders
                /*
                applicationServer = entry.Strings.Get(ProjectConstants.PlaceHolders.ApplSrv.Stringify()).ReadString(),
                systemClient = entry.Strings.Get(ProjectConstants.PlaceHolders.Client.Stringify()).ReadString(),
                systemId = entry.Strings.Get(ProjectConstants.PlaceHolders.ID.Stringify()).ReadString(),
                instanceNumber = entry.Strings.Get(ProjectConstants.PlaceHolders.Number.Stringify()).ReadString(),
                sapRouter = entry.Strings.Get(ProjectConstants.PlaceHolders.SapRouter.Stringify()).ReadString(),
                userName = entry.Strings.Get(ProjectConstants.PlaceHolders.UserName.Stringify()).ReadString(),
                password = entry.Strings.Get(ProjectConstants.PlaceHolders.Password.Stringify()).ReadString()
                */


                applicationServer = entry.Strings.ReadSafe(pluginParameters.ApplSrv),
                systemClient = entry.Strings.ReadSafe(pluginParameters.Client),
                systemId = entry.Strings.ReadSafe(pluginParameters.SysID),
                instanceNumber = entry.Strings.ReadSafe(pluginParameters.Number),
                sapRouter = entry.Strings.ReadSafe(pluginParameters.SapRouter),
                userName = entry.Strings.ReadSafe(pluginParameters.Username),
                password = entry.Strings.ReadSafe(pluginParameters.Password)
            };

            //optional placeholders
            if (entry.Strings.Exists(pluginParameters.Language))
            {
                p.logonLanguage = entry.Strings.Get(pluginParameters.Language).ReadString();
            }
            else p.logonLanguage = "CS";

            return p;
        }
    }
}