/*
	(C) 2023 David Suchopar
*/
using System.Drawing;
using KeePass.Plugins;

namespace KPSAPLunch
{
    public sealed class KPSAPLunchExt : Plugin
    {
        //plugin name constant
        public const string PlugInName = "KPSAPLunch";

        //remember plugin's host instance
        private static IPluginHost oHost = null;

        //prepare refernces for plugin's column
        private HotColumnProvider oColumnGui = null;
        private HotColumnProvider oColumnBC = null;

        //project constants and default values
        private ProjectConstants oParameters = new ProjectConstants();
        //event handler
        private PluginEventHandler oEvenHandler = new PluginEventHandler();

        //name of the configuration option
        private const string OptionsConnectionParams = "KPSAPLunch_ConnectionParams";

        //set plugin's icon
        public override Image SmallIcon { get { return KPSAPLunch.Properties.Resources.sap_image; } }

        /// <summary>
        /// KP constructor called when plugin is loaded
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public override bool Initialize(IPluginHost host)
        {
            Terminate();

            if (host == null) { return false; }
            oHost = host;

            //create instances of new column
            oColumnGui = new HotColumnProvider(oParameters.placeHolders);
            oColumnBC = new HotColumnProvider(oParameters.placeHolders);

            //add new columns to KP
            oHost.ColumnProviderPool.Add(oColumnGui);
            oHost.ColumnProviderPool.Add(oColumnBC);

            //get last connection params values
            oParameters.placeHolders = oParameters.placeHolders.ToStruc(oHost.CustomConfig.GetString(OptionsConnectionParams, oParameters.GetPluginsDefaultsAsString()));

            //register own event handler when db is saved
            oHost.MainWindow.FileSaved += oEvenHandler.OnFileSaved;

            //Initialization was succefull
            return true;
        }

        /// <summary>
		/// The <c>Terminate</c> method is called by KeePass when
		/// you should free all resources, close files/streams,
		/// remove event handlers, etc.
		/// </summary>
        public override void Terminate()
        {
            if (oHost == null) return;

            oHost.ColumnProviderPool.Remove(oColumnGui);
            oColumnGui = null;

            oHost.ColumnProviderPool.Remove(oColumnBC);
            oColumnBC = null;

            oHost = null;

            // Save the state of plugin parameters
            oHost.CustomConfig.SetString(OptionsConnectionParams, oParameters.placeHolders.Stringify());

            // Remove event handler (important!)
            oHost.MainWindow.FileSaved -= oEvenHandler.OnFileSaved;

            base.Terminate();
        }
    }
}
