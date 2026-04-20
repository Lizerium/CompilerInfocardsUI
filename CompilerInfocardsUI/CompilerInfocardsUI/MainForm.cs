/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 20 апреля 2026 16:21:26
 * Version: 1.0.238
 */

using System.Threading.Tasks;

using CompilerInfocardsUI.AppData.Command;
using CompilerInfocardsUI.Services;

namespace CompilerInfocardsUI
{
    public partial class MainForm : Form
    {
        private readonly CommandServices commandServices;
        private Dictionary<string, ExeCommand> commands;

        public MainForm()
        {
            commandServices = new CommandServices("configs.json");
            commands = commandServices.Commands;
            commandServices.LogAction += CommandServiceLog;
            InitializeComponent();

            var currentPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        private async void materialButton_ALL_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM_ALL");
            await RunCommand("SBM3_ALL");
            await RunCommand("infocards_HTML");
            await RunCommand("SBM2_HTML");
            await RunCommand("misctextinfo2_HTML");
            await RunCommand("misctext_HTML");
            await RunCommand("equipresources_HTML");
            await RunCommand("SBM2_STRINGS");
            await RunCommand("offerbriberesources_STRINGS");
            await RunCommand("equipresources_STRINGS");
            await RunCommand("nameresources_STRINGS");
            await RunCommand("resources_STRINGS");
        }

        #region STRINGS COMPILE

        private async void materialButton_STRINGS_SBM2_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM2_STRINGS");
        }

        private async void materialButton_STRINGS_offerbriberesources_Click(object sender, EventArgs e)
        {
            await RunCommand("offerbriberesources_STRINGS");
        }

        private async void materialButton_STRINGS_equipresources_Click(object sender, EventArgs e)
        {
            await RunCommand("equipresources_STRINGS");
        }

        private async void materialButton_STRINGS_nameresources_Click(object sender, EventArgs e)
        {
            await RunCommand("nameresources_STRINGS");
        }

        private async void materialButton_STRINGS_resources_Click(object sender, EventArgs e)
        {
            await RunCommand("resources_STRINGS");
        }


        #endregion

        #region HTML COMPILE

        private async void materialButton_HTML_infocards_Click(object sender, EventArgs e)
        {
            await RunCommand("infocards_HTML");
        }

        private async void materialButton_HTML_SBM2_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM2_HTML");
        }

        private async void materialButton_HTML_misctextinfo2_Click(object sender, EventArgs e)
        {
            await RunCommand("misctextinfo2_HTML");
        }

        private async void materialButton_HTML_misctext_Click(object sender, EventArgs e)
        {
            await RunCommand("misctext_HTML");
        }

        private async void materialButtonHTML_equipresources_Click(object sender, EventArgs e)
        {
            await RunCommand("equipresources_HTML");
        }

        #endregion

        #region HTML AND STRING COMPILE

        private async void materialButton_ALL_SBM_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM_ALL");
        }

        private async void materialButton_ALL_SBM3_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM3_ALL");

        }

        #endregion

        #region EDIT FILES
        private async void materialButton_Open_DLLS_Click(object sender, EventArgs e)
        {
            await RunCommand("RootDLLS");
        }

        private async void materialButton_VSCODE_Click(object sender, EventArgs e)
        {
            await RunCommand("VSCODE");
        }

        private async void materialButton_E_SBM_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM_EDIT");
        }

        private async void materialButton_E_SBM2_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM2_STRINGS_EDIT");
            await RunCommand("SBM2_HTML_EDIT");
        }

        private async void materialButton_E_SBM3_Click(object sender, EventArgs e)
        {
            await RunCommand("SBM3_EDIT");
        }

        private async void materialButton_E_resources_Click(object sender, EventArgs e)
        {
            await RunCommand("resources_EDIT");
        }

        private async void materialButton_E_infocards_Click(object sender, EventArgs e)
        {
            await RunCommand("infocards_EDIT");
        }

        private async void materialButton_E_misctext_Click(object sender, EventArgs e)
        {
            await RunCommand("misctext_EDIT");
        }

        private async void materialButton_E_nameresources_Click(object sender, EventArgs e)
        {
            await RunCommand("nameresources_EDIT");
        }

        private async void materialButton_E_equipresources_Click(object sender, EventArgs e)
        {
            await RunCommand("equipresources_STRINGS_EDIT");
            await RunCommand("equipresources_HTML_EDIT");
        }

        private async void materialButton_E_offerbriberesources_Click(object sender, EventArgs e)
        {
            await RunCommand("offerbriberesources_EDIT");
        }

        private async void materialButton_E_misctextinfo2_Click(object sender, EventArgs e)
        {
            await RunCommand("misctextinfo2_EDIT");
        }

        #endregion

        private async Task RunCommand(string key)
        {
            if (commands.TryGetValue(key, out var cmd))
            {
                await commandServices.RunExeCommand(cmd.ExePath, cmd.Arguments);
                textBoxLog.AppendText($"🔥 Выполнена команда: {key}" + Environment.NewLine);
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }
            else
            {
                textBoxLog.AppendText($"💤 Команда {key} не найдена!" + Environment.NewLine);
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }
        }

        private void CommandServiceLog(string msg)
        {
            textBoxLog.AppendText(msg + Environment.NewLine);
            textBoxLog.SelectionStart = textBoxLog.Text.Length;
            textBoxLog.ScrollToCaret();
        }
    }
}
