using KeePass.Forms;
using System;
using System.Windows.Forms;

namespace KPSAPLunch
{
    public partial class OptionDialog : Form
    {
        private readonly PluginOptions pluginOptions;
        private readonly MainForm mainForm;
        private PluginParameters parameters;

        public OptionDialog(MainForm form, PluginOptions config, PluginParameters parameters)
        {
            pluginOptions = config;
            mainForm = form;
            this.parameters = parameters;

            // Standard method
            InitializeComponent();

            // Load data to form fileds
            LoadData();
        }

        private void LoadData()
        {
            if (pluginOptions == null) { return; }

            // Set Form fields value
            iApplSrv.Text = parameters.ApplSrv;
            iNumber.Text = parameters.Number;
            iClient.Text = parameters.Client;
            iSysID.Text = parameters.SysID;
            iSapRouter.Text = parameters.SapRouter;
            iLanguage.Text = parameters.Language;
            iTransaction.Text = parameters.Transaction;
            iUserName.Text = parameters.Username;
            iPassword.Text = parameters.Password;
            isMaxGui.Checked = parameters.isMaxGui;

            // Read binaries path
            //SAPBinaries oExec = new SAPBinaries();
            //iSapGuiPath.Text = oExec.DetectSAPGUIPath(PluginParameters.SAPGUIShortCutEXE);
            //iNBCSPath.Text = oExec.DetectSAPGUIPath(PluginParameters.SAPNWBCShortCutEXE);
            iSapGuiPath.Text = parameters.sapGuiPath;
            iNBCSPath.Text = parameters.nBCPath;

            if (!string.IsNullOrEmpty(iSapGuiPath.Text))
            {
                iSapGuiPath.ReadOnly = true;
            }
            else { iSapGuiPath.ReadOnly = false; }

            if (!string.IsNullOrEmpty(iNBCSPath.Text))
            {
                iNBCSPath.ReadOnly = true;
            }
            else { iNBCSPath.ReadOnly = false; }
        }

        private void SaveOptions()
        {
            if (pluginOptions != null)
            {
                // Set actuals value to active instance of plugin parametrs
                parameters.ApplSrv = iApplSrv.Text;
                parameters.Number = iNumber.Text;
                parameters.Client = iClient.Text;
                parameters.SysID = iSysID.Text;
                parameters.SapRouter = iSapRouter.Text;
                parameters.Language = iLanguage.Text;
                parameters.Transaction = iTransaction.Text;
                parameters.isMaxGui = isMaxGui.Checked;
                parameters.sapGuiPath = iSapGuiPath.Text;
                parameters.nBCPath = iNBCSPath.Text;

                // Prepare pluginOption string to store
                string strPar = parameters.ToString();

                // Save pluginOption
                pluginOptions.PluginOptionString = strPar;
            }
        }

        private void OnTransactionHover(object sender, EventArgs e)
        {
            ttOption.SetToolTip(iTransaction, "(optional)\nPlaceholder of entry with transaction, program name or system command run after sucessfull login.");
        }

        private void OnLanguageHover(object sender, EventArgs e)
        {
            ttOption.SetToolTip(iTransaction, "(optional)\nWhen placeholder stays empty or even doesn't exist on entry the language parameter won't passed.");
        }

        private void OnBtnOK_Click(object sender, EventArgs e)
        {
            // Plugin has not any check for this moment
            DialogResult = DialogResult.OK;

            SaveOptions();
            Close();
        }

        private void OnBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
