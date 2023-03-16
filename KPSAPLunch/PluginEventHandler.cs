/*
	(C) 2023 David Suchopar
*/

using KeePass.Forms;
using System;

namespace KPSAPLunch
{
    internal class PluginEventHandler
    {
        private PluginParameters oParameters;
        private PluginOptions oOptions;

        public PluginEventHandler(PluginParameters oParameters, PluginOptions oOptions)
        {
            this.oParameters = oParameters;
            this.oOptions = oOptions;
        }

        public void OnFileSaved(object sender, FileSavedEventArgs e)
        {

        }

        /// <summary>
        /// Handle event for menu click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSettingsDlg(object sender, EventArgs e)
        {
            OptionDialog dialog = new OptionDialog(KPSAPLunchExt.oHost.MainWindow, oOptions, oParameters);
            dialog.ShowDialog();

            dialog.Dispose();
        }
    }
}