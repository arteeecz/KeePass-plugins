/*
	(C) 2023 David Suchopar
*/

using KeePass.Plugins;
using System.Text.Json;

namespace KPSAPLunch
{
    internal class ProjectConstants
    {  

        public const string SAPGUIShortCutEXE = "sapshcut.exe";
        public const string SAPNWBCShortCutEXE = "NWBC.exe";

        // Menu texts
        public const string menuItemText = "KPSAPLunch options...";
        public const string menuItemTextTooltip = "";

        // Initialize empty params var
        public ConnectionPlaceHolders placeHolders = new ConnectionPlaceHolders(false);

        /// <summary>
        /// Structure holds all placeholders used in connection string
        /// </summary>
        public struct ConnectionPlaceHolders
        {
            public string ApplSrv;
            public string Client;
            public string SysID;
            public string Number;
            public string SapRouter;
            public string Language;
            public readonly string Username;
            public readonly string Password;

            /// <summary>
            /// Structure constructor
            /// </summary>
            /// <param name="empty"></param>Determine if new varibale will contain default values
            public ConnectionPlaceHolders(bool empty = false) {

                if (empty)
                {
                    ApplSrv = string.Empty;
                    Client = string.Empty;
                    SysID = string.Empty;
                    Number = string.Empty;
                    SapRouter = string.Empty;
                    Language = string.Empty;
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
                    Username = "UserName";
                    Password = "Password";
                }
            }

            public string Stringify()
            {
                return JsonSerializer.Serialize(this);
            }

            public ConnectionPlaceHolders ToStruc(string str)
            {
                return JsonSerializer.Deserialize<ConnectionPlaceHolders>(str);
            }
        }
        /// <summary>
        /// Return default names of placeholders
        /// </summary>
        /// <returns>JSON representation of struc</returns>
        public string GetPluginsDefaultsAsString()
        {
            ConnectionPlaceHolders sPar = new ConnectionPlaceHolders();
            return sPar.Stringify();
        }
    }
}
