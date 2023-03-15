/*
	(C) 2023 David Suchopar
*/

using KeePass.App.Configuration;

namespace KPSAPLunch
{
    public class PluginOptions
    {
        private readonly AceCustomConfig config = null;

        public PluginOptions(AceCustomConfig config)
        {
            this.config = config;
        }
    }
}