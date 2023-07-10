/*
	(C) 2023 David Suchopar
*/
using KeePass.Plugins;
using System.Drawing;
using System.Windows.Forms;

namespace KPSAPLunch
{
    public sealed class KPSAPLunchExt : Plugin
    {
        #region Public section
        // Plugin name constant
        public const string PlugInName = "KPSAPLunch";

        // Name of the columns
        public const string ColGuiName = "Gui";
        public const string ColNBCName = "NBC";

        // Remember plugin's host instance
        public static IPluginHost oHost = null;

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
            InitGlobals(host);

            //Create columns
            InitColumns();

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
        #endregion

        #region Protected section

        #endregion

        #region Private section
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

        private void InitGlobals(IPluginHost host)
        {
            oHost = host;

            // Get KeePass option handler
            oOptions = new PluginOptions(oHost.CustomConfig);

            // Get saved plugin parammeters
            if (oOptions.PluginParametersObj == null)
            {
                oParameters = new PluginParameters();
            }
            else
            {
                oParameters = oOptions.PluginParametersObj;
            }

            // Get binaries path
            var oExec = new SAPBinaries();
            if (string.IsNullOrEmpty(oParameters.SAPGuiPath))
            {
                oParameters.sapGuiPath = oExec.DetectSAPGUIPath(PluginParameters.SAPGUIShortCutEXE);
            }

            if (string.IsNullOrEmpty(oParameters.SAPNWBCPath))
            {
                oParameters.nBCPath = oExec.DetectSAPGUIPath(PluginParameters.SAPNWBCShortCutEXE);
            }


            // Inicialize event handler
            oEvenHandler = new PluginEventHandler(oParameters, oOptions);
        }

        private void InitColumns()
        {
            // Set name of new columns
            string[] columns = { ColGuiName, ColNBCName };

            // Create instances of new column handler and add it keepass
            // Gui
            oColumnGui = new HotColumnProvider(columns[0], oParameters);
            oHost.ColumnProviderPool.Add(oColumnGui);
            // BC
            oColumnBC = new HotColumnProvider(columns[1], oParameters);
            oHost.ColumnProviderPool.Add(oColumnBC);
        }
        #endregion       
    }
}
