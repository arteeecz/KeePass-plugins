/*
	(C) 2023 David Suchopar
*/

using KeePass.App.Configuration;

namespace KPSAPLunch
{
    public class PluginOptions
    {
        private readonly AceCustomConfig oKeePassConfig = null;

        private const string pluginOptions = KPSAPLunchExt.PlugInName + "-" + "PluginOptionString";

        public PluginOptions(AceCustomConfig config)
        {
            oKeePassConfig = config;
        }

        public string PluginOptionString
        {
            get
            {
                string savedStr = oKeePassConfig.GetString(pluginOptions);
                if (string.IsNullOrEmpty(savedStr)) { savedStr = new PluginParameters(false).GetPluginsDefaultsAsString(); }
                return savedStr;
            }

            set
            {
                oKeePassConfig.SetString(pluginOptions, value);
            }
        }

        public PluginParameters PluginParametersObj
        {
            get
            {
                var oParam = new PluginParameters(true);
                return oParam.ToStruc(PluginOptionString);
            }
            set
            {
                oKeePassConfig.SetString(pluginOptions, PluginOptionString);
            }
        }
    }
}