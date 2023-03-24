/*
	(C) 2023 David Suchopar
*/

using System;

namespace KPSAPLunch
{
    public class PluginParameters
    {
        public string ApplSrv;
        public string Client;
        public string SysID;
        public string Number;
        public string SapRouter;
        public string Language;
        public string Transaction;
        public bool isMaxGui;
        public readonly string Username;
        public readonly string Password;
        public string sapGuiPath;
        public string nBCPath;
        public string SAPGuiPath;
        public string SAPNWBCPath;

        public const string SAPGUIShortCutEXE = "sapshcut.exe";
        public const string SAPNWBCShortCutEXE = "NWBC.exe";

        // Menu texts
        public const string menuItemText = "KPSAPLunch options...";
        public const string menuItemTextTooltip = "";

        /// <summary>
        /// Structure constructor
        /// </summary>
        /// <param name="empty">Determine if new varibale will contain default values</param>
        public PluginParameters(bool empty = false)
        {

            if (empty)
            {
                ApplSrv = string.Empty;
                Client = string.Empty;
                SysID = string.Empty;
                Number = string.Empty;
                SapRouter = string.Empty;
                Language = string.Empty;
                Transaction = string.Empty;
                isMaxGui = true;
                Username = "UserName";
                Password = "Password";
            }
            else
            {
                ApplSrv = "ApplSrv";
                Client = "Client";
                SysID = "ID";
                Number = "Number";
                SapRouter = "SapRouter";
                Language = "Language";
                Transaction = "Transaction";
                isMaxGui = true;
                Username = "UserName";
                Password = "Password";
            }
        }

        public override string ToString()
        {
            return "ApplSrv:" + ApplSrv + ";" +
            "Client:" + Client + ";" +
            "SysID:" + SysID + ";" +
            "Number:" + Number + ";" +
            "SapRouter:" + SapRouter + ";" +
            "Language:" + Language + ";" +
            "Transaction:" + Transaction + ";" +
            "Username:" + Username + ";" +
            "Password:" + Password + ";" +
            "isMaxGui:" + isMaxGui + ";" +
            "SAPGUIPath:" + SAPGuiPath + ";" +
            "SAPNWBCPath:" + SAPNWBCPath;
        }

        /// <summary>
        /// Return default names of placeholders
        /// </summary>
        /// <returns>JSON representation of struc</returns>
        public string GetPluginsDefaultsAsString()
        {
            PluginParameters connectionPlaceHolders = new PluginParameters(false);
            return connectionPlaceHolders.ToString();
        }

        public PluginParameters ToStruc(string str)
        {
            PluginParameters connectionPlaceHolders = new PluginParameters(true);

            if (str == null) { return connectionPlaceHolders; }

            Array arr = str.Split(';');
            foreach (string item in arr)
            {
                Array par = item.Split(':');
                if (par.Length > 1)
                {
                    if (typeof(PluginParameters).GetField(par.GetValue(0).ToString()).FieldType == typeof(bool))
                    {
                        typeof(PluginParameters).GetField(par.GetValue(0).ToString()).SetValue(connectionPlaceHolders, par.GetValue(1).ToString() == "True");
                    }
                    else if (typeof(PluginParameters).GetField(par.GetValue(0).ToString()).FieldType == typeof(string))
                    {
                        typeof(PluginParameters).GetField(par.GetValue(0).ToString()).SetValue(connectionPlaceHolders, par.GetValue(1).ToString());
                    }
                }
            }

            return connectionPlaceHolders;
        }
    }
}
