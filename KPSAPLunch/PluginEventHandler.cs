/*
	(C) 2023 David Suchopar
*/

using KeePass.Forms;
using KeePassLib.Utility;
using System.Windows.Forms;
using System;

namespace KPSAPLunch
{
    internal class PluginEventHandler
    {
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
            OptionDialog dlg = new OptionDialog(KPSAPLunchExt.oHost.MainWindow, new PluginOptions(KPSAPLunchExt.oHost.CustomConfig));
            dlg.ShowDialog();

            dlg.Dispose();
        }
    }
}