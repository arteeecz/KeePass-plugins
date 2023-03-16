﻿/*
	(C) 2023 David Suchopar
*/
using KeePass.Plugins;
using System.Drawing;
using System.Windows.Forms;

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

        // Plugin parameters and default values
        private PluginParameters oParameters;

        // Plugin option handler
        private PluginOptions oOptions;

        // Event handler
        private PluginEventHandler oEvenHandler = null;

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

            // Initialize runtime
            IntInitialize(host);

            // Create instances of new column
            oColumnGui = new HotColumnProvider(oParameters);
            oColumnBC = new HotColumnProvider(oParameters);

            // Add new columns to KP
            oHost.ColumnProviderPool.Add(oColumnGui);
            oHost.ColumnProviderPool.Add(oColumnBC);

            // Get last connection params values
            //oParameters = oParameters.ToStruc(oHost.CustomConfig.GetString(OptionsConnectionParams, oParameters.GetPluginsDefaultsAsString()));

            // Register own event handler when db is saved
            oHost.MainWindow.FileSaved += oEvenHandler.OnFileSaved;

            // Get a reference to the 'Tools' menu item container
            ToolStripItemCollection oMenu = oHost.MainWindow.ToolsMenu.DropDownItems;

            // Add the popup menu item
            oMenuItem = new ToolStripMenuItem
            {
                Text = PluginParameters.menuItemText,
                ToolTipText = PluginParameters.menuItemTextTooltip,
                Image = Properties.Resources.sap_image
            };
            oMenuItem.Click += oEvenHandler.OnSettingsDlg;
            oMenu.Add(oMenuItem);

            // Initialization was succefull
            return true;
        }

        private void IntInitialize(IPluginHost host)
        {
            oHost = host;

            // Get KeePass's option handler
            oOptions = new PluginOptions(oHost.CustomConfig);

            // Get saved plugin's parammeters
            oParameters = oOptions.PluginParametersObj;

            // Inicialize event handler
            oEvenHandler = new PluginEventHandler(oParameters, oOptions);
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

            // Remove event handler (important!)
            oHost.MainWindow.FileSaved -= oEvenHandler.OnFileSaved;

            // Remove menu items
            ToolStripItemCollection oMenu = oHost.MainWindow.ToolsMenu.DropDownItems;

            if (oMenuItem != null)
            {
                // Unregister event handler
                oMenuItem.Click -= oEvenHandler.OnSettingsDlg;
                oMenu.Remove(oMenuItem);
            }

            oHost = null;

            base.Terminate();
        }
    }
}
