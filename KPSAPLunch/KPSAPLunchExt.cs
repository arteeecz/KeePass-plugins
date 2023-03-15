/*
	(C) 2023 David Suchopar
*/
using System.Windows.Forms;
using System.Drawing;
using KeePass.Plugins;

namespace KPSAPLunch
{
    public sealed class KPSAPLunchExt : Plugin
    {
        // Plugin name constant
        public const string PlugInName = "KPSAPLunch";

        // Remember plugin's host instance
        public static IPluginHost oHost = null;

        // Atribute holds app menu context
        private ToolStripMenuItem oMenuItem = null;

        // Prepare refernces for plugin's column
        private HotColumnProvider oColumnGui = null;
        private HotColumnProvider oColumnBC = null;

        // Project constants and default values
        private ProjectConstants oParameters = new ProjectConstants();

        // Option dialog class
        private PluginOptions oOptions = null;
        
        // Event handler
        private PluginEventHandler oEvenHandler = new PluginEventHandler();

        // Name of the configuration option
        private const string OptionsConnectionParams = "KPSAPLunch_ConnectionParams";

        // Set plugin's icon
        public override Image SmallIcon { get { return Properties.Resources.sap_image; } }

        // Set URL for version check
        public override string UpdateUrl { get { return Properties.Resources.URLVersionCheck; } }

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

            // Create instances of new column
            oColumnGui = new HotColumnProvider(oParameters.placeHolders);
            oColumnBC = new HotColumnProvider(oParameters.placeHolders);

            // Add new columns to KP
            oHost.ColumnProviderPool.Add(oColumnGui);
            oHost.ColumnProviderPool.Add(oColumnBC);

            // Get last connection params values
            oParameters.placeHolders = oParameters.placeHolders.ToStruc(oHost.CustomConfig.GetString(OptionsConnectionParams, oParameters.GetPluginsDefaultsAsString()));

            // Register own event handler when db is saved
            oHost.MainWindow.FileSaved += oEvenHandler.OnFileSaved;

            // Get a reference to the 'Tools' menu item container
            ToolStripItemCollection oMenu = oHost.MainWindow.ToolsMenu.DropDownItems;

            // Add the popup menu item
            oMenuItem = new ToolStripMenuItem();
            oMenuItem.Text = ProjectConstants.menuItemText;
            oMenuItem.ToolTipText = ProjectConstants.menuItemTextTooltip;
            oMenuItem.Image = Properties.Resources.sap_image;
            oMenuItem.Click += oEvenHandler.OnSettingsDlg;
            oMenu.Add(oMenuItem);

            // Initialization was succefull
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
